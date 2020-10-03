using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Software_Evolution.models
{
    class MasterDetailModel
    {
        public string titulo { get; set; }
        public string id { get; set; }
        public string descripcion { get; set; }
        public bool autoincrement { get; set; }
        public int tipodoc { get; set; }

        public List<ForeinField> foreinfields { get; set; }
    }
}
