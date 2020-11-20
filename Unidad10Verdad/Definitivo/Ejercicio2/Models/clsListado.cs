using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ejercicio2.Models
{
    public class clsListado
    {
        #region Atributos
        private List<clsPersona> listadoPersonas;
        #endregion

        #region Propiedades
        public List<clsPersona> ListadoPersonas { get => listadoPersonas; set => listadoPersonas = value; }
        #endregion

        #region Constructores
        //Con parámetros
        public clsListado(List<clsPersona> listadoPersonas) {
            this.listadoPersonas = listadoPersonas;
        }
        #endregion
    }
}