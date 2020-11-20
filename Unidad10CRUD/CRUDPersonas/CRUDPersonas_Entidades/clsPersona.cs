using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDPersonas_Entidades
{
    public class clsPersona
    {
        #region Atributos
        private int ID;
        private String nombre;
        private String apellidos;
        private DateTime fechaNacimiento;
        private String telefono;
        private String direccion;
        #endregion

        #region Propiedades
        public String Nombre {
            get { return this.nombre; }
            set { this.nombre = value; } 
        }
        public String Apellidos
        {
            get { return this.apellidos; }
            set { this.apellidos = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return this.fechaNacimiento; }
            set { this.fechaNacimiento = value; }
        }

        public String Telefono
        {
            get { return this.telefono; }
            set { this.telefono = value; }
        }

        public String Direccion
        {
            get { return this.direccion; }
            set { this.direccion = value; }
        }
        #endregion

        #region Constructores
        //Sin Parametros
        public clsPersona()
        {
            ID = 1;
            nombre = "Menda";
            apellidos = "Quintero";
            fechaNacimiento = new DateTime(1995, 10, 20);
            direccion = "C/Piruleta nº22";
            telefono = "660013713";

        }

        //Con parametros
        public clsPersona(string nombre, string apellido, DateTime fechaNac, string direccion, string telefono)
        {
            this.nombre = nombre;
            this.apellidos = apellido;
            this.fechaNacimiento = fechaNac;
            this.direccion = direccion;
            this.telefono = telefono;
        }
        #endregion
    }
}
