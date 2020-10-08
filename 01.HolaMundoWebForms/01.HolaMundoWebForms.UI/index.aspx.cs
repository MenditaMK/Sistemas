using _01.HolaMundoWebForms.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;

namespace _01.HolaMundoWebForms.UI
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSaludar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNombre.Text))
            {
                lblSaludo.ForeColor = System.Drawing.Color.Red;
                lblSaludo.Text = "Por favor, el campo no puede estar vacio";
            }
            else {
                lblSaludo.ForeColor = System.Drawing.Color.Black;
                clsPersona persona = new clsPersona(txtNombre.Text);
                lblSaludo.Text = $"Hola {persona.Nombre}";
            }
            
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}