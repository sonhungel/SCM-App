using System;

namespace SCMApp.Presentation.Views
{
    public interface IWaitCursorScope : IDisposable
    {
        void PauseWaitCursor();
        void ContinueWaitCursor();
    }
}
