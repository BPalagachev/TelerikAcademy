namespace FreeContentCatalog
{
    using System;
    using System.Linq;

    public class Command : ICommand
    {
        private readonly char[] paramsSeparators = { ';' };
        private readonly char commandEnd = ':';
        private int commandNameEndIndex;

        public Command(string input)
        {
            this.OriginalForm = input.Trim();
            this.Parse();
        }

        public CommandType Type { get; set; }

        public string OriginalForm { get; set; }

        public string Name { get; set; }

        public string[] Parameters { get; set; }

        public CommandType ParseCommandType(string commandName)
        {
            CommandType type;

            if (commandName.Contains(':') || commandName.Contains(';'))
            {
                throw new FormatException("command name cannot contain \";\" or \":\"!");
            }

            switch (commandName.Trim())
            {
                case "Add book":
                    type = CommandType.AddBook;
                    break;

                case "Add movie":
                    type = CommandType.AddMovie;
                    break;

                case "Add song":
                    type = CommandType.AddSong;
                    break;

                case "Add application":
                    type = CommandType.AddApplication;
                    break;

                case "Update":
                    type = CommandType.Update;
                    break;

                case "Find":
                    type = CommandType.Find;
                    break;

                default:
                    {
                        if (commandName.ToLower().Contains("book") || commandName.ToLower().Contains("movie")
                            || commandName.ToLower().Contains("song") || commandName.ToLower().Contains("application"))
                        {
                            throw new ArgumentException("Incomplete command passed - possibly \"add\" was ommited: " + commandName);
                        }
                        else if (commandName.ToLower().Contains("find") || commandName.ToLower().Contains("update"))
                        {
                            throw new ArgumentException("Incomplete command passed - possibly \"find\" or \"update\" command: " + commandName);
                        }
                        else
                        {
                            throw new ArgumentException("Invalid command name: " + commandName);
                        }
                    }
            }

            return type;
        }

        public string GetName()
        {
            string name = this.OriginalForm.Substring(0, this.commandNameEndIndex + 1);
            return name;
        }

        public string[] ParseParameters()
        {
            int paramsLength = this.OriginalForm.Length - (this.commandNameEndIndex + 3);

            string paramsOriginalForm = this.OriginalForm.Substring(this.commandNameEndIndex + 3, paramsLength);

            string[] parameters = paramsOriginalForm.Split(this.paramsSeparators, StringSplitOptions.RemoveEmptyEntries);

            // TODO: posible bottle neck
            // for (int i = 0; i < parameters.Length; i++)
            // {
            //     parameters[i] = parameters[i];
            // }
            return parameters;
        }

        public override string ToString()
        {
            string commandAsString = this.Name + " ";

            foreach (string param in this.Parameters)
            {
                commandAsString += param + " ";
            }
            
            return commandAsString;
        }

        private int GetCommandNameEndIndex()
        {
            int endIndex = this.OriginalForm.IndexOf(this.commandEnd) - 1;

            return endIndex;
        }

        private void TrimParams()
        {
            for (int i = 0; i < this.Parameters.Length; i++)
            {
                this.Parameters[i] = this.Parameters[i].Trim();
            }
        }

        private void Parse()
        {
            this.commandNameEndIndex = this.GetCommandNameEndIndex();

            this.Name = this.GetName();
            this.Parameters = this.ParseParameters();
            this.TrimParams();

            this.Type = this.ParseCommandType(this.Name);
        }
    }
}
