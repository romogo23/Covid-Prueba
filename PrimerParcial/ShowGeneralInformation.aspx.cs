using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using DOM;

namespace PrimerParcial
{
    public partial class ShowGeneralInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DailyRecordsManager man = new DailyRecordsManager();
            DataTable tbl = man.allRecords();
            tbl.Columns[0].ColumnName = Properties.Resources.canton;
            tbl.Columns[1].ColumnName = Properties.Resources.totalpositive;
            tbl.Columns[2].ColumnName = Properties.Resources.totalnegative;
            tbl.Columns[3].ColumnName = Properties.Resources.totaltested;
            tbl.Columns[4].ColumnName = Properties.Resources.totalrecovered;
            tbl.Columns[5].ColumnName = Properties.Resources.totaldeaths;
            tbl.Columns[6].ColumnName = Properties.Resources.deathrate;
            tbl.Columns[7].ColumnName = Properties.Resources.postivityrate;
            tbl.Columns[8].ColumnName = Properties.Resources.recoveryrate;
            grdGeneral.DataSource = tbl;

            grdGeneral.DataBind();
        }

        protected void RowCreated(object sender, GridViewRowEventArgs e)
        {
        }
    }
}