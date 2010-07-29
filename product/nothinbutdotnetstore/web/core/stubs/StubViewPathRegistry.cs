using System.Collections.Generic;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubViewPathRegistry : ViewPathRegistry
    {
        public string get_path_to_view_that_can_display<DisplayModel>()
        {
            if (typeof(DisplayModel) == typeof(IEnumerable<Department>)) return "~/views/DepartmentBrowser.aspx";
            return "~/views/ProductBrowser.aspx";
        }
    }
}