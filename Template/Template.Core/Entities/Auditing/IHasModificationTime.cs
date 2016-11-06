﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Core.Entities.Auditing
{
    /// <summary>
    /// An entity can implement this interface if <see cref="LastModificationTime"/> of this entity must be stored.
    /// <see cref="LastModificationTime"/> is automatically set when updating <see cref="Entity"/>.
    /// </summary>
    public interface IHasModificationTime
    {
        /// <summary>
        /// The last modified time for this entity.
        /// </summary>
        DateTime? LastModificationTime { get; set; }
    }
}
