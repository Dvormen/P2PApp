using P2PApp.src.commands;

namespace P2PApp.src
{
    internal class Program
    {
        /// <summary>
        /// Main Application loop
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine("=== P2P Bank Node ===");
            Console.WriteLine("Connected");
            Console.WriteLine();

            while (true)
            {
                string input = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(input))
                    continue;

                if (input.Equals("EXIT", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Shutting down node...");
                    break;
                }

                ICommand command = CommandFactory.Create(input);
                command.Execute();

                Console.WriteLine();
            }
        }
    }
}
