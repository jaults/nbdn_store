using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class ViewMainDepartmentsSpecs
    {
        public abstract class concern : Observes<ApplicationCommand,
                                            ViewMainDepartments>
        {
        }

        [Subject(typeof(ViewMainDepartments))]
        public class when_viewing_the_main_departments : concern
        {
            Establish c = () =>
            {
                request = an<Request>();
                response_engine = the_dependency<ResponseEngine>();

                catalog_browsing_tasks = the_dependency<CatalogBrowsingTasks>();
                main_departments = new List<Department>();

                catalog_browsing_tasks.Stub(x => x.get_the_main_departments()).Return(main_departments);
            };

            Because b = () =>
                sut.process(request);

            It should_render_the_list_of_main_departments = () =>
                response_engine.received(x => x.display(main_departments));
  

            static Request request;
            static CatalogBrowsingTasks catalog_browsing_tasks;
            static ResponseEngine response_engine;
            static IEnumerable<Department> main_departments;
        }
    }
}