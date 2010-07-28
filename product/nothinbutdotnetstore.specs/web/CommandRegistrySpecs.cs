using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Extensions;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class CommandRegistrySpecs
    {
        public abstract class concern : Observes<CommandRegistry,
                                            DefaultCommandRegistry>
        {
            Establish c = () =>
            {
                request = an<Request>();
                all_commands = new List<RequestCommand>();

                Enumerable.Range(1, 100).each(x => all_commands.Add(an<RequestCommand>()));

                provide_a_basic_sut_constructor_argument<IEnumerable<RequestCommand>>(all_commands);
            };

            protected static Request request;
            protected static List<RequestCommand> all_commands;
            protected static RequestCommand result;
        }

        [Subject(typeof(DefaultCommandRegistry))]
        public class when_getting_a_command_for_a_request_and_it_has_the_command : concern
        {
            Establish c = () =>
            {
                command_that_can_handle_the_request = an<RequestCommand>();
                all_commands.Add(command_that_can_handle_the_request);
                command_that_can_handle_the_request.Stub(x => x.can_process(request)).Return(true);
            };

            Because b = () =>
                result = sut.get_command_that_can_handle(request);

            It should_return_the_command_that_can_handle_the_request = () =>
                result.ShouldEqual(command_that_can_handle_the_request);

            static RequestCommand command_that_can_handle_the_request;
        }

        public class when_getting_a_command_for_a_request_and_it_does_not_have_the_command : concern
        {
            Because b = () =>
                result = sut.get_command_that_can_handle(request);

            It should_return_a_missing_command = () =>
                result.ShouldBeAn<MissingRequestCommand>();
        }
    }
}