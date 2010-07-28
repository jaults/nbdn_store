namespace nothinbutdotnetstore.web.core
{
    public interface ResponseEngine
    {
        void display<DisplayModel>(DisplayModel model);
    }
}