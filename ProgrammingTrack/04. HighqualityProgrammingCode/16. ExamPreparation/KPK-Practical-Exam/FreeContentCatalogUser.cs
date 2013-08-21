namespace FreeContentCatalog
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class FreeContentCatalogUser
    {
        public static void Main()
        {
            StringBuilder output = new StringBuilder();
            Catalog catalog = new Catalog();
            ICommandExecutor commandExecutor = new CommandExecutor();

            List<ICommand> commands = Parse();

            foreach (ICommand item in commands)
            {
                commandExecutor.ExecuteCommand(catalog, item, output);
            }

            Console.Write(output);
        }

        private static List<ICommand> Parse()
        {
            List<ICommand> allCommands = new List<ICommand>();
            bool end = false;

            do
            {
                string currentCommand = Console.ReadLine();
                end = (currentCommand.Trim() == "End");
                if (!end)
                {
                    allCommands.Add(new Command(currentCommand));
                }
            }
            while (!end);

            return allCommands;
        }
    }
}
