using CyberSecurityChatBot.Models;

namespace CyberSecurityChatBot.Services
{
    public class KnowledgeBase
    {
        private readonly Dictionary<string, Topic> _topics;
        private readonly Random _random;
        private readonly Dictionary<string, string[]> _basicResponses;

        public KnowledgeBase()
        {
            _random = new Random();
            _topics = InitializeTopics();
            _basicResponses = InitializeBasicResponses();
        }

        private Dictionary<string, string[]> InitializeBasicResponses()
        {
            return new Dictionary<string, string[]>
            {
                { "how are you", new string[]
                    {
                        "I'm doing great, thank you for asking! Ready to help you stay safe online.",
                        "I'm functioning perfectly! How can I assist you with cybersecurity today?",
                        "All systems operational! What would you like to learn about?"
                    }
                },

                { "what is your purpose", new string[]
                    {
                        "I'm your Cybersecurity Awareness Assistant, created to educate South African citizens about online safety. I can help you understand phishing, passwords, safe browsing, and more!",
                        "My purpose is to help you navigate the digital world safely. Think of me as your personal cybersecurity guide!",
                        "I'm here to spread cybersecurity awareness and help protect South Africans from online threats."
                    }
                },

                { "what can i ask you about", new string[]
                    {
                        "You can ask me about passwords, phishing emails, social media safety, malware, suspicious links, online banking, public WiFi, and what to do if you've been scammed. Just type 'help' to see all topics!",
                        "Feel free to ask about any cybersecurity topic! Password safety, phishing scams, safe browsing - I'm here to help."
                    }
                },

                { "who created you", new string[]
                    {
                        "I was created as part of the Department of Cybersecurity's campaign to educate South African citizens about online safety.",
                        "I'm a project developed to promote cybersecurity awareness in South Africa."
                    }
                },

                { "thank", new string[]
                    {
                        "You're welcome! Stay safe online!",
                        "My pleasure! Remember to share these tips with family and friends.",
                        "Glad I could help! That's what I'm here for."
                    }
                },

                { "thanks", new string[]
                    {
                        "You're welcome! Stay safe online!",
                        "My pleasure! Remember to share these tips with family and friends.",
                        "Glad I could help! That's what I'm here for."
                    }
                },

                { "hello", new string[]
                    {
                        "Hello! I'm your Cybersecurity Awareness Assistant. How can I help you today?",
                        "Hi there! Ready to learn about staying safe online?",
                        "Greetings! I'm here to help you protect your digital life."
                    }
                },

                { "hi", new string[]
                    {
                        "Hello! I'm your Cybersecurity Awareness Assistant. How can I help you today?",
                        "Hi there! Ready to learn about staying safe online?",
                        "Greetings! I'm here to help you protect your digital life."
                    }
                },

                { "hey", new string[]
                    {
                        "Hello! I'm your Cybersecurity Awareness Assistant. How can I help you today?",
                        "Hi there! Ready to learn about staying safe online?",
                        "Greetings! I'm here to help you protect your digital life."
                    }
                },

                { "goodbye", new string[]
                    {
                        "Stay safe online! Remember, cybersecurity is everyone's responsibility.",
                        "Goodbye! Keep your digital life secure and protected.",
                        "Until next time! Stay vigilant against cyber threats."
                    }
                },

                { "bye", new string[]
                    {
                        "Stay safe online! Remember, cybersecurity is everyone's responsibility.",
                        "Goodbye! Keep your digital life secure and protected.",
                        "Until next time! Stay vigilant against cyber threats."
                    }
                },

                { "exit", new string[]
                    {
                        "Stay safe online! Remember, cybersecurity is everyone's responsibility.",
                        "Goodbye! Keep your digital life secure and protected.",
                        "Until next time! Stay vigilant against cyber threats."
                    }
                }
            };
        }

