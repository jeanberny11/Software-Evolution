using Software_Evolution.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Software_Evolution.managers.general;
using System.Data;

namespace Software_Evolution
{
    public sealed class AppData
    {
        private static readonly AppData _instance = new AppData();
        PreferenciasManager preferenciasManager = new PreferenciasManager();
        private Usuario _currentuser;
        private AppData()
        {

        }

        public static AppData Instance => _instance;
       

        public Usuario Currentuser { get => _currentuser; set => _currentuser = value; }

        public DataRow Preferencias => preferenciasManager.GetPreferencias();
    }
}
