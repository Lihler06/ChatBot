using System;
using System.Media;
using System.Threading;

namespace CyberSecurityChatbot
{
    class Chatbot
    {
        public string UserName { get; set; }

        public void Start()
        {
            PlayGreeting();
            ShowHeader();
            GetUserName();
            ShowHelp(); 
            ChatLoop();
        }

        private void PlayGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("greeting.wav");
                player.Play();
            }
            catch
            {
                Console.WriteLine("Audio file not found. Continuing...");
            }
        }

        private void ShowHeader()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(@"
   ____       _               ____                      _ _       
  / ___|  ___| |__   ___ _ __/ ___|  ___  __ _ _ __ ___(_) |_ ___ 
  \___ \ / __| '_ \ / _ \ '__\___ \ / _ \/ _` | '__/ __| | __/ __|
   ___) | (__| | | |  __/ |   ___) |  __/ (_| | | | (__| | |_\__ \
  |____/ \___|_| |_|\___|_|  |____/ \___|\__,_|_|  \___|_|\__|___/

        CYBERSECURITY AWARENESS CHATBOT
================================================================
");

            Console.ResetColor();
        }

        private void GetUserName()
        {
            Console.Write("Enter your name: ");
            string? input = Console.ReadLine();

            UserName = string.IsNullOrWhiteSpace(input)
                ? "Guest"
                : input.Trim();

            Console.ForegroundColor = ConsoleColor.Cyan;
            TypeText($"\nWelcome, {UserName.ToUpper()}! I'm here to help you stay safe online.\n");
            Console.ResetColor();
        }

        // ✅ NEW METHOD (Help Menu)
        private void ShowHelp()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine("\nYou can ask me about:");
            Console.WriteLine("- password");
            Console.WriteLine("- phishing");
            Console.WriteLine("- malware");
            Console.WriteLine("- scams");
            Console.WriteLine("- safe browsing");
            Console.WriteLine("\nType 'help' to see this again.");

            Console.ResetColor();
        }

        private void ChatLoop()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nAsk me something (type 'exit' to quit): ");
                Console.ResetColor();

                string? rawInput = Console.ReadLine();
                string input = rawInput?.ToLower().Trim() ?? "";

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please enter something.");
                    continue;
                }

                switch (input)
                {
                    case "how are you":
                        TypeText($"I'm doing great, {UserName}!");
                        break;

                    case "purpose":
                    case "what is your purpose":
                        TypeText("I help educate people about cybersecurity and staying safe online.");
                        break;

                    case "password":
                        TypeText("Use strong passwords with uppercase, lowercase, numbers, and symbols.");
                        break;

                    case "phishing":
                        TypeText("Be careful of emails asking for personal info. Always verify the sender.");
                        break;

                    case "safe browsing":
                        TypeText("Always check for HTTPS and avoid suspicious websites.");
                        break;

                    case "malware":
                        TypeText("Malware is harmful software. Avoid downloading from unknown sources.");
                        break;

                    case "scams":
                        TypeText("Scammers try to trick you. Never share personal or banking details.");
                        break;

                    case "help":
                        ShowHelp(); // 👈 Now reuses the method
                        break;

                    case "exit":
                        Console.ForegroundColor = ConsoleColor.Red;
                        TypeText($"Goodbye, {UserName}! Stay safe online.");
                        Console.ResetColor();
                        return;

                    default:
                        Console.WriteLine("I didn't understand that. Try typing 'help'.");
                        break;
                }
            }
        }

        private void TypeText(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(20);
            }
            Console.WriteLine();
        }
    }
}