using Software_Evolution.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Software_Evolution.repositorios
{
    public abstract class Repository
    {
        protected readonly QueryManager manager = QueryManager.Instance;
        public Repository() { }
    }
}
