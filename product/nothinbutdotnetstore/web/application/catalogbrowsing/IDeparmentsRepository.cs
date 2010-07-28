using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public interface IDeparmentsRepository
    {
        IEnumerable<Department> GetAllDeparments();
    }
}
