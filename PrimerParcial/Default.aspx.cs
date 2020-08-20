using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerParcial
{
    public partial class Default : System.Web.UI.Page
    {
        private void Translate()
        {
            lblStudents.InnerText = Properties.Resources.lblStudents;    
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Translate();
        }
    }
}