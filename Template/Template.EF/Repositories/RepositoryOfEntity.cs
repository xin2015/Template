using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Core.Entities;

namespace Template.EF.Repositories
{
    public class Repository<TEntity> : Repository<TEntity, int> where TEntity : Entity
    {
    }
}
