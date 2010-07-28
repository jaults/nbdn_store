using System;
using System.Collections.Generic;
using System.Web;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubResponseEngine: ResponseEngine
    {
        public void display<DisplayModel>(DisplayModel model)
        {
            HttpContext.Current.Items.Add("blah", model);

            if (typeof(DisplayModel).FullName.Contains("Product"))
                HttpContext.Current.Server.Transfer("~/views/ProductBrowser.aspx", true);

            HttpContext.Current.Server.Transfer("~/views/DepartmentBrowser.aspx", true);
        }
    }
}