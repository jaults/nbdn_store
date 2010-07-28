using System.Collections.Generic;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.tasks
{
    public interface DeparmentsRepository
    {
        IEnumerable<Department> get_the_main_departments();
    }
}