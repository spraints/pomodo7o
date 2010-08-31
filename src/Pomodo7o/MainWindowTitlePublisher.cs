using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace Pomodo7o
{
    public class MainWindowTitlePublisher : IPomodoroPublisher
    {
        private readonly Pomodo7oWindow _window;
        private readonly string _baseTitle;
        private string _mode;
        private bool _isPaused;

        public MainWindowTitlePublisher(Pomodo7oWindow window)
        {
            _window = window;
            _baseTitle = _window.Title;
            _mode = null;
            _isPaused = false;
        }

        public void Dispose()
        {
            try
            {
                _mode = null;
                _isPaused = false;
                UpdateTitle();
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
            }
        }

        public void WorkStarted()
        {
            _mode = "Work!";
            UpdateTitle();
        }

        public void WorkPercent(int percent)
        {
        }

        public void WorkTimeLeft(TimeSpan remaining)
        {
        }

        public void WorkComplete()
        {
        }

        public void RestStarted()
        {
            _mode = "Rest";
            UpdateTitle();
        }

        public void RestPercent(int percent)
        {
        }

        public void RestTimeLeft(TimeSpan remaining)
        {
        }

        public void RestComplete()
        {
        }

        public void Paused()
        {
            _isPaused = true;
            UpdateTitle();
        }

        public void Resumed()
        {
            _isPaused = false;
            UpdateTitle();
        }

        private void UpdateTitle()
        {
            var newTitle = _baseTitle;
            if(_mode != null)
            {
                newTitle += " - " + _mode;
                if(_isPaused)
                {
                    newTitle += " (paused)";
                }
            }
            _window.Title = newTitle;
        }
    }
}
