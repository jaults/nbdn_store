using System;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.core;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class ViewRegistrySpecs
    {
        public abstract class concern : Observes<ViewRegistry,
                                            DefaultViewRegistry>
        {
        }

        [Subject(typeof(DefaultViewRegistry))]
        public class when_getting_a_view_for_a_display_model : concern
        {
            Establish c = () =>
            {
                view_path_registry = the_dependency<ViewPathRegistry>();
                view_path_registry.Stub(x => x.get_path_to_view_that_can_display<int>()).Return("blah.aspx");

                view_factory = (path, type_requested) =>
                {
                    path_requested = path;
                    type = type_requested;
                    return an<View<int>>();
                };

                change(() => DefaultViewRegistry.view_factory).to(view_factory);
            };

            Because b = () =>
                result = sut.get_view_that_can_display<int>();

            It should_return_an_http_handler_that_can_be_used_to_render_the_model = () =>
            {
                path_requested.ShouldEqual("blah.aspx");
                type.ShouldEqual(typeof(View<int>));
                result.ShouldBeAn<View<int>>();
            };

            static View<int> result;
            static ViewPathRegistry view_path_registry;
            static ViewFactory view_factory;
            static string path_requested;
            static Type type;
        }
    }
}