using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenSGE_Entidades
{
    public class clsMisiones
    {
        #region Atributos
        private int id;
        private String nombre;
        private String descripcion;
        private int creditos;
        private bool completada;

        public clsMisiones()
        {
        }
        #endregion
        #region Constructores

        public clsMisiones(int id, string nombre, string descripcion, int creditos, bool completada)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.creditos = creditos;
            this.completada = completada;
        }
        #endregion

        #region Propiedades

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Creditos { get => creditos; set => creditos = value; }
        public bool Completada { get => completada; set => completada = value; }
        #endregion
    }
}
