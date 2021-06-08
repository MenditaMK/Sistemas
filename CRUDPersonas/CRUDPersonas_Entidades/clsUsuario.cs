using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDPersonas_Entidades
{
    public class clsUsuario
    {
        #region Atributos
        private String nick;
        private String email;
        private String nombre;
        private String password;
        private String imagen;
        private String tipo;
        #endregion

        #region Propiedades
        public string Nick { get => nick; set => nick = value; }
        public string Email { get => email; set => email = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Password { get => password; set => password = value; }
        public string Imagen { get => imagen; set => imagen = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        #endregion

        #region Constructores
        public clsUsuario(string nick, string email, string nombre, string password, string imagen, string tipo)
        {
            this.nick = nick;
            this.email = email;
            this.nombre = nombre;
            this.password = password;
            this.imagen = imagen;
            this.tipo = tipo;
        }

        public clsUsuario()
        {
            this.nick = "";
            this.imagen = "";
            this.nombre = "";
            this.password = "";
            this.email = "";
            this.tipo = "";
        }
        #endregion
    }
}
