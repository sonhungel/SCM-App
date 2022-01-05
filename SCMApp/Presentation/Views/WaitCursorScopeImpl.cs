using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace SCMApp.Presentation.Views
{
    public class WaitCursorScopeImpl : IWaitCursorScope
    {
        private bool _disposed;
        private bool _isRootScope;
        private bool _isPausingWaitCursor;

        public WaitCursorScopeImpl()
        {
            Application.Current.Dispatcher.Invoke(DisplayWaitCursor);
        }

        public void PauseWaitCursor()
        {
            if (_isRootScope && !_isPausingWaitCursor)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    Mouse.OverrideCursor = null;
                    _isPausingWaitCursor = true;
                });
            }
        }

        public void ContinueWaitCursor()
        {
            if (_isPausingWaitCursor)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    DisplayWaitCursor();
                    _isPausingWaitCursor = false;
                });
            }
        }

        private void DisplayWaitCursor()
        {
            _isRootScope = Mouse.OverrideCursor != Cursors.Wait;
            if (_isRootScope)
            {
                Mouse.OverrideCursor = Cursors.Wait;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            if (disposing && _isRootScope)
            {
                Application.Current.Dispatcher.Invoke(() => Mouse.OverrideCursor = null);
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
