using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learning.DesignPatterns.CommandPattern.Commands;

namespace Learning.DesignPatterns.CommandPattern
{
    class CommandParser
    {
        private IEnumerable<ICommandFactory> _AvailableCommands;

        public CommandParser(IEnumerable<ICommandFactory> availableCommands)
        {
            this._AvailableCommands = availableCommands;
        }

        internal ICommand ParseCommand(string[] args)
        {
            var requestedCommandName = args[0];

            var command = FindRequestedCommand(requestedCommandName);
            if (null == command)
                return new NotFoundCommand { Name = requestedCommandName };

            return command.MakeCommand(args);
        }
        ICommandFactory FindRequestedCommand(string commandName)
        {
            return _AvailableCommands
                .FirstOrDefault(cmd => cmd.CommandName == commandName);
        }
    }
}
