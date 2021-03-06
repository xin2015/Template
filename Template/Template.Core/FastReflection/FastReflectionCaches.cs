﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Template.Core.FastReflection
{
    public static class FastReflectionCaches
    {
        static FastReflectionCaches()
        {
            MethodInvokerCache = new MethodInvokerCache();
            PropertyAccessorCache = new PropertyAccessorCache();
            FieldAccessorCache = new FieldAccessorCache();
            ConstructorInvokerCache = new ConstructorInvokerCache();
        }

        public static IFastReflectionCache<MethodInfo, MethodInvoker> MethodInvokerCache { get; set; }

        public static IFastReflectionCache<PropertyInfo, PropertyAccessor> PropertyAccessorCache { get; set; }

        public static IFastReflectionCache<FieldInfo, FieldAccessor> FieldAccessorCache { get; set; }

        public static IFastReflectionCache<ConstructorInfo, ConstructorInvoker> ConstructorInvokerCache { get; set; }
    }
}
