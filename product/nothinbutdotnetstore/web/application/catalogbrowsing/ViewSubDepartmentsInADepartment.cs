using nothinbutdotnetstore.model;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewSubDepartmentsInADepartment : ApplicationCommand
    {
        DeparmentsRepository deparments_repository;
        ResponseEngine response_engine;

        public ViewSubDepartmentsInADepartment()
            : this(new StubDepartmentRepository(), new StubResponseEngine())
        {
        }

        public ViewSubDepartmentsInADepartment(DeparmentsRepository deparmentsRepository, ResponseEngine response_engine)
        {
            this.deparments_repository = deparmentsRepository;
            this.response_engine = response_engine;

        }

        public void process(Request request)
        {
            Department department = request.get_main_department();
            response_engine.display(deparments_repository.get_the_sub_departments(department));
        }
    }
}