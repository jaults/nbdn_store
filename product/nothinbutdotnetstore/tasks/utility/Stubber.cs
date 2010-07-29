using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace nothinbutdotnetstore.tasks.utility
{
    public class Stubber<TStub> where TStub : class, new()
    {
        public static IEnumerable<TStub> MakeEnumerable<TProperty>(int rangeStart, int rangeEnd, 
            Func<TStub, TProperty> property_accessor)
        {
                return Enumerable.Range(rangeStart, rangeEnd)
                    .Select(x => new TStub());
        }
    }
}