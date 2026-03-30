using System;
using System.Collections.Generic;

namespace CyberSecurityChatBot.Models
{
    public class ConversationEntry
    {
        public DateTime Timestamp { get; set; }
        public string Speaker { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"[{Timestamp:HH:mm:ss}] {Speaker}: {Message}";
        }
    }

    public class Topic
    {
        public string Name { get; set; } = string.Empty;
        public List<string> Keywords { get; set; } = new List<string>();
        public List<string> Responses { get; set; } = new List<string>();
        public string Advice { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }
}