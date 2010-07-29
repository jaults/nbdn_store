using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.tasks.stubs
{
    public class StubCatalogBrowsingTasks : CatalogBrowsingTasks
    {
        public IEnumerable<Department> get_the_main_departments()
        {
            return get_collection_of<Department>(100,
                                                 (number, department) =>
                                                 {
                                                     department.name =
                                                         number.ToString("Department 0");
                                                     department.has_sub_departments = number%2 == 0;
                                                 });
        }

        public IEnumerable<Product> get_products_for_department(Department department)
        {
            return get_collection_of<Product>(10,
                                              (x, product) =>
                                              {
                                                  product.name = x.ToString("Product 0");
                                                  product.description = x.ToString("Product 0 Description");
                                                  product.price = x.ToString("$0");
                                              });
        }

        public IEnumerable<Department> get_the_sub_departments_in(Department department)
        {
            return get_collection_of<Department>(10, (number, item) => item.name = number.ToString("Department 0"));
        }

        public delegate void PostCreationProcessor<ItemToUpdate>(int number, ItemToUpdate item);

        IEnumerable<ReturnType> get_collection_of<ReturnType>(int quantity, PostCreationProcessor<ReturnType> post)
            where ReturnType : new()
        {
            //TODO - Explore more
            return Enumerable.Range(1, quantity).Select(x =>
            {
                var item = new ReturnType();
                post(x, item);
                return item;
            });
        }
    }
}