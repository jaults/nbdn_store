using System;
using nothinbutdotnetstore.model;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewProductsInADepartment : ApplicationCommand
    {
        ResponseEngine response_engine;
        CatalogBrowsingTasks repository;

        public ViewProductsInADepartment() : this(new StubCatalogBrowsingTasks(), new StubResponseEngine())
        {
            
        }

        public ViewProductsInADepartment(CatalogBrowsingTasks repository, ResponseEngine responseEngine)
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