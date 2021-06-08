using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRUDPersonas_Entidades;
using CRUDPersonas_BL.Listados;

namespace CRUDPersonas_UI.Models
{
    public class clsPersonaNombreDepartamento : clsPersona
    {
        #region Atributos
        private String nombreDepartamento;
        #endregion

        #region Propiedades
        public String NombreDepartamento {
            get { return nombreDepartamento; }
            set { this.nombreDepartamento = value; }
        }
        #endregion

        #region Constructores
        public clsPersonaNombreDepartamento(clsPersona persona, String nombreDepartamento)
         {
            this.Id = persona.Id;
            this.Nombre = persona.Nombre;
            this.Apellidos = persona.Apellidos;
            this.FechaNacimiento = persona.FechaNacimiento;
            this.Direccion = persona.Direccion;
            this.Imagen = persona.Imagen;
            this.Telefono = persona.Telefono;
            this.IdDepartamento = persona.IdDepartamento;
            this.NombreDepartamento = nombreDepartamento;
        }
        #endregion
    }
}