using DI.App.Abstractions;
using DI.App.Services;
using DI.App.Services.PL;
using DI.App.Services.PL.Commands;

namespace DI.App
{
    internal class Program
    {
        private static void Main()
        {
            // Inversion of Control
            var database = new InMemoryDatabaseService();
            var shop = new UserStore(database);
            var addUsers = new AddUserCommand(shop);
            var listUsers = new ListUsersCommand(shop);
            ICommandProcessor processor = new CommandProcessor(new ICommand[] { addUsers, listUsers });
            var manager = new CommandManager(processor);
            manager.Start();

        }
    }
}
