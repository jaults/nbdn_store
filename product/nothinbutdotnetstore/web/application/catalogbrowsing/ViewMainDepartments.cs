using System;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewMainDepartments: ApplicationCommand
    {
        private IDeparmentsRepository deparmentsRepository;

        public ViewMainDepartments(IDeparmentsRepository deparmentsRepository)
        {
            this.deparmentsRepository = deparmentsRepository;
        }

        public void process(Request request)
        {
            deparmentsRepository.GetAllDeparments();
        }
    }
}