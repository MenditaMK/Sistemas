using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDPersonas_Entidades
{
    public class clsEmailPassword
    {
        #region Atributos
        private String password;
        private String email;
        #endregion

        #region Propiedades
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        #endregion

        #region Constructores
        public clsEmailPassword(String email, string password)
        {
            this.password = password;
            this.email = email;
        }
        #endregion

        
    }
}