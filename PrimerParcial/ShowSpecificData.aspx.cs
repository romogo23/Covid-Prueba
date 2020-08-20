using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL; 

namespace PrimerParcial
{
    public partial class ShowSpecificData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Translaste();
            if (!IsPostBack)
            {
                ProvincesManager provinceMan = new ProvincesManager();
                DataTable provinceList = provinceMan.loadProvinces();
                DataView dv = new DataView(provinceList);
                ddlProvince.DataSource = dv;
                ddlProvince.DataValueField = provinceList.Columns[0].ToString();
                ddlProvince.DataTextField = provinceList.Columns[1].ToString();
                ddlProvince.DataBind();


                CantonsManager cantonMan = new CantonsManager();
                DataTable cantonList = cantonMan.loadCanton(Convert.ToInt32(ddlProvince.SelectedValue));
                DataView dv2 = new DataView(cantonList);
                ddlCanton.DataSource = dv2;
                ddlCanton.DataValueField = cantonList.Columns[0].ToString();
                ddlCanton.DataTextField = cantonList.Columns[2].ToString();
                ddlCanton.DataBind();
            }
        }

        private void Translaste()
        {
            dateSearch.Text = Properties.Resources.dateSearch;
            lblsince.Text = Properties.Resources.lblsince;
            lbluntil.Text = Properties.Resources.lbluntil;
            province.Text = Properties.Resources.province;
            canton.Text = Properties.Resources.canton;
            btnSearch.Text = Properties.Resources.btnSearch;
        }

        protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            CantonsManager cantonMan = new CantonsManager();
            DataTable cantonList = cantonMan.loadCanton(Convert.ToInt32(ddlProvince.SelectedValue));
            DataView dv2 = new DataView(cantonList);
            ddlCanton.DataSource = dv2;
            ddlCanton.DataValueField = cantonList.Columns[0].ToString();
            ddlCanton.DataTextField = cantonList.Columns[2].ToString();
            ddlCanton.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            recordsFound.Visible = true;
            DailyRecordsManager man = new DailyRecordsManager();
            if (since.Text != "" && until.Text != "")
            {
                DateTime sinceDate = Convert.ToDateTime(since.Text);
                DateTime untilDate = Convert.ToDateTime(until.Text);

                if (sinceDate < untilDate)
                {
                    DataTable records = man.findDailyRecord(Convert.ToInt32(ddlCanton.SelectedValue), sinceDate, untilDate);
                    records.Columns[0].ColumnName = Properties.Resources.totalpositive;
                    records.Columns[1].ColumnName = Properties.Resources.totalnegative;
                    records.Columns[2].ColumnName = Properties.Resources.totaltested;
                    records.Columns[3].ColumnName = Properties.Resources.totalrecovered;
                    records.Columns[4].ColumnName = Properties.Resources.totaldeaths;
                    records.Columns[5].ColumnName = Properties.Resources.deathrate;
                    records.Columns[6].ColumnName = Properties.Resources.postivityrate;
                    records.Columns[7].ColumnName = Properties.Resources.recoveryrate;
                    DataView dv3 = new DataView(records);
                    recordsFound.DataSource = dv3;
                    recordsFound.DataBind();
                }
            }
        }
    }
}