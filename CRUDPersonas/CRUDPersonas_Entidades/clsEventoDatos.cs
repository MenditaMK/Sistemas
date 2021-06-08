using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDPersonas_Entidades
{
    public class clsEventoDatos
    {
        #region Atributos
        private clsEvento evento;
        private List<clsPost> posts;
        private String nombreSala;
        private String direccion;
        private String localidad;
        #endregion

        #region Propiedades
        public clsEvento Evento { get => evento; set => evento = value; }
        public List<clsPost> Posts { get => posts; set => posts = value; }
        public string NombreSala { get => nombreSala; set => nombreSala = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Localidad { get => localidad; set => localidad = value; }
        #endregion

        #region Constructores
        public clsEventoDatos(clsEvento evento, List<clsPost> posts, string nombreSala, string direccion, string localidad)
        {
            this.evento = evento;
            this.posts = posts;
            this.nombreSala = nombreSala;
            this.direccion = direccion;
            this.localidad = localidad;
        }

        public clsEventoDatos()
        {
        }
        #endregion
    }
}
