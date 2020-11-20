using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ejercicio2._2.Models
{
    public class clsPersona
    {
        #region Atributos
        private int ID;
        private string nombre;
        private string apellidos;
        private DateTime fechaNacimiento;
        private byte[][] foto;
        private string direccion;
        private string telefono;
        #endregion

        #region Propiedades
        public int ID1 { get => ID; set => ID = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public byte[][] Foto { get => foto; set => foto = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        #endregion

        #region Constructores
        //Con parámetros
        public clsPersona(int iD, string nombre, string apellidos, DateTime fechaNacimiento, byte[][] foto, string direccion, string telefono)
        {
            ID = iD;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fechaNacimiento = fechaNacimiento;
            this.foto = foto;
            this.direccion = direccion;
            this.telefono = telefono;
        }
        #endregion
    }
}
}