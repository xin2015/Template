﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Core.FastReflection
{
    public abstract class FastReflectionCache<TKey, TValue> : IFastReflectionCache<TKey, TValue>
    {
        private Dictionary<TKey, TValue> m_cache = new Dictionary<TKey, TValue>();

        public TValue Get(TKey key)
        {
            TValue value = default(TValue);
            if (this.m_cache.TryGetValue(key, out value))
            {
                return value;
            }

            lock (key)
            {
                if (!this.m_cache.TryGetValue(key, out value))
                {
                    value = this.Create(key);
                    this.m_cache[key] = value;
                }
            }

            return value;
        }

        protected abstract TValue Create(TKey key);
    }
}
