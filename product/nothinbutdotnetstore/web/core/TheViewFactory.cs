using System;
using System.Web.Compilation;

namespace nothinbutdotnetstore.web.core
{
    public interface TheViewFactory
    {
        object create_from(string path, Type type);
    }

    class TheViewFactoryImpl : TheViewFactory
    {
        public object create_from(string path, Type type)
        {
            //THERE BE DRAGONS
            return BuildManager.CreateInstanceFromVirtualPath(path, typeof(int));
        }
    }
}