        private Dictionary<string, Topic> InitializeTopics()
        {
            var topics = new Dictionary<string, Topic>();

            // Phishing topic
            var phishingTopic = new Topic
            {
                Name = "Phishing",
                Category = "Email Security",
                Keywords = new List<string> {
                    "phishing", "email", "scam", "fake email", "suspicious email",
                    "clicked link", "strange email", "email scam"
                },
                Responses = new List<string>
                {
                    "Phishing emails are messages that appear legitimate but aim to steal your personal information. They often create a sense of urgency.",
                    "In South Africa, phishing attacks have increased significantly. Always check the sender's email address carefully for misspellings.",
                    "🚨 *Phishing Red Flags*: Urgent language, spelling mistakes, suspicious links, requests for personal info.",
                    "Never click on links in unexpected emails. Instead, type the website address directly in your browser.",
                    "Remember: Banks and government departments in SA will NEVER ask for your password or PIN via email.",
                    "Look out for emails claiming you've won a prize or need to verify your account urgently."
                },
                Advice = "If you receive a suspicious email, report it to the South African Police Service's Cyber Crime unit at 012 393 3115."
            };
            topics.Add("phishing", phishingTopic);

            // Passwords topic
            var passwordsTopic = new Topic
            {
                Name = "Passwords",
                Category = "Account Security",
                Keywords = new List<string> {
                    "password", "passwords", "secure password", "strong password",
                    "password safety", "login", "credentials", "log in"
                },
                Responses = new List<string>
                {
                    "Strong passwords are your first line of defense against cyber attacks. Use a mix of uppercase, lowercase, numbers, and symbols.",
                    "Avoid using personal information like your ID number, birth date, or common words like 'password123'.",
                    "Consider using a password manager to keep track of all your passwords securely.",
                    "Enable two-factor authentication (2FA) whenever possible - it adds an extra layer of security.",
                    "A strong password should be at least 12 characters long and unique for each account.",
                    "Never share your passwords with anyone, not even family members."
                },
                Advice = "Change your passwords every 3 months and never reuse passwords across different accounts."
            };
            topics.Add("passwords", passwordsTopic);

            // Social Media topic
            var socialMediaTopic = new Topic
            {
                Name = "Social Media",
                Category = "Online Presence",
                Keywords = new List<string> {
                    "social media", "facebook", "twitter", "instagram", "whatsapp",
                    "tiktok", "sharing", "post", "profile"
                },
                Responses = new List<string>
                {
                    "Be careful what you share on social media - cybercriminals can use this information for targeted attacks.",
                    "Avoid posting your location, ID number, or when you're going on holiday.",
                    "Review your privacy settings regularly on all social media platforms.",
                    "In South Africa, the Protection of Personal Information Act (POPIA) protects your data privacy.",
                    "Think twice before accepting friend requests from people you don't know.",
                    "Photos can reveal more than you think - check for sensitive information in the background."
                },
                Advice = "Set your profiles to private and be selective about who you connect with online."
            };
            topics.Add("socialmedia", socialMediaTopic);

            // Malware topic
            var malwareTopic = new Topic
            {
                Name = "Malware",
                Category = "Device Security",
                Keywords = new List<string> {
                    "malware", "virus", "software", "download", "antivirus", "infected",
                    "computer slow", "pop up", "ransomware"
                },
                Responses = new List<string>
                {
                    "Malware includes viruses, spyware, and ransomware that can harm your device and steal your data.",
                    "Only download apps from official stores like Google Play Store or Apple App Store.",
                    "Keep your antivirus software updated and run regular scans to catch threats early.",
                    "Be wary of pop-ups claiming your computer is infected - these are often scams.",
                    "Ransomware attacks have been targeting South African businesses and individuals.",
                    "Don't insert unknown USB drives into your computer - they could contain malware."
                },
                Advice = "Back up your important files regularly to an external hard drive or cloud storage."
            };
            topics.Add("malware", malwareTopic);

            // Links topic
            var linksTopic = new Topic
            {
                Name = "Links",
                Category = "Web Browsing",
                Keywords = new List<string> {
                    "link", "click", "url", "website", "web address", "suspicious link",
                    "shortened link", "bit.ly", "tinyurl"
                },
                Responses = new List<string>
                {
                    "Before clicking a link, hover over it to see the actual URL destination.",
                    "Look for 'https://' in the website address - the 's' means secure connection.",
                    "Be cautious with shortened links as they hide the real destination.",
                    "Scammers often create fake websites that look identical to legitimate ones.",
                    "Type important website addresses directly rather than clicking links in emails.",
                    "Check for misspellings in website addresses - like 'g00gle.com' instead of 'google.com'."
                },
                Advice = "If a link looks suspicious, don't click it. Use a link checker website first."
            };
            topics.Add("links", linksTopic);

            // Banking topic
            var bankingTopic = new Topic
            {
                Name = "Banking",
                Category = "Financial Security",
                Keywords = new List<string> {
                    "bank", "banking", "payment", "money", "transfer", "eft",
                    "account", "credit card", "transaction"
                },
                Responses = new List<string>
                {
                    "South African banks will never ask for your PIN or password via SMS, email, or phone call.",
                    "Use your bank's official app for transactions rather than public computers.",
                    "Check your bank statements regularly for unauthorized transactions.",
                    "Beware of 'SIM swap' scams - contact your mobile provider immediately if you lose signal.",
                    "The South African Banking Risk Information Centre (SABRIC) reports rising banking scams.",
                    "Set up transaction notifications so you're alerted to any activity on your account."
                },
                Advice = "Register for SMS notifications for all transactions on your bank accounts."
            };
            topics.Add("banking", bankingTopic);

            // WiFi topic
            var wifiTopic = new Topic
            {
                Name = "WiFi",
                Category = "Network Security",
                Keywords = new List<string> {
                    "wifi", "wi-fi", "public wifi", "hotspot", "internet", "network",
                    "free wifi", "wireless"
                },
                Responses = new List<string>
                {
                    "Public WiFi networks in malls, coffee shops, and airports are often unsecured.",
                    "Avoid accessing banking apps or entering passwords when connected to public WiFi.",
                    "Use a VPN (Virtual Private Network) when connecting to public networks.",
                    "Make sure your home WiFi is password protected with WPA2 or WPA3 encryption.",
                    "Change your WiFi router's default admin password - many people never do this!",
                    "Disable file sharing when connecting to public networks."
                },
                Advice = "Turn off WiFi when you're not using it to prevent automatic connections."
            };
            topics.Add("wifi", wifiTopic);

            // Scams topic
            var scamsTopic = new Topic
            {
                Name = "Scams",
                Category = "Emergency Response",
                Keywords = new List<string> {
                    "scam", "fraud", "cheated", "lost money", "victim", "report",
                    "help", "emergency", "scammed", "hacked"
                },
                Responses = new List<string>
                {
                    "🚨 **If you think you've been scammed in South Africa, act quickly:**",
                    "1️⃣ Contact your bank immediately to stop payments or freeze accounts.",
                    "2️⃣ Report the incident to the South African Police Service (SAPS).",
                    "3️⃣ Lay a charge and get a case number.",
                    "4️⃣ Report cybercrime to the SAPS Cyber Crime unit at 012 393 3115.",
                    "5️⃣ Report scams to the Internet Service Providers' Association (ISPA)."
                },
                Advice = "Keep records of all communications and transactions related to the scam."
            };
            topics.Add("scams", scamsTopic);

            return topics;
        }

