using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        IEnumerable<RequestCommand> commands;

        public DefaultCommandRegistry(IEnumerable<RequestCommand> commands)
        {
            this.commands = commands;
        }

        public DefaultCommandRegistry() : this(new StubSetOfCommands())
        {
        }

        public RequestCommand get_command_that_can_handle(Request request)
        {
            return commands.FirstOrDefault(command => command.can_process(request))
                ?? new MissingRequestCommand();
        }
    }
}