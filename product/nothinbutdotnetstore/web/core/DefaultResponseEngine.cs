using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultResponseEngine : ResponseEngine
    {
        //        public static readonly CurrentContextResolver active_resolver = delegate
        //        {
        //            throw new Exception(
        //                "This needs to be configured at application startup");
        //        };

        public static readonly CurrentContextResolver active_context_resolver = () => HttpContext.Current;

        ViewRegistry view_registry;

        public DefaultResponseEngine() : this(new DefaultViewRegistry())
        {
        }

        public DefaultResponseEngine(ViewRegistry view_registry)
        {
            this.view_registry = view_registry;
        }

        public void display<DisplayModel>(DisplayModel model)
        {
            var view = view_registry.get_view_that_can_display<DisplayModel>();
            view.display_model = model;
            view.ProcessRequest(active_context_resolver());
        }
    }
}