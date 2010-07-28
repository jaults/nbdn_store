namespace nothinbutdotnetstore.web
{
    public interface CommandRegistry
    {
        RequestCommand get_command_that_can_handle(Request request);
    }
}