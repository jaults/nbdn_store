using System;
using System.Collections.Generic;
using System.Text;

namespace nothinbutdotnetstore.web.core
{
    public class LinkBuilder<T>
    {
        Dictionary<Func<T, bool>, string> conditions;

        public LinkBuilder()
        {
            conditions = new Dictionary<Func<T, bool>, string>();
        }

        public LinkBuilder<T> when(Func<T, bool> criteria, string commandTypeName)
        {
            conditions.Add(criteria, commandTypeName);
            return this;
        }

        public string render(T instance)
        {
            var builder = new StringBuilder();
            builder.Append("/dept.store/");

            foreach (var condition in conditions)
            {
                if (condition.Key(instance))
                {
                    builder.Append(condition.Value);
                }
            }

            return builder.ToString();
        }
    }
}