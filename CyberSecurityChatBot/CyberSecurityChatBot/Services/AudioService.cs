using System;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace CyberSecurityChatBot.Services
{
    public class AudioService
    {
        private readonly string _audioFilePath;
        private readonly bool _isWindows;

        public AudioService()
        {
            // Detect if running on Windows
            _isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

            // Get the current directory
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Your specific file path (corrected from Greetings.wav to Greeting.wav)
            string[] possiblePaths = new[]
            {
                // Direct path from your project
                @"C:\Users\lab_services_student\Documents\GitHub\Prog6221-ST10443481\CyberSecurityChatBot\CyberSecurityChatBot\Services\Greeting.wav",
                
                // Relative paths from current directory
                Path.Combine(currentDirectory, "Services", "Greeting.wav"),
                Path.Combine(currentDirectory, "Services", "Greetings.wav"), // Fallback
                Path.Combine(currentDirectory, "Resources", "Greeting.wav"),
                Path.Combine(currentDirectory, "Resources", "Greetings.wav"),
                Path.Combine(currentDirectory, "Greeting.wav"),
                Path.Combine(currentDirectory, "Greetings.wav"),
                
                // Project directory paths
                Path.Combine(Directory.GetParent(currentDirectory)?.Parent?.Parent?.FullName ?? currentDirectory, "Services", "Greeting.wav"),
                Path.Combine(Directory.GetParent(currentDirectory)?.Parent?.Parent?.FullName ?? currentDirectory, "Services", "Greetings.wav"),
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Services", "Greeting.wav")
            };

            // Find the first existing file
            _audioFilePath = possiblePaths.FirstOrDefault(File.Exists) ??
                            Path.Combine(currentDirectory, "Services", "Greeting.wav");
        }

        public async Task PlayVoiceGreetingAsync()
        {
            try
            {
                // Check if audio file exists
                if (!File.Exists(_audioFilePath))
                {
                    Console.WriteLine("⚠️ Voice greeting file not found.");
                    Console.WriteLine($"Expected location: {_audioFilePath}");
                    await PlayTextBasedGreetingAsync();
                    return;
                }

                Console.WriteLine($"🔊 Found audio file: {Path.GetFileName(_audioFilePath)}");

                // Play actual audio only on Windows
                if (_isWindows)
                {
                    bool audioPlayed = await PlayWindowsAudioAsync();
                    if (audioPlayed)
                    {
                        Console.WriteLine("✅ Voice greeting completed");
                    }
                    else
                    {
                        Console.WriteLine("⚠️ Audio playback failed, using text simulation.");
                        await PlayTextBasedGreetingAsync();
                    }
                }
                else
                {
                    Console.WriteLine("⚠️ Audio playback is only supported on Windows.");
                    await PlayTextBasedGreetingAsync();
                }

                await Task.Delay(500);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Could not play voice greeting: {ex.Message}");
                await PlayTextBasedGreetingAsync();
            }
        }

        private async Task<bool> PlayWindowsAudioAsync()
        {
            try
            {
                await Task.Run(() =>
                {
                    using (var player = new SoundPlayer(_audioFilePath))
                    {
                        // PlaySync blocks until audio finishes
                        player.PlaySync();
                    }
                });
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Audio playback error: {ex.Message}");
                return false;
            }
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
            return $"File: {fileInfo.Name}\n" +
                   $"Size: {fileInfo.Length / 1024} KB\n" +
                   $"Location: {fileInfo.FullName}\n" +
                   $"Platform: {(_isWindows ? "Windows" : "Non-Windows")}";
        }

        // Helper method to test audio playback
        public async Task TestAudioPlaybackAsync()
        {
            Console.WriteLine("\n=== Testing Audio Playback ===\n");
            Console.WriteLine($"Audio file path: {_audioFilePath}");
            Console.WriteLine($"File exists: {File.Exists(_audioFilePath)}");
            Console.WriteLine($"Platform: {(_isWindows ? "Windows" : "Non-Windows")}");

            if (File.Exists(_audioFilePath))
            {
                var fileInfo = new FileInfo(_audioFilePath);
                Console.WriteLine($"File name: {fileInfo.Name}");
                Console.WriteLine($"File size: {fileInfo.Length} bytes");
                Console.WriteLine($"File extension: {fileInfo.Extension}");
                Console.WriteLine($"Directory: {fileInfo.DirectoryName}");

                // Try to play the audio
                if (_isWindows)
                {
                    Console.WriteLine("\nAttempting to play audio...");
                    bool played = await PlayWindowsAudioAsync();
                    Console.WriteLine(played ? "✅ Audio played successfully!" : "❌ Audio playback failed");
                }
                else
                {
                    Console.WriteLine("\n⚠️ Audio playback only supported on Windows");
                }
            }
            else
            {
                Console.WriteLine("\n❌ Audio file not found!");
                Console.WriteLine("Please ensure Greeting.wav is in the correct location:");
                Console.WriteLine($"  Expected: {_audioFilePath}");
                Console.WriteLine("\nCheck if the file name is exactly 'Greeting.wav' (case-sensitive)");
            }
        }
    }
}