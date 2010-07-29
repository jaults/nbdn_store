using System.Web;
using nothinbutdotnetstore.infrastructure.categorization;
using nothinbutdotnetstore.model;

namespace nothinbutdotnetstore.web.core.stubs
{
    [Factory]
    public class StubRequestFactory : RequestFactory
    {
        public Request create_request_from(HttpContext http_context)
        {
            var department_name = http_context.Request.QueryString["d"];
            return new StubRequest(department_name) { command = http_context.Request.Url.AbsolutePath };
        }

        class StubRequest : Request
        {
            readonly string department_name;

            public StubRequest(string department_name)
            {
                this.department_name = department_name;
            }

            public InputModel map<InputModel>()
            {
                object department = new Department() {name = department_name};
                return (InputModel) (department);
            }

            public string command { get; set; }
        }
    }

    
}