using System;

namespace nothinbutdotnetstore.web
{
    public class MissingRequestCommand : RequestCommand
    {
        public void process(Request request)
        {
            throw new NotImplementedException();
        }

        public bool can_process(Request request)
        {
            throw new NotImplementedException();
        }
    }
}