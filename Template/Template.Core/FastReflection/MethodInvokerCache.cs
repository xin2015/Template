using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Template.Core.FastReflection
{
    public class MethodInvokerCache : FastReflectionCache<MethodInfo, MethodInvoker>
    {
        protected override MethodInvoker Create(MethodInfo key)
        {
            return FastReflectionFactories.MethodInvokerFactory.Create(key);
        }
    }
}
