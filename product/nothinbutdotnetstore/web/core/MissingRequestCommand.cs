using System;

namespace nothinbutdotnetstore.web.core
{
    public class MissingRequestCommand : RequestCommand
    {
        public void process(Request request)
        {
            throw new NotImplementedException();
        }

        public bool can_process(Request request)
        {
            return false;
        }
    }
}