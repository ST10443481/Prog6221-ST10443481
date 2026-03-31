using System;
using System.Threading.Tasks;

namespace CyberSecurityChatBot
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Run test if --test argument is provided
            if (args.Length > 0 && args[0].ToLower() == "--test")
            {
           //     await TestChatbot.RunTest();
                return;
            }

            // Run audio test
            if (args.Length > 0 && args[0].ToLower() == "--test-audio")
            {
               // TestAudio.TestVoiceGreeting();
                return;
            }

            try
            {
                var chatbot = new Chatbot();
                await chatbot.StartAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n❌ An error occurred: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("Please restart the chatbot.");
            }
            finally
            {
                Console.WriteLine("\n🛡️  Thank you for using the Cybersecurity Awareness Assistant!  🛡️");
                Console.WriteLine("Remember: Your online safety is important. Stay vigilant!\n");
            }
        }
    }
}