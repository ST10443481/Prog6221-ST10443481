using System;

namespace CyberSecurityChatBot.Models
{
    public class User
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public DateTime SessionStartTime { get; set; }
        public DateTime LastInteractionTime { get; set; }

        // Auto-implemented properties
        public bool IsAuthenticated { get; set; }
        public int InteractionsCount { get; set; }

        public User()
        {
            SessionStartTime = DateTime.Now;
            LastInteractionTime = DateTime.Now;
            IsAuthenticated = false;
            InteractionsCount = 0;
        }

        public void UpdateLastInteraction()
        {
            LastInteractionTime = DateTime.Now;
            InteractionsCount++;
        }

        public TimeSpan GetSessionDuration()
        {
            return DateTime.Now - SessionStartTime;
        }
    }
}