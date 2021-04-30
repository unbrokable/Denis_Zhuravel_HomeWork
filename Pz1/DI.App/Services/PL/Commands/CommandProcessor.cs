using System.Collections.Generic;
using System.Linq;
using DI.App.Abstractions;
using DI.App.Services.PL.Commands;

namespace DI.App.Services.PL
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly Dictionary<int, ICommand> commands = new Dictionary<int, ICommand>();

        public CommandProcessor(  ICommand[] commands)
        {
          for(int i = 0; i < commands.Length; i++)
            {
                this.commands.Add(commands[i].Number, commands[i]);

            }
        }

        public void Process(int number)
        {
            if (!this.commands.TryGetValue(number, out var command)) return;

            command.Execute();
        }

        public IEnumerable<ICommand> Commands => this.commands.Values.AsEnumerable();
    }
}