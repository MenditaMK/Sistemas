using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ejercicio2.Models
{
    public class clsListadoPersonas
    {
        #region Atributos
        private List<clsPersona> listadoPersonas;
        #endregion

        #region Constructores
        public clsListadoPersonas(List<clsPersona> listadoPersonas)
        {
            this.listadoPersonas = listadoPersonas;
        }
        #endregion

        #region Propiedades
        public List<clsPersona> ListadoPersonas { get => listadoPersonas;}
        #endregion

        #region Métodos
        public List<clsPersona> obtenerListadoPersonas() { 
            
        }
        #endregion
    }
}