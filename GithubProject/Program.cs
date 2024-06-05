using GithubProject.Class;
using GithubProject.Commands;
using GithubProject.Interfaces;
using GithubProject.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        Repository repository = new Repository();

        Console.WriteLine("Welcome to Git. Type 'git help' for a list of commands");
        string conditional = "";

        while (conditional != "exit")
        {
            Console.Write("> ");
            string[] commands = Console.ReadLine().Split(' ');

            if (commands.Length < 2 || !commands[0].Equals("git", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("Error: Command must start with 'git'. Type 'git help' for a list of commands.");
                continue;
            }

            ICommand? command = null;
            string mainCommand = commands[1].ToLower();

            switch (mainCommand)
            {
                case "add":
                    if (commands.Length > 2)
                    {
                        command = new AddCommand(repository, commands[2]);
                    }
                    else
                    {
                        Console.WriteLine("Error: 'git add' requires a file name.");
                    }
                    break;
                case "commit":
                    if (commands.Length > 2)
                    {
                        command = new CommitCommand(repository, string.Join(" ", commands.Skip(2)));
                    }
                    else
                    {
                        Console.WriteLine("Error: 'git commit' requires a commit message.");
                    }
                    break;
                case "push":
                    command = new PushCommand(repository);
                    break;
                case "log":
                    command = new LogCommand(repository);
                    break;
                case "status":
                    command = new StatusCommand(repository);
                    break;                
                case "revert":
                    command = new RevertCommand(repository);
                    break;
                case "help":
                    command = new HelpCommand(repository);
                    break;
                case "exit":
                    conditional = "exit";
                    break;
                default:
                    Console.WriteLine("Error: Unknown command. Type 'git help' for a list of commands.");
                    break;
            };

            command?.Execute();
        }

        Console.WriteLine("Exiting the application...");
    }
}