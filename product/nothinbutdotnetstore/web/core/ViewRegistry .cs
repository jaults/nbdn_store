namespace nothinbutdotnetstore.web.core
{
    public interface ViewRegistry 
    {
        View<DisplayModel> get_view_that_can_display<DisplayModel>();
    }
}