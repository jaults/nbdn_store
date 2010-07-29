using System;
using System.Web.Compilation;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultViewRegistry : ViewRegistry
    {
//        public static readonly ViewFactory view_factory =
//            delegate { throw new NotImplementedException("This needs to be configured at app startup"); };


        public static readonly ViewFactory view_factory = BuildManager.CreateInstanceFromVirtualPath;

        ViewPathRegistry view_path_registry;

        public DefaultViewRegistry():this(new StubViewPathRegistry())
        {
        }

        public DefaultViewRegistry(ViewPathRegistry view_path_registry)
        {
            this.view_path_registry = view_path_registry;
        }

        public View<DisplayModel> get_view_that_can_display<DisplayModel>()
        {
            return (View<DisplayModel>)view_factory(view_path_registry.get_path_to_view_that_can_display<DisplayModel>(), typeof(View<DisplayModel>));
        }
    }
}