using System;
using System.IO;
using System.Runtime.InteropServices;

namespace CyberSecurityChatBot
{
    public static class TestAudio
    {
        public static void TestVoiceGreeting()
        {
            Console.WriteLine("Testing Voice Greeting...");
            Console.WriteLine("======================\n");

            // Check platform
            bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            Console.WriteLine($"Platform: {(isWindows ? "Windows" : "Other")}");

            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine($"Current directory: {currentDir}\n");

            string[] searchPaths = new[]
            {
                Path.Combine(currentDir, "Services", "Greetings.wav"),
                Path.Combine(currentDir, "Greetings.wav"),
                Path.Combine(Directory.GetParent(currentDir)?.Parent?.Parent?.FullName ?? currentDir, "Services", "Greetings.wav")
            };

            Console.WriteLine("Searching for Greetings.wav in:");
            foreach (string path in searchPaths)
            {
                string fullPath = Path.GetFullPath(path);
                Console.WriteLine($"  - {fullPath}");

                if (File.Exists(fullPath))
                {
                    Console.WriteLine("\n✅ Found audio file!");
                    FileInfo fileInfo = new FileInfo(fullPath);
                    Console.WriteLine($"   Full path: {fileInfo.FullName}");
                    Console.WriteLine($"   File size: {fileInfo.Length / 1024} KB");

                    if (isWindows)
                    {
                        Console.WriteLine("\n🔊 Playing audio file...");
                        try
                        {
                            // Use dynamic loading to avoid platform warnings
                            var soundPlayerType = Type.GetType("System.Media.SoundPlayer, System.Windows.Extensions");
                            if (soundPlayerType != null)
                            {
                                dynamic player = Activator.CreateInstance(soundPlayerType, fullPath);
                                player.PlaySync();
                                Console.WriteLine("✅ Audio played successfully!");
                            }
                            else
                            {
                                Console.WriteLine("⚠️ SoundPlayer not available on this platform");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"❌ Error playing audio: {ex.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("⚠️ Audio playback is only supported on Windows platforms");
                        Console.WriteLine("File validation passed but playback skipped.");
                    }
                    return;
                }
            }

            Console.WriteLine("\n❌ Greetings.wav not found!");
            Console.WriteLine("\nPlease ensure:");
            Console.WriteLine("1. The file is named 'Greetings.wav'");
            Console.WriteLine("2. It's placed in the 'Services' folder");
            Console.WriteLine("3. The file is a valid WAV format");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}