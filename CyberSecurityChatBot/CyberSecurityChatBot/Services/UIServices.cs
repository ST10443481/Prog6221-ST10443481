using System;
using System.Threading.Tasks;

namespace CyberSecurityChatBot.Services
{
    public class UIService
    {
        private readonly AudioService _audioService;

        private const ConsoleColor PrimaryColor = ConsoleColor.Cyan;
        private const ConsoleColor SecondaryColor = ConsoleColor.Yellow;
        private const ConsoleColor SuccessColor = ConsoleColor.Green;
        private const ConsoleColor ErrorColor = ConsoleColor.Red;
        private const ConsoleColor InfoColor = ConsoleColor.Magenta;
        private const ConsoleColor BorderColor = ConsoleColor.DarkCyan;

        public UIService(AudioService audioService)
        {
            _audioService = audioService;
        }

        public async Task DisplayWelcomeScreenAsync()
        {
            Console.Clear();
            DisplayAsciiArt();
            await Task.Delay(500);
        }

        public void DisplayAsciiArt()
        {
            Console.ForegroundColor = PrimaryColor;

            string asciiArt = @"
    ╔═══════════════════════════════════════════════════════════════════╗
    ║                                                                   ║
    ║     ██████╗██╗   ██╗██████╗ ███████╗██████╗                     ║
    ║    ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗                    ║
    ║    ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝                    ║
    ║    ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗                    ║
    ║    ╚██████╗   ██║   ██████╔╝███████╗██║  ██║                    ║
    ║     ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝                    ║
    ║                                                                   ║
    ║              █████╗ ██╗    ██╗ █████╗ ██████╗ ███████╗          ║
    ║             ██╔══██╗██║    ██║██╔══██╗██╔══██╗██╔════╝          ║
    ║             ███████║██║ █╗ ██║███████║██████╔╝█████╗            ║
    ║             ██╔══██║██║███╗██║██╔══██║██╔══██╗██╔══╝            ║
    ║             ██║  ██║╚███╔███╔╝██║  ██║██║  ██║███████╗          ║
    ║             ╚═╝  ╚═╝ ╚══╝╚══╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚══════╝          ║
    ║                                                                   ║
    ║              SOUTH AFRICAN CYBERSECURITY AWARENESS                ║
    ║                           ASSISTANT                               ║
    ║                                                                   ║
    ╚═══════════════════════════════════════════════════════════════════╝";

            Console.WriteLine(asciiArt);
            Console.ResetColor();
            Console.WriteLine();
        }

        public void DisplaySimpleLogo()
        {
            Console.ForegroundColor = SecondaryColor;

            string logo = @"
    ╔═══════════════════════════════════════════════════════════════════╗
    ║                     🔒  CYBER GUARDIAN  🔒                        ║
    ║                 Your Digital Safety Companion                     ║
    ║                          🇿🇦                                       ║
    ╚═══════════════════════════════════════════════════════════════════╝";

            Console.WriteLine(logo);
            Console.ResetColor();
        }

        public async Task DisplayAudioStatusAsync(AudioService audioService)
        {
            DisplaySectionHeader("🔊 VOICE GREETING STATUS");

            if (audioService.IsAudioFileValid())
            {
                DisplaySuccess("Voice greeting file found and valid!");
                Console.WriteLine(audioService.GetAudioFileInfo());
            }
            else
            {
                DisplayError("Voice greeting file not found or invalid");
                DisplayInfo("Please ensure Greetings.wav is in the Services folder");
            }

            await Task.Delay(1000);
        }

        public void DisplaySectionHeader(string title)
        {
            Console.ForegroundColor = BorderColor;
            Console.WriteLine($"\n╔{new string('═', 58)}╗");
            Console.WriteLine($"║{title.PadLeft(29 + title.Length / 2).PadRight(58)}║");
            Console.WriteLine($"╚{new string('═', 58)}╝");
            Console.ResetColor();
        }

        public void DisplaySuccess(string message)
        {
            Console.ForegroundColor = SuccessColor;
            Console.WriteLine($"✅ {message}");
            Console.ResetColor();
        }

        public void DisplayError(string message)
        {
            Console.ForegroundColor = ErrorColor;
            Console.WriteLine($"❌ {message}");
            Console.ResetColor();
        }

        public void DisplayInfo(string message)
        {
            Console.ForegroundColor = InfoColor;
            Console.WriteLine($"ℹ️ {message}");
            Console.ResetColor();
        }

        public void DisplaySeparator()
        {
            Console.ForegroundColor = BorderColor;
            Console.WriteLine($"\n{new string('─', 60)}");
            Console.ResetColor();
        }

        public void DisplayMenu()
        {
            DisplaySectionHeader("📋 Available Topics");

            Console.WriteLine(@"
  🔐  Passwords     - Create strong password
  📱  Social Media  - Stay safe on social platforms
  🦠  Malware       - Protect from viruses
  🔗  Links         - Identify suspicious URLs
  🏦  Banking       - Secure online banking
  📶  WiFi          - Safe network usage
  ⚠️  Scams         - What to do if scammed
  ❓  Help          - Show this menu again
  👋  Bye           - Exit the chatbot");

            DisplaySeparator();
        }

        public void DisplayUserPrompt(string userName)
        {
            Console.ForegroundColor = SecondaryColor;
            Console.Write($"\n👤 [{userName}]: ");
            Console.ResetColor();
        }

        public string GetUserInput()
        {
            return Console.ReadLine()?.Trim() ?? string.Empty;
        }

        public string GetValidatedUserInput(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(input))
                {
                    DisplayError("Input cannot be empty. Please try again.");
                }
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }

        public void DisplayBotMessage(string message)
        {
            Console.ForegroundColor = PrimaryColor;
            Console.Write($"\n🤖 [BOT]: ");
            Console.ResetColor();
            Console.WriteLine(message);
        }

        public async Task DisplayBotMessageWithTypingEffect(string message, int delayMs = 30)
        {
            Console.ForegroundColor = PrimaryColor;
            Console.Write($"\n🤖 [BOT]: ");
            Console.ResetColor();

            await _audioService.SimulateTypingEffectAsync(message, delayMs);
        }

        public void DisplayFooter()
        {
            Console.ForegroundColor = BorderColor;
            Console.WriteLine($"\n{new string('═', 60)}");
            Console.ForegroundColor = InfoColor;
            Console.WriteLine("  Stay Safe Online! 🇿🇦  |  Report Cybercrime: 012 393 3115");
            Console.ForegroundColor = BorderColor;
            Console.WriteLine(new string('═', 60));
            Console.ResetColor();
        }
    }
}