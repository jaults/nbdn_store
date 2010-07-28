using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        private IEnumerable<RequestCommand> commands;

        public DefaultCommandRegistry(IEnumerable<RequestCommand> commands)
        {
            this.commands = commands;
        }

        public RequestCommand get_command_that_can_handle(Request request)
        {
            RequestCommand rc = null;
            try
            {
                rc = commands.First(command => command.can_process(request));
            }
            catch (Exception)
            {
                rc = new MissingRequestCommand();
            }
            return rc;
        }
    }
}