        public string GetBasicResponse(string input)
        {
            input = input.ToLower();

            foreach (var kvp in _basicResponses)
            {
                if (input.Contains(kvp.Key))
                {
                    var responses = kvp.Value;
                    return responses[_random.Next(responses.Length)];
                }
            }

            return string.Empty;
        }

        public (string response, string? topic) MatchTopic(string input)
        {
            input = input.ToLower();

            foreach (var topic in _topics.Values)
            {
                foreach (var keyword in topic.Keywords)
                {
                    if (input.Contains(keyword.ToLower()))
                    {
                        var response = topic.Responses[_random.Next(topic.Responses.Count)];

                        if (_random.NextDouble() < 0.3)
                        {
                            response += $"\n\n💡 *Tip: {topic.Advice}";
                        }
                        return (response, topic.Name);
                    }
                }
            }
            return (string.Empty, null);
        }

        public string GetDefaultResponse()
        {
            string[] defaultResponses = new[]
            {
                "I'm not sure I understand. Could you rephrase that? You can ask me about passwords, phishing, safe browsing, and more!",
                "I didn't quite catch that. Try asking about specific topics like 'password safety' or 'phishing emails'.",
                "Hmm, I don't have information about that. Would you like to learn about cybersecurity topics instead? Type 'help' to see what I can do.",
                "I'm still learning about cybersecurity topics. Could you ask me something about online safety?",
                "That's an interesting question, but I specialize in cybersecurity awareness. Try asking about passwords, phishing, or safe browsing."
            };

            return defaultResponses[_random.Next(defaultResponses.Length)];
        }

        public string GetHelpText()
        {
            return @"📚 I can help you with these cybersecurity topics:

🔐 Passwords - Creating strong passwords, password managers, 2FA
📱 Social Media - Privacy settings, safe sharing, fake profiles
🦠 Malware - Viruses, ransomware, antivirus software
🔗 Links - Identifying suspicious URLs, safe clicking
🏦 Banking - Online banking safety, SIM swap scams
📶 WiFi - Public WiFi risks, home network security
⚠️ Scams - What to do if you've been scammed

Just type any topic above and I'll provide information!";
        }

        public bool IsGreeting(string input)
        {
            string[] greetingPatterns = { "hello", "hi", "hey", "howdy", "greetings" };
            foreach (var pattern in greetingPatterns)
            {
                if (input.Contains(pattern))
                    return true;
            }
            return false;
        }

        public bool IsFarewell(string input)
        {
            string[] farewellPatterns = { "bye", "goodbye", "exit", "quit", "see you" };
            foreach (var pattern in farewellPatterns)
            {
                if (input.Contains(pattern))
                    return true;
            }
            return false;
        }

        public bool IsHelpRequest(string input)
        {
            string[] helpPatterns = { "help", "what can you do", "menu", "options" };
            foreach (var pattern in helpPatterns)
            {
                if (input.Contains(pattern))
                    return true;
            }
            return false;
        }
    }
}