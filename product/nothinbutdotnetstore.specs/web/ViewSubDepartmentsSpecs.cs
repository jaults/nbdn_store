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
    public class ViewSubDepartmentsInADepartmentSpecs
    {
        public abstract class concern : Observes<ApplicationCommand,
                                            ViewSubDepartmentsInADepartment>
        {
        }

        [Subject(typeof(ViewSubDepartmentsInADepartmentSpecs))]
        public class when_viewing_the_sub_departments_in_a_main_department : concern
        {
            Establish c = () =>
            {
                request = an<Request>();
                response_engine = the_dependency<ResponseEngine>();

                catalog_browsing_tasks = the_dependency<CatalogBrowsingTasks>();
                sub_departments = new List<Department>();
                main_department = new Department();
                request.Stub(x => x.map<Department>()).Return(main_department);
                catalog_browsing_tasks.Stub(x => x.get_the_sub_departments_in(main_department)).Return(sub_departments);
            };

            Because b = () =>
                sut.process(request);

            It should_render_the_list_of_sub_departments = () =>
                response_engine.received(x => x.display(sub_departments));
  

            static Request request;
            static CatalogBrowsingTasks catalog_browsing_tasks;
            static ResponseEngine response_engine;
            static IEnumerable<Department> sub_departments;
            static Department main_department;
        }
    }

    
}