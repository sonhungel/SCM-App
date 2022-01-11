using System;

namespace SCMApp.Presentation.Views
{
    public sealed class WaitCursorScope : IDisposable
    {
        private bool _disposed;
        private readonly IWaitCursorScope _waitCursorScope;

        public WaitCursorScope()
        {
            _waitCursorScope = IoC.Get<IWaitCursorScope>();
        }

        public void PauseWaitCursor()
        {
            _waitCursorScope.PauseWaitCursor();
        }

        public void ContinueWaitCursor()
        {
            _waitCursorScope.ContinueWaitCursor();
        }

        public void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            if (disposing)
            {
                _waitCursorScope.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
