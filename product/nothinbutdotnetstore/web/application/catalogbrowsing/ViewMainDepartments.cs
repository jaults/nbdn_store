using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stub;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewMainDepartments : ApplicationCommand
    {
        DeparmentsRepository deparments_repository;
        ResponseEngine response_engine;

        public ViewMainDepartments():this(new StubDepartmentRepository(),
            new StubResponseEngine())
        {
        }

        public ViewMainDepartments(DeparmentsRepository deparmentsRepository, ResponseEngine response_engine)
        {
            this.deparments_repository = deparmentsRepository;
            this.response_engine = response_engine;
        }

        public void process(Request request)
        {
            response_engine.display(deparments_repository.get_the_main_departments());
        }
    }
}