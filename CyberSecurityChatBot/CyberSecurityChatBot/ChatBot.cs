using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CyberSecurityChatBot.Models;
using CyberSecurityChatBot.Services;

namespace CyberSecurityChatBot
{
    public class Chatbot
    {
        private readonly User _currentUser;
        private readonly List<ConversationEntry> _conversationHistory;
        private readonly KnowledgeBase _knowledgeBase;
        private readonly UIService _uiService;
        private readonly AudioService _audioService;

        private bool _isRunning;

        public Chatbot()
        {
            _currentUser = new User();
            _conversationHistory = new List<ConversationEntry>();
            _knowledgeBase = new KnowledgeBase();
            _audioService = new AudioService();
            _uiService = new UIService(_audioService);
            _isRunning = true;
        }

        public async Task StartAsync()
        {
            try
            {
                // Display welcome screen with ASCII art
                await _uiService.DisplayWelcomeScreenAsync();

                // Check audio file status
                await _uiService.DisplayAudioStatusAsync(_audioService);

                // Play voice greeting
                await _audioService.PlayVoiceGreetingAsync();

                // Display simple logo after voice greeting
                _uiService.DisplaySimpleLogo();

                // Small pause for effect
                await Task.Delay(500);

                // Get user information
                await GetUserInformationAsync();

                // Display welcome message
                await DisplayPersonalizedWelcomeAsync();

                // Show available topics
                _uiService.DisplayMenu();

                // Main conversation loop
                await ConversationLoopAsync();
            }
            catch (Exception ex)
            {
                _uiService.DisplayError($"An error occurred: {ex.Message}");
            }
        }

        private async Task GetUserInformationAsync()
        {
            _uiService.DisplaySectionHeader("👤 TELL ME ABOUT YOURSELF");

            // Get user name with validation
            string name = _uiService.GetValidatedUserInput("Enter your name: ");
            _currentUser.Name = name;

            // Get age (optional)
            _uiService.DisplayInfo("Age is optional - press Enter to skip");
            Console.Write("Enter your age (optional): ");
            string ageInput = Console.ReadLine()?.Trim() ?? string.Empty;

            if (!string.IsNullOrWhiteSpace(ageInput) && int.TryParse(ageInput, out int age))
            {
                _currentUser.Age = age;
            }

            _currentUser.IsAuthenticated = true;
            LogConversation("SYSTEM", $"User {name} started session");
        }

        private async Task DisplayPersonalizedWelcomeAsync()
        {
            _uiService.DisplaySectionHeader($"✨ WELCOME, {_currentUser.Name.ToUpper()}! ✨");

            string welcomeMessage = $"Hello {_currentUser.Name}! I'm your personal Cybersecurity Awareness Assistant. " +
                                   "I'm here to help you learn about staying safe online in South Africa. " +
                                   "Feel free to ask me anything about cybersecurity!";

            await _uiService.DisplayBotMessageWithTypingEffect(welcomeMessage, 30);

            if (_currentUser.Age > 0 && _currentUser.Age < 18)
            {
                _uiService.DisplayInfo("I see you're a young user! I'll make sure to explain things in an easy-to-understand way.");
            }
            else if (_currentUser.Age > 60)
            {
                _uiService.DisplayInfo("Great to have you here! I'll provide clear, step-by-step advice for staying safe online.");
            }

            _uiService.DisplaySeparator();
        }

        private async Task ConversationLoopAsync()
        {
            while (_isRunning)
            {
                // Get user input
                _uiService.DisplayUserPrompt(_currentUser.Name);
                string userInput = _uiService.GetUserInput();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    _uiService.DisplayError("Please type something. I'm here to help!");
                    continue;
                }

                // Update user stats
                _currentUser.UpdateLastInteraction();

                // Log user message
                LogConversation("USER", userInput);

                // Process input and generate response
                await ProcessUserInputAsync(userInput);
            }
        }

        private async Task ProcessUserInputAsync(string input)
        {
            string response;

            // Convert to lowercase for matching
            string lowerInput = input.ToLower();

            // Check for exit
            if (_knowledgeBase.IsFarewell(lowerInput))
            {
                await HandleFarewellAsync();
                return;
            }

            // Check for help
            if (_knowledgeBase.IsHelpRequest(lowerInput))
            {
                response = _knowledgeBase.GetHelpText();
                await _uiService.DisplayBotMessageWithTypingEffect(response, 20);
                LogConversation("BOT", response);
                return;
            }

            // Check for basic responses
            string basicResponse = _knowledgeBase.GetBasicResponse(lowerInput);
            if (!string.IsNullOrEmpty(basicResponse))
            {
                await _uiService.DisplayBotMessageWithTypingEffect(basicResponse, 25);
                LogConversation("BOT", basicResponse);
                return;
            }

            // Check for cybersecurity topics
            var (topicResponse, topic) = _knowledgeBase.MatchTopic(lowerInput);
            if (!string.IsNullOrEmpty(topicResponse))
            {
                await _uiService.DisplayBotMessageWithTypingEffect(topicResponse, 30);
                LogConversation("BOT", topicResponse);

                // Offer follow-up help
                await Task.Delay(500);
                _uiService.DisplayInfo("Would you like to learn about another topic? Just ask or type 'menu' to see options.");
                return;
            }

            // Default response for unrecognized input
            response = _knowledgeBase.GetDefaultResponse();
            await _uiService.DisplayBotMessageWithTypingEffect(response, 30);
            LogConversation("BOT", response);
        }

        private async Task HandleFarewellAsync()
        {
            _isRunning = false;

            // Display session summary
            DisplaySessionSummary();

            // Farewell message
            string farewell = _knowledgeBase.GetBasicResponse("goodbye");
            if (string.IsNullOrEmpty(farewell))
            {
                farewell = "Stay safe online! Remember, cybersecurity is everyone's responsibility.";
            }

            await _uiService.DisplayBotMessageWithTypingEffect(farewell, 30);

            // Ask if user wants to see conversation history
            _uiService.DisplayInfo("Would you like to see your conversation history? (yes/no)");
            _uiService.DisplayUserPrompt(_currentUser.Name);
            string showHistory = _uiService.GetUserInput().ToLower();

            if (showHistory == "yes" || showHistory == "y")
            {
                DisplayConversationHistory();
            }

            // Display footer
            _uiService.DisplayFooter();

            LogConversation("SYSTEM", "Session ended");
        }

        private void DisplaySessionSummary()
        {
            _uiService.DisplaySectionHeader("📊 SESSION SUMMARY");

            TimeSpan duration = _currentUser.GetSessionDuration();

            Console.WriteLine($"  👤 User: {_currentUser.Name}");
            if (_currentUser.Age > 0)
            {
                Console.WriteLine($"  📅 Age: {_currentUser.Age}");
            }
            Console.WriteLine($"  ⏱️  Session Duration: {duration.Minutes} minutes, {duration.Seconds} seconds");
            Console.WriteLine($"  💬 Messages Exchanged: {_currentUser.InteractionsCount}");

            _uiService.DisplaySeparator();
        }

        private void DisplayConversationHistory()
        {
            _uiService.DisplaySectionHeader("📜 CONVERSATION HISTORY");

            foreach (var entry in _conversationHistory)
            {
                Console.WriteLine(entry.ToString());
            }

            _uiService.DisplaySeparator();
        }

        private void LogConversation(string speaker, string message)
        {
            _conversationHistory.Add(new ConversationEntry
            {
                Timestamp = DateTime.Now,
                Speaker = speaker,
                Message = message
            });
        }
    }
}