using System;

namespace nothinbutdotnetstore.web
{
    public class DefaultCommandRegistry : CommandRegistry
    {
        public RequestCommand get_command_that_can_handle(Request request)
        {
            throw new NotImplementedException();
        }
    }
}