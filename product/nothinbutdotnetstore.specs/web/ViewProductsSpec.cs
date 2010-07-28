using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class ViewProductsIADepartmentSpec
    {
        public abstract class concern : Observes<ApplicationCommand,
                                            ViewProductsInADepartment>
        {
        }

        [Subject(typeof(ViewSubDpartmentsInADepartmentSpecs))]
        public class when_viewing_the_products_in_a_department : concern
        {
            Establish c = () =>
            {
                request = an<Request>();
                response_engine = the_dependency<ResponseEngine>();
                products_repository = the_dependency<ProductRepository>();

                products = new List<Product>();
                Department department = new Department();

                products_repository.Stub(x => x.get_products_for_department(department)).Return((products));
                request.Stub(x => x.map<Department>()).Return(department);
            };

            Because b = () =>
                        sut.process(request);

            It should_render_a_list_of_products_in_a_department = () =>
                response_engine.received(x => x.display(products));

            static ResponseEngine response_engine;
            static Request request;
            static ProductRepository products_repository;
            static IEnumerable<Product> products;
        }
    }
}
