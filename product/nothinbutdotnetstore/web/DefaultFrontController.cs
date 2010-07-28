using System;

namespace nothinbutdotnetstore.web
{
    public class DefaultFrontController : FrontController
    {
        private CommandRegistry commandRegistry;

        public DefaultFrontController(CommandRegistry commandRegistry)
        {
            this.commandRegistry = commandRegistry;
        }

        public void process(Request request)
        {
           var commandProcessor = commandRegistry.get_command_that_can_handle(request);
           commandProcessor.process(request);
        }
    }
}