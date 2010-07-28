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
    public class ViewSubDpartmentsInADepartmentSpecs
    {
        public abstract class concern : Observes<ApplicationCommand,
                                            ViewSubDepartmentsInADepartment>
        {
        }

        [Subject(typeof(ViewSubDpartmentsInADepartmentSpecs))]
        public class when_viewing_the_sub_departments_in_a_main_department : concern
        {
            Establish c = () =>
            {
                request = an<Request>();
                response_engine = the_dependency<ResponseEngine>();

                deparments_repository = the_dependency<DeparmentsRepository>();
                sub_departments = new List<Department>();
                main_department = new Department();
                request.Stub(x => x.map<Department>()).Return(main_department);
                deparments_repository.Stub(x => x.get_the_sub_departments_in(main_department)).Return(sub_departments);
            };

            Because b = () =>
                sut.process(request);

            It should_render_the_list_of_sub_departments = () =>
                response_engine.received(x => x.display(sub_departments));
  

            static Request request;
            static DeparmentsRepository deparments_repository;
            static ResponseEngine response_engine;
            static IEnumerable<Department> sub_departments;
            static Department main_department;
        }
    }

    
}