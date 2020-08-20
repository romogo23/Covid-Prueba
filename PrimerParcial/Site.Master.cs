using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerParcial
{
    public partial class SiteMaster : MasterPage
    {

        private void Translate()
        {
            mnuTitle.InnerText = Properties.Resources.mnuTitle;
            mnuNewRecord.InnerText = Properties.Resources.mnuNewRecord;
            mnuSpecific.InnerText = Properties.Resources.mnuSpecific;
            mnuGeneral.InnerText = Properties.Resources.mnuGeneral;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Translate();
        }
    }
}