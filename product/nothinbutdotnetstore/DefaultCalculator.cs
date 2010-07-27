using System;
using System.Data;
using System.Security;
using System.Threading;

namespace nothinbutdotnetstore
{
    public interface Calculator
    {
        int add(int first, int second);
        void shut_off();
    }

    public class DefaultCalculator : Calculator
    {
        IDbConnection connection;

        public DefaultCalculator(IDbConnection connection,IDbDataParameter parameter)
        {
            this.connection = connection;
        }

        public int add(int first, int second)
        {
            using (connection)
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            return first + second;
        }

        public void shut_off()
        {
            ensure_security_role();
        }

        void ensure_security_role()
        {
            if (Thread.CurrentPrincipal.IsInRole("blah")) return;
            throw new SecurityException();
        }
    }
}