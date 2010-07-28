using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class FrontControllerSpecs
    {
        public abstract class concern : Observes<FrontController,
                                            DefaultFrontController>
        {
        }

        [Subject(typeof(DefaultFrontController))]
        public class when_processing_a_request : concern
        {
            Establish c = () =>
            {
                command_registry = the_dependency<CommandRegistry>();
                request = an<Request>();
                command = an<RequestCommand>();

                command_registry.Stub(x => x.get_command_that_can_handle(request)).Return(command);

            };

            Because b = () =>
                sut.process(request);

            It should_delegate_processing_to_the_command_for_the_request = () =>
                command.received(x => x.process(request));

            static RequestCommand command;
            static Request request;
            static CommandRegistry command_registry;
        }
    }
}