using ExamenSGE_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamenSGE_BL.Listados;

namespace ExamenSGE_UI.Models
{
    public class clsListadoMisionesNoCompletadas
    {
        #region Atributos
        private List<clsMisiones> listadoMisionesNoCompletadas;
        #endregion

        #region Constructores
        public clsListadoMisionesNoCompletadas(List<clsMisiones> listadoMisiones)
        {
            this.listadoMisionesNoCompletadas = listadoMisionesNoCompletadas;
        }

        public clsListadoMisionesNoCompletadas() {
            listadoMisionesNoCompletadas = new List<clsMisiones>();
        }
        #endregion

        #region Propiedades
        public List<clsMisiones> ListadoMisionesNoCompletadas { get => listadoMisionesNoCompletadas; set => listadoMisionesNoCompletadas = value; }
        #endregion

        #region Métodos

        /// <summary>
        /// Este método obtiene de la base de datos el listado de misiones no completadas y se lo asigna a
        /// </summary>
        public void rellenarListadoMisiones() {
            this.listadoMisionesNoCompletadas = clsGestoraListadoMisionesBL.obtenerListadoMisionesNoCompletadas();
        }
        #endregion
    }
}