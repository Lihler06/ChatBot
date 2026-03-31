using ChatBotNamespace;
using System;
using System.Media; 

namespace CyberSecurityChatbotApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // --- ASCII Logo / Header ---
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
  ____      _      ____                 _            _   _             
 / ___| ___| | ___/ ___|_ __ __ _ _ __ | |_ ___  ___| |_(_) ___  _ __  
| |    / _ \ |/ _ \___ \ '__/ _` | '_ \| __/ _ \/ __| __| |/ _ \| '_ \ 
| |___|  __/ |  __/___) | | | (_| | | | | ||  __/ (__| |_| | (_) | | | |
 \____|\___|_|\___|____/|_|  \__,_|_| |_|\__\___|\___|\__|_|\___/|_| |_|
");
            Console.ResetColor();

            // --- Audio Greeting ---
            try
            {
                SoundPlayer player = new SoundPlayer("greeting.wav"); 
                player.Play();
            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Audio greeting not found. Continuing without sound...");
                Console.ResetColor();
            }

            // Ask for User Name 
            Console.Write("Enter your name: ");
            string? rawName = Console.ReadLine();
            string name = string.IsNullOrWhiteSpace(rawName) ? "User" : rawName.Trim();
            name = name.ToUpper();

            Console.WriteLine($"\nWelcome, {name}! I am Cybersecurity Awareness Bot. I'm here to help you stay safe online.\n");
            Console.WriteLine("Type 'Help' to see a list of topics you can ask about.\n");

            //Start Chatbot
            Chatbot bot = new Chatbot();

            while (true)
            {
                Console.Write("\nAsk me something (type 'exit' to quit): ");
                string userInput = Console.ReadLine();

                if (userInput.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\nThanks for chatting! Stay safe online!");
                    Console.ResetColor();
                    break;
                }

                bot.Respond(userInput);
            }
        }
    }
}