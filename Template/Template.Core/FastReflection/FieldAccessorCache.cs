﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Template.Core.FastReflection
{
    public class FieldAccessorCache : FastReflectionCache<FieldInfo, FieldAccessor>
    {
        protected override FieldAccessor Create(FieldInfo key)
        {
            return FastReflectionFactories.FieldAccessorFactory.Create(key);
        }
    }
}
