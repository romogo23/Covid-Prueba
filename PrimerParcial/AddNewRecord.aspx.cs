using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DOM;
using BL;
using System.Data;

namespace PrimerParcial
{
    public partial class AddNewRecord : System.Web.UI.Page
    {
        private List<DailyRecord> recordsList;
        //private List<ForList> list;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (ViewState["Province"] == null)
            //{
            Translate();
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
            if (ViewState["grdRecords"] == null)
            {
                recordsList = new List<DailyRecord>();
            }
            else
            {
                recordsList = (List<DailyRecord>)ViewState["grdRecords"];
            }
            //if (ViewState["grdLIST"] == null)
            //{
            //    list = new List<ForList>();
            //}
            //else
            //{
            //    list = (List<ForList>)ViewState["grdRecords"];
            //}
            //}
            //else
            //{
            //    CantonsManager cantonMan = new CantonsManager();
            //    DataTable cantonList = cantonMan.loadCanton(Convert.ToInt32( ViewState["Province"]));
            //    DataView dv2 = new DataView(cantonList);
            //    ddlCanton.DataSource = dv2;
            //    ddlCanton.DataValueField = cantonList.Columns[0].ToString();
            //    ddlCanton.DataTextField = cantonList.Columns[2].ToString();
            //    ddlCanton.DataBind();
            //}    
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (recordDate.Text != "")
            {
                if (txtPositives.Text != "" && txtNegatives.Text != "" && txtDeads.Text != "" && txtRecovered.Text != "")
                {
                    int positives = Convert.ToInt32(txtPositives.Text);
                    int negatives = Convert.ToInt32(txtNegatives.Text);
                    int recovered = Convert.ToInt32(txtRecovered.Text);
                    int deads = Convert.ToInt32(txtDeads.Text);
                    if (positives >= 0 && negatives >= 0 && recovered >= 0 && deads >= 0)
                    {
                        int totalTested = positives + negatives;
                        recordsList.Add(new DailyRecord(recordDate.Text, Convert.ToInt32(ddlProvince.SelectedValue), Convert.ToInt32(ddlCanton.SelectedValue), positives, negatives, totalTested, recovered, deads));

                        //list.Add(new ForList("Eliminar", recordsList));

                        grdRecords.DataSource = recordsList;
                        grdRecords.DataBind();

                        //grdList.DataSource = list;
                        //grdList.DataBind();

                        ViewState["grdRecords"] = recordsList;
                        //ViewState["grdLIST"] = list;
                        btnSave.Visible = true;
                    }
                }
            }
        }

        private void Translate()
        {
            dateAdd.Text = Properties.Resources.dateAdd;
            province.Text = Properties.Resources.province;
            canton.Text = Properties.Resources.canton;
            cases.Text = Properties.Resources.cases;
            positives.Text = Properties.Resources.positives;
            negatives.Text = Properties.Resources.negatives;
            recovered.Text = Properties.Resources.recovered;
            deads.Text = Properties.Resources.deads;
            btnAdd.Text = Properties.Resources.btnAdd;
            btnSave.Text = Properties.Resources.btnSave;
        }

        protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ViewState["Province"] = ddlProvince.SelectedValue;
            //cases.Text = "dkasasdksadhsadkashdaskd";
            CantonsManager cantonMan = new CantonsManager();
            DataTable cantonList = cantonMan.loadCanton(Convert.ToInt32(ddlProvince.SelectedValue));
            DataView dv2 = new DataView(cantonList);
            ddlCanton.DataSource = dv2;
            ddlCanton.DataValueField = cantonList.Columns[0].ToString();
            ddlCanton.DataTextField = cantonList.Columns[2].ToString();
            ddlCanton.DataBind();
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            DailyRecordsManager man = new DailyRecordsManager();
            man.insertDailyRecords(recordsList);
        }

        protected void grdRecords_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Text = Properties.Resources.recorddate;
            e.Row.Cells[3].Text = Properties.Resources.recordprovince;
            e.Row.Cells[4].Text = Properties.Resources.recordcanton;
            e.Row.Cells[5].Text = Properties.Resources.positives;
            e.Row.Cells[6].Text = Properties.Resources.negatives;
            e.Row.Cells[7].Text = Properties.Resources.totaltested;
            e.Row.Cells[8].Text = Properties.Resources.recovered;
            e.Row.Cells[9].Text = Properties.Resources.deads;
        }

        protected void grdRecords_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //int codeRow = Convert.ToInt32(grdRecords.DataKeys[e.RowIndex].Values[0]);
            //TableCell cell = grdRecords.Rows[e.RowIndex].Cells[2];
            //GridViewRow row = (GridViewRow)grdRecords.Rows[e.RowIndex];
            //grdRecords.DeleteRow(e.RowIndex);

            recordsList.RemoveAt(e.RowIndex);
            grdRecords.DataSource = recordsList;
            grdRecords.DataBind();
        }
    }
}