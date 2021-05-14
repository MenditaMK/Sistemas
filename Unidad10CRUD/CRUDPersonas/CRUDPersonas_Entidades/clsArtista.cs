using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDPersonas_Entidades
{
    public class clsArtista : clsUsuario
    {
        #region Atributos
        private String biografia;
        private String link;
        private String genero;
        #endregion

        #region Propiedades
        public string Biografia { get => biografia; set => biografia = value; }
        public string Link { get => link; set => link = value; }
        public string Genero { get => genero; set => genero = value; }
        #endregion

        #region Constructores
        public clsArtista(string nick, string email, string nombre, string password, string imagen, string tipo, string biografia, string link, string genero)
                        : base(nick, email, nombre, password, imagen, tipo)
        {
            this.biografia = biografia;
            this.link = link;
            this.genero = genero;
        }

        public clsArtista() {
            this.biografia = "Hola me llamo Puto Menda";
            this.link = "https://soundcloud.com/setednb";
            this.genero = "Hardcore";
        }
        #endregion
    }
}
