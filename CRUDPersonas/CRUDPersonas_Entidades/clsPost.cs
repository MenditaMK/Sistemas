using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDPersonas_Entidades
{
    public class clsPost
    {
        #region Atributos
        private String nickUsuario;
        private String contenido;
        private DateTime fecha;
        private String imagen;
        #endregion

        #region Propiedades
        public string NickUsuario { get => nickUsuario; set => nickUsuario = value; }
        public string Contenido { get => contenido; set => contenido = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Imagen { get => imagen; set => imagen = value; }
        #endregion

        #region Constructores
        public clsPost(string nickUsuario, string contenido, DateTime fecha, string imagen)
        {
            this.nickUsuario = nickUsuario;
            this.contenido = contenido;
            this.fecha = fecha;
            this.imagen = imagen;
        }

        public clsPost()
        {
        }
        #endregion
    }
}
