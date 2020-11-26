using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDPersonas_Entidades;
using CRUDPersonas_DAL.Listados;

namespace CRUDPersonas_BL.Listados
{
    public class clsListadoDepartamentosBL
    {
        public static List<clsDepartamento> obtenerListadoDepartamentos()
        {
            //List<clsDepartamento> listado = new List<clsDepartamento>();
            //listado.Add(new clsDepartamento());
            //foreach (clsDepartamento departamento in clsListadoDepartamentoDAL.obtenerListadoDepartamentos()) {
            //    listado.Add(departamento);
            //}
            //return listado;
            return clsListadoDepartamentoDAL.obtenerListadoDepartamentos();
        }

        public static string obtenerNombreDepartamento(int id)
        {
            return clsListadoDepartamentoDAL.obtenerNombreDepartamento(id);
        }
    }
}
