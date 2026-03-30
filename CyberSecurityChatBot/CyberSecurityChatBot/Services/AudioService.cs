using System;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace CyberSecurityChatBot.Services
{
    public class AudioService
    {
        private readonly string _audioFilePath;

        public AudioService()
        {
            // Get the current directory
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Find the audio file
            string[] possiblePaths = new[]
            {
                Path.Combine(currentDirectory, "Services", "Greetings.wav"),
                Path.Combine(Directory.GetParent(currentDirectory)?.Parent?.Parent?.FullName ?? currentDirectory, "Services", "Greetings.wav"),
                Path.Combine(currentDirectory, "Resources", "Greetings.wav"),
                Path.Combine(currentDirectory, "Greetings.wav")
            };

            _audioFilePath = possiblePaths.FirstOrDefault(File.Exists) ??
                            Path.Combine(currentDirectory, "Services", "Greetings.wav");
        }

        public async Task PlayVoiceGreetingAsync()
        {
            try
            {
                if (!File.Exists(_audioFilePath))
                {
                    Console.WriteLine("⚠️ Voice greeting file not found.");
                    await PlayTextBasedGreetingAsync();
                    return;
                }

                Console.WriteLine("🔊 Playing voice greeting...");

                await PlayTextBasedGreetingAsync();
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    await PlayWindowsAudioAsync();
                }
                else
                {
                    Console.WriteLine("⚠️ Audio playback is only supported on Windows.");
                    await PlayTextBasedGreetingAsync();
                }

                Console.WriteLine("✅ Voice greeting completed");
                await Task.Delay(500);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Could not play voice greeting: {ex.Message}");
                await PlayTextBasedGreetingAsync();
            }
        }

        private async Task PlayWindowsAudioAsync()
        {
            await Task.Run(() =>
            {
                using (var player = new System.Media.SoundPlayer(_audioFilePath))
                {
                    player.PlaySync();
                }
            });
        }

        private async Task PlayTextBasedGreetingAsync()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n🔊 [VOICE GREETING SIMULATION]");
            Console.WriteLine("=================================");
            await SimulateTypingEffectAsync("Hello! Welcome to the Cybersecurity Awareness Bot. ", 40);
            await SimulateTypingEffectAsync("I'm here to help you stay safe online.", 40);
            Console.WriteLine("=================================\n");
            Console.ResetColor();
            await Task.Delay(1000);
        }

        public async Task SimulateTypingEffectAsync(string message, int delayMs = 50)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                await Task.Delay(delayMs);
            }
            Console.WriteLine();
        }

        public bool IsAudioFileValid()
        {
            return File.Exists(_audioFilePath);
        }

        public string GetAudioFileInfo()
        {
            if (!File.Exists(_audioFilePath))
                return "Audio file not found";

            var fileInfo = new FileInfo(_audioFilePath);
            return $"File: {fileInfo.Name}\nSize: {fileInfo.Length / 1024} KB\nLocation: {fileInfo.FullName}";
        }
    }
}