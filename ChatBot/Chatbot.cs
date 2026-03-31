using System;
using System.Collections.Generic;
using System.Threading;

namespace ChatBotNamespace
{
    public class Chatbot
    {
       
        private Dictionary<string, string> responses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public Chatbot()
        {
            // cybersecurity topics
            responses.Add("Phishing", "Be careful of emails asking for personal info. Always verify the sender.");
            responses.Add("Password", "Use long and unique passwords. Avoid using the same password for multiple accounts.");
            responses.Add("Safe Browsing", "Check URLs carefully and do not click suspicious links. Look for HTTPS and trusted sites.");
            responses.Add("Social Engineering", "Never give personal info to strangers or over the phone/email unless verified.");
            responses.Add("Purpose", "I am here to help you learn about cybersecurity and how to stay safe online.");
            responses.Add("How are you?", "I'm a bot, but I am ready to help you stay safe online!");
        }

        public void ShowHelp()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n--- Available Topics ---");
            foreach (var key in responses.Keys)
            {
                Console.WriteLine($"- {key}");
            }
            Console.WriteLine("- Help (shows this list)\n");
            Console.ResetColor();
        }

        public void Respond(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Please type something! Type 'Help' to see topics.");
                Console.ResetColor();
                return;
            }

            if (userInput.Equals("Help", StringComparison.OrdinalIgnoreCase))
            {
                ShowHelp();
                return;
            }

            if (responses.ContainsKey(userInput))
            {
                SimulateTyping(responses[userInput]);
            }
            else
            {
                SimulateTyping("I didn't quite understand that. Type 'Help' to see available topics.");
            }
        }

        // Optional: Typing effect for bot responses
        private void SimulateTyping(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(20); 
            }
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}