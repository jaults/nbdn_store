using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewMainDepartments : ApplicationCommand
    {
        CatalogBrowsingTasks catalog_browsing_tasks;
        ResponseEngine response_engine;

        public ViewMainDepartments():this(new StubDepartmentRepository(),
            new StubResponseEngine())
        {
        }

        public ViewMainDepartments(CatalogBrowsingTasks catalog_browsing_tasks, ResponseEngine response_engine)
        {
            this.catalog_browsing_tasks = catalog_browsing_tasks;
            this.response_engine = response_engine;
        }

        public void process(Request request)
        {
            response_engine.display(catalog_browsing_tasks.get_the_main_departments());
        }
    }
}