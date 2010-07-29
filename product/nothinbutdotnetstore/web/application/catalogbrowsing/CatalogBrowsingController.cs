using System.Collections.Generic;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.tasks;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class CatalogBrowsingController
    {
        CatalogBrowsingTasks catalog_browsing_tasks;

        public CatalogBrowsingController(CatalogBrowsingTasks catalog_browsing_tasks)
        {
            this.catalog_browsing_tasks = catalog_browsing_tasks;
        }

        public IEnumerable<Department> get_the_main_departments()
        {
            return catalog_browsing_tasks.get_the_main_departments();
        }

        public IEnumerable<Department> get_the_sub_departments_in(Department department)
        {
            return catalog_browsing_tasks.get_the_sub_departments_in(department);
        }

        public IEnumerable<Product> get_products_for_department(Department department)
        {
            return catalog_browsing_tasks.get_products_for_department(department);
        }
    }
}