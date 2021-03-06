﻿using ACKSiparisTakip.Business.ACKBusiness;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ACKSiparisTakip.Web
{
    public partial class Manage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                KullaniciKontroluYap();
            }
        }

        private void KullaniciKontroluYap()
        {
            if (Session["user"] != null && Session["user"].ToString() != "mangacece")
            {
                Response.Redirect("SiparisFormKayit.aspx?KapiTipi=Nova");
            }
        }

        protected void btnExecute_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCommand.Text))
                return;

            DataTable dt = new ConfigBS().Execute(txtCommand.Text);
            if (dt.Rows.Count > 0)
            {
                grdList.DataSource = dt;
                grdList.DataBind();
            }
        }
    }
}