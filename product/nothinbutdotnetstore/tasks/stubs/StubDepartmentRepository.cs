using System;
using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.tasks.stubs
{
    public class StubDepartmentRepository: DeparmentsRepository
    {
        public IEnumerable<Department> get_the_main_departments()
        {
            return Enumerable.Range(1, 100).Select(x => new Department {name = x.ToString("Department 0")});
        }

        public IEnumerable<Department> get_the_sub_departments_in(Department department)
        {
            return Enumerable.Range(1, 10).Select(x => new Department { name = x.ToString("Sub Department 0") });
        }
    }
}