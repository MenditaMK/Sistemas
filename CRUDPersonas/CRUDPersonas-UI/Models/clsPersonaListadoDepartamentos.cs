using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRUDPersonas_Entidades;
using CRUDPersonas_BL.Listados;

namespace CRUDPersonas_UI.Models
{
    public class clsPersonaListadoDepartamentos : clsPersona
    {
        #region Atributos
        private List<clsDepartamento> listadoDepartamentos;
        #endregion

        #region Propiedades
        public List<clsDepartamento> ListadoDepartamentos { get => listadoDepartamentos; set => listadoDepartamentos = value; }
        #endregion

        #region Constructores
        public clsPersonaListadoDepartamentos(clsPersona persona) {
            this.Id = persona.Id;
            this.Nombre = persona.Nombre;
            this.Apellidos = persona.Apellidos;
            this.FechaNacimiento = persona.FechaNacimiento;
            this.Direccion = persona.Direccion;
            this.Imagen = persona.Imagen;
            this.Telefono = persona.Telefono;
            this.IdDepartamento = persona.IdDepartamento;
            this.listadoDepartamentos = clsListadoDepartamentosBL.obtenerListadoDepartamentos();
        }

        public clsPersonaListadoDepartamentos() { }
        #endregion
    }
}