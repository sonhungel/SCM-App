using System;
using System.Collections.Generic;
using System.Text;

namespace SCMApp.Presentation.Views
{
    public interface IWaitCursorScope : IDisposable
    {
        void PauseWaitCursor();
        void ContinueWaitCursor();
    }
}
