namespace FreeContentCatalog
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CommandExecutor : ICommandExecutor
    {
        public void ExecuteCommand(ICatalog catalog, ICommand command, StringBuilder sb)
        {
            switch (command.Type)
            {
                case CommandType.AddBook:
                    this.HandleAddBook(command, catalog, sb);
                    break;
                case CommandType.AddMovie:
                    this.HandleAddMovie(command, catalog, sb);
                    break;

                case CommandType.AddSong:
                    this.HandleAddSong(command, catalog, sb);
                    break;
                case CommandType.AddApplication:
                    this.HandleAddApplication(command, catalog, sb);
                    break;
                case CommandType.Update:
                    this.HandleUpdate(command, catalog, sb);
                    break;
                case CommandType.Find:
                    this.HandleFind(command, catalog, sb);
                    break;
                default:
                    throw new InvalidOperationException("Unknown command!");
            }
        }

        private void HandleFind(ICommand command, ICatalog catalog, StringBuilder sb)
        {
            if (command.Parameters.Length != 2)
            {
                throw new ArgumentException("Invalid number of parameters!");
            }

            int numberOfElementsToList = int.Parse(command.Parameters[1]);

            IEnumerable<IContent> foundContent = catalog.GetListContent(command.Parameters[0], numberOfElementsToList);

            if (foundContent.Count() == 0)
            {
                sb.AppendLine("No items found");
            }
            else
            {
                foreach (IContent content in foundContent)
                {
                    sb.AppendLine(content.TextRepresentation);
                }
            }
        }

        private void HandleUpdate(ICommand command, ICatalog catalog, StringBuilder sb)
        {
            if (command.Parameters.Length != 2)
            {
                throw new ArgumentException("Invalid number of params");
            }

            int numberOfItemsUpdates = catalog.UpdateContent(command.Parameters[0], command.Parameters[1]);
            sb.AppendLine(string.Format("{0} items updated!", numberOfItemsUpdates));
        }

        private void HandleAddApplication(ICommand command, ICatalog catalog, StringBuilder sb)
        {
            IContent newApp = new Content(ContentType.Application, command.Parameters);
            catalog.Add(newApp);
            sb.AppendLine("Application added");
        }

        private void HandleAddSong(ICommand command, ICatalog catalog, StringBuilder sb)
        {
            IContent newMusicItem = new Content(ContentType.Music, command.Parameters);
            catalog.Add(newMusicItem);
            sb.Append("Song added");
        }

        private void HandleAddMovie(ICommand command, ICatalog catalog, StringBuilder sb)
        {
            IContent newMovie = new Content(ContentType.Movie, command.Parameters);
            catalog.Add(newMovie);
            sb.AppendLine("Movie added");
        }

        private void HandleAddBook(ICommand command, ICatalog catalog, StringBuilder sb)
        {
            IContent newBook = new Content(ContentType.Book, command.Parameters);
            catalog.Add(newBook);
            sb.AppendLine("Book Added");
        }
    }
}
