namespace nothinbutdotnetstore.web.core
{
    public interface ViewPathRegistry
    {
        string get_path_to_view_that_can_display<DisplayModel>();
    }
}