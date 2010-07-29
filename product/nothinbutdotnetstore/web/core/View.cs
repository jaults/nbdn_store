using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public interface View<DisplayModel> : IHttpHandler
    {
        DisplayModel display_model { get; set; }
    }
}