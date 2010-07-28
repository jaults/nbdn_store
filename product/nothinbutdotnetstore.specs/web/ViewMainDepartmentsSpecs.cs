using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
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
        public class when_processing_a_viewdepartments_command : concern
        {
            Establish c = () =>
            {
                request = an<Request>();
   
                deparments_repository = the_dependency<IDeparmentsRepository>();
                deparments_repository.Stub(x => x.GetAllDeparments()).Return(new  List<Department>() );


                
            }; 
            
            Because b = () =>
                sut.process(request);
            
            
            private It call_method_which_returns_all_deparments = () =>
                                                            deparments_repository.received(x => x.GetAllDeparments());

            private static ViewMainDepartments application_command;
            private static Request request;
            private static IDeparmentsRepository deparments_repository;

        }
    }
}