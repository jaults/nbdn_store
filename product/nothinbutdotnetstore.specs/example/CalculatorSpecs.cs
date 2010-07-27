using System.Data;
using System.Security;
using System.Security.Principal;
using System.Threading;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.example
{
    public class CalculatorSpecs
    {
        public abstract class concern : Observes<Calculator,DefaultCalculator>
        {
        }

        public class when_shutting_off_the_calculator_and_they_are__in_the_correct_role : concern
        {

            Establish c = () =>
            {
                fake_principal = an<IPrincipal>();
                fake_principal.Stub(x => x.IsInRole(Arg<string>.Is.Anything)).Return(true);
            
                change(() => Thread.CurrentPrincipal).to(fake_principal);
            };

            Because b = () =>
                sut.shut_off();


            It should_not_throw_a_security_exception = () =>
            {
            };

            static IPrincipal fake_principal;
        }
        public class when_shutting_off_the_calculator_and_they_are_not_in_the_correct_role : concern
        {

            Establish c = () =>
            {
                fake_principal = an<IPrincipal>();
                fake_principal.Stub(x => x.IsInRole(Arg<string>.Is.Anything)).Return(false);
            
                change(() => Thread.CurrentPrincipal).to(fake_principal);
            };

            Because b = () =>
                catch_exception(() => sut.shut_off());


            It should_throw_a_security_exception = () =>
            {
                exception_thrown_by_the_sut.ShouldBeAn<SecurityException>();
            };

            static IPrincipal fake_principal;
        }
        public class when_adding_two_numbers : concern
        {
            Establish c = () =>
            {
                connection = the_dependency<IDbConnection>();
//                provide_a_basic_sut_constructor_argument()
//                    create_sut_using()
                command = an<IDbCommand>();


                connection.Stub(x => x.CreateCommand()).Return(command);
            };

            Because b = () =>
                result = sut.add(2, 2);

            It should_return_the_sum_of_the_numbers = () =>
                result.ShouldEqual(4);

            It should_open_a_connection_to_the_database = () =>
                connection.received(x => x.Open());

            It should_run_a_command = () =>
                command.received(x => x.ExecuteNonQuery());

  

            static int result;
            static IDbConnection connection;
            static IDbCommand command;
        }
    }
}