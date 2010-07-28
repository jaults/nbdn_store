using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubSetOfCommands : IEnumerable<RequestCommand>
    {
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<RequestCommand> GetEnumerator()
        {
            yield return new DefaultRequestCommand(x => x.command.Contains("ViewSubDepartments"), new ViewSubDepartmentsInADepartment());
            yield return new DefaultRequestCommand(x => x.command.Contains("ViewProducts"), new ViewProductsInADepartment());
            yield return new DefaultRequestCommand(x => true, new ViewMainDepartments());
        }
    }
}