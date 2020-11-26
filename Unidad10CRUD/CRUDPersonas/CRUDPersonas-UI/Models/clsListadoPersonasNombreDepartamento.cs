using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDPersonas_UI.Models
{
    public class clsListadoPersonasNombreDepartamento
    {
        #region Atributos
        private List<clsPersonaNombreDepartamento> listado;
        #endregion

        #region Propiedades
        public List<clsPersonaNombreDepartamento> Listado {
            get { return listado; }
            set { this.listado = value; }
        }
        #endregion


    }
}