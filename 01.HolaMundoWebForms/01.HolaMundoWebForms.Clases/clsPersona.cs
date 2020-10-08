using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.HolaMundoWebForms.Clases
{
    public class clsPersona
    {
        #region Atributos
        private string nombre;
        #endregion
        #region Constructores
        //Por Defecto
        public clsPersona() {
            this.nombre = "default";
        }

        //Con parametros
        public clsPersona(String nombre) {
            this.nombre = nombre;
        }
        #endregion
        #region Propiedades
        public string Nombre {
            get => this.nombre;
            set => this.nombre = value;
        }
        #endregion
    }
}
