using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDPersonas_Entidades
{
    public class clsDepartamento
    {
        #region Atributos
        private int id;
        private String nombre;
        #endregion

        #region Constructores
        public clsDepartamento(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }

        public clsDepartamento() {
            this.id = 0;
            this.nombre = "";
        }
        #endregion

        #region Propiedades
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        #endregion
    }
}
