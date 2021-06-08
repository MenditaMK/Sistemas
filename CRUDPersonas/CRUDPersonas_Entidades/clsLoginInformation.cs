using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDPersonas_Entidades
{
    public class clsLoginInformation
    {
        #region Atributos
        private String nickEmail;
        private String password;
        #endregion

        #region Propiedades
        public string NickEmail { get => nickEmail; set => nickEmail = value; }
        public string Password { get => password; set => password = value; }
        #endregion

        #region Constructores
        public clsLoginInformation(string nickEmail, string password)
        {
            this.nickEmail = nickEmail;
            this.password = password;
        }
        #endregion
    }
}
