using System;
using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.tasks.stubs
{
    public class StubCatalogBrowsingTasks: CatalogBrowsingTasks
    {
        public IEnumerable<Department> get_the_main_departments()
        {
            return get_collection_of(100,
                                     x =>
                                     new Department {name = x.ToString("Department 0"), has_sub_departments = x%2 == 0});
       
        }

        public IEnumerable<Product> get_products_for_department(Department department)
        {
            return get_collection_of(10,
                                     x =>
                                     new Product()
                                         {
                                             name = x.ToString("Product 0"),
                                             description = x.ToString("Product 0 Description"),
                                             price = x.ToString("$0")
                                         });
            
        }

        public IEnumerable<Department> get_the_sub_departments_in(Department department)
        {
            return get_collection_of(10, x => new Department {name = x.ToString("Sub Department 0")});
           
        }


        private IEnumerable<ReturnType> get_collection_of<ReturnType>(int quantity, Func<ReturnType> creator)
        {
            return Enumerable.Range(1, quantity).Select(creator);
        }

    }
}