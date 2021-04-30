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

            var addUsers = new AddUserCommand(new UserStore(new InMemoryDatabaseService()));
            var listUsers = new ListUsersCommand(new UserStore(new InMemoryDatabaseService()));
            ICommandProcessor processor = new CommandProcessor(new ICommand[] { addUsers, listUsers });
            var manager = new CommandManager(processor);
            manager.Start();

        }
    }
}
