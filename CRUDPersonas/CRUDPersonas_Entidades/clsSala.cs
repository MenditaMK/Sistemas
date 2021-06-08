using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDPersonas_Entidades
{
    public class clsSala : clsUsuario
    {
        #region Atributos
        private String provincia;
        private String direccion;
        private String localidad;
        #endregion

        #region Propiedades
        public string Provincia { get => provincia; set => provincia = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Localidad { get => localidad; set => localidad = value; }
        #endregion

        #region Constructores
        public clsSala(string nick, string email, string nombre, string password, string imagen, string tipo, string provincia, string direccion, string localidad)
                        : base(nick, email, nombre, password, imagen, tipo)
        {
            this.provincia = provincia;
            this.direccion = direccion;
            this.localidad = localidad;
        }

        public clsSala()
        {
            this.provincia = "Sevilla";
            this.direccion = "C/Uranio";
            this.localidad = "Sevilla";
        }
        #endregion
    }
}
