using System;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewProductsInADepartment : ApplicationCommand
    {
        ResponseEngine response_engine;
        ProductRepository repository;

        public ViewProductsInADepartment(ResponseEngine responseEngine, ProductRepository repository)
        {
            response_engine = responseEngine;
            this.repository = repository;
        }

        public void process(Request request)
        {
            response_engine.display(repository.get_products_for_department(request.map<Department>()));
        }
    }
}