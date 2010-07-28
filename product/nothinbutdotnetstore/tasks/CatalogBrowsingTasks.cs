using System.Collections.Generic;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.tasks
{
    public interface CatalogBrowsingTasks
    {
        IEnumerable<Department> get_the_main_departments();
        IEnumerable<Department> get_the_sub_departments_in(Department department);
        IEnumerable<Product> get_products_for_department(Department department);
    }
}