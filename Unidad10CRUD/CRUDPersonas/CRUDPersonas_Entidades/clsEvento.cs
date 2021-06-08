using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDPersonas_Entidades
{
    public class clsEvento
    {
        #region Atributos
        private int id;
        private String cartel;
        private DateTime fecha;
        private String informacion;
        private String lugar;
        private String genero;
        private String titulo;
        private String provincia;
        #endregion

        #region Propiedades
        public string Cartel { get => cartel; set => cartel = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Informacion { get => informacion; set => informacion = value; }
        public string Lugar { get => lugar; set => lugar = value; }
        public string Genero { get => genero; set => genero = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public int Id { get => id; set => id = value; }
        public string Provincia { get => provincia; set => provincia = value; }
        #endregion

        #region Constructores
        public clsEvento(string cartel, DateTime fecha, string informacion, string lugar, string genero, string titulo, int id, string provincia)
        {
            this.cartel = cartel;
            this.fecha = fecha;
            this.informacion = informacion;
            this.lugar = lugar;
            this.genero = genero;
            this.titulo = titulo;
            this.Id = id;
            this.provincia = provincia;
        }

        public clsEvento()
        {
            this.cartel = "";
            this.fecha = new DateTime(1996, 06, 23);
            this.informacion = "";
            this.lugar = "";
            this.genero = "";
            this.titulo = "";
            this.provincia = "";
        }
        #endregion
    }
}
