using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace Ejercicio1.Controllers
{
    public class DataBaseController : Controller
    {
        // GET: DataBase
        public ActionResult Index()
        {
     
            return View();
        }

        [HttpPost, ActionName("Index")]
        public ActionResult IndexPost() {
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.ConnectionString = "server = jaquintero.database.windows.net; database = jaquintero; uid = prueba; pwd = Mitesoro1.";

                connection.Open();
            }
            catch (SqlException exception) { 
                
            }
            return View();
        }
    }
}