using System.Web;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.specs.utility;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class ResponseEngineSpecs
    {
        public abstract class concern : Observes<ResponseEngine,
                                            DefaultResponseEngine>
        {
        }

        [Subject(typeof(DefaultResponseEngine))]
        public class when_displaying_a_model : concern
        {
            Establish c = () =>
            {
                some_model = new object();
                the_view = an<View<object>>();
                view_registry = the_dependency<ViewRegistry>();
                current_context = ObjectMother.create_http_context();
                view_registry.Stub(x => x.get_view_that_can_display<object>()).Return(the_view);

                CurrentContextResolver resolver = () => current_context;

                change(() => DefaultResponseEngine.active_context_resolver).to(resolver);
            };

            Because b = () =>
                sut.display(some_model);

            It should_update_the_model_property_on_the_view = () =>
                the_view.display_model.ShouldEqual(some_model);


            It should_tell_the_view_that_can_display_the_model_to_render = () =>
                the_view.received(x => x.ProcessRequest(current_context)); 
  

            static object some_model;
            static ViewRegistry view_registry;
            static View<object> the_view;
            static HttpContext current_context;
        }
    }
}