using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDPersonas_Entidades
{
    public class clsListadoArtistasEvento
    {
        #region Atributos
        private List<String> listadoArtistas;
        private int idEvento;
        #endregion

        #region Propiedades
        public List<string> ListadoArtistas { get => listadoArtistas; set => listadoArtistas = value; }
        public int IDEvento { get => idEvento; set => idEvento = value; }
        #endregion

        #region Constructores
        public clsListadoArtistasEvento(List<string> listadoArtistas, int idEvento)
        {
            this.listadoArtistas = listadoArtistas;
            this.idEvento = idEvento;
        }
        #endregion
    }
}