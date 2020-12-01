using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDPersonas_Entidades
{
    public class clsPersona
    {
        #region Atributos
        private int id;
        private String nombre;
        private String apellidos;
        private DateTime fechaNacimiento;
        private byte[] imagen;
        private String direccion;
        private String telefono;
        private int idDepartamento;
        #endregion

        #region Constructores

        public clsPersona(int id, string nombre, string apellidos, DateTime fechaNacimiento, byte[] imagen, string direccion, string telefono, int idDepartamento)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.FechaNacimiento = fechaNacimiento;
            this.Imagen = imagen;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.IdDepartamento = idDepartamento;
        }

        public clsPersona() { }
        #endregion

        #region Propiedades
        public int Id { get => id; set => id = value; }
        [Required]
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public byte[] Imagen { get => imagen; set => imagen = value; }
        public string Direccion { get => direccion; set => direccion = value; }

        [MaxLength(9)]
        public string Telefono { get => telefono; set => telefono = value; }
        public int IdDepartamento { get => idDepartamento; set => idDepartamento = value; }
        #endregion
    }
}
