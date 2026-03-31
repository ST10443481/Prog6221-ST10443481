using System;
using System.Threading.Tasks;
using CyberSecurityChatBot.Services;

namespace CyberSecurityChatBot
{
    public static class TestAudioOnly
    {
        public static async Task RunAudioTest()
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("    AUDIO PLAYBACK TEST");
            Console.WriteLine("==========================================\n");

            var audioService = new AudioService();

            // Display audio file info
            Console.WriteLine(audioService.GetAudioFileInfo());
            Console.WriteLine();

            // Test if audio file is valid
            if (audioService.IsAudioFileValid())
            {
                Console.WriteLine("✅ Audio file is valid and found!");
                Console.WriteLine("\nPlaying voice greeting in 2 seconds...");
                await Task.Delay(2000);

                // Play the actual audio
                await audioService.PlayVoiceGreetingAsync();
            }
            else
            {
                Console.WriteLine("❌ Audio file not found!");
                Console.WriteLine("\nPlease ensure:");
                Console.WriteLine("1. The file is named 'Greeting.wav' (not 'Greetings.wav')");
                Console.WriteLine("2. It's located in the Services folder");
                Console.WriteLine("3. The file is a valid WAV format (PCM, 16-bit)");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}