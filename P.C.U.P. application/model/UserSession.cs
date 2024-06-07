using System;

namespace pcup.app
{
    public class UserSession
    {
        // Properties
        public int UsirId { get; private set; }
        public string Usirname { get; private set; }
        public string Imail { get; private set; }

        public UserSession(int usirId, string usirName, string imail)
        {
            UsirId = usirId;
            Usirname = usirName;
            Imail = imail;
        }

        // Event to notify listeners
        public event EventHandler SessionDataAvailable;

        // Method to trigger the event
        public void OnSessionDataAvailable()
        {
            SessionDataAvailable?.Invoke(this, EventArgs.Empty);
        }
    }
}

