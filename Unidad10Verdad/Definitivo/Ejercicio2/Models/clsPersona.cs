using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ejercicio2.Models
{
    public class clsPersona
    {
        #region Atributos
        private int iD;
        private String nombre;
        private String apellidos;
        private DateTime fechaNacimiento;
        private byte[] foto;
        private String telefono;
        private String direccion;
        private int iDDepartamento;
        #endregion

        #region Propiedades
        public int ID { get => iD; set => iD = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public byte[] Foto { get => foto; set => foto = value; }
        public int IDDepartamento { get => iDDepartamento; set => iDDepartamento = value; }
        #endregion

        #region Constructores
        //Con parámetros
        public clsPersona(int iD, string nombre, string apellidos, DateTime fechaNacimiento, string telefono, string direccion, byte[] foto, int iDDepartamento)
        {
            this.iD = iD;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fechaNacimiento = fechaNacimiento;
            this.telefono = telefono;
            this.direccion = direccion;
            this.foto = foto;
            this.iDDepartamento = iDDepartamento;
        }

        //Sin parámetros
        public clsPersona() {
            this.iD = 1;
            this.nombre = "Juan Antonio";
            this.apellidos = "Quintero Gómez";
            this.fechaNacimiento = new DateTime(1995, 10, 20);
            this.telefono = "660013711";
            this.direccion = "C/ Piruleta";
        }
        #endregion
    }
}