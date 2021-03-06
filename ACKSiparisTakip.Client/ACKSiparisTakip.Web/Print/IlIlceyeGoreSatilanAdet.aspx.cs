﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ACKSiparisTakip.Web.Print
{
    public partial class IlIlceyeGoreSatilanAdet : System.Web.UI.Page
    {
        private DataSet SorguSonucListesi
        {
            get
            {
                if (Session["IlIlceyeGoreSatilanAdet"] != null)
                    return Session["IlIlceyeGoreSatilanAdet"] as DataSet;
                else
                    return null;
            }
            set
            {
                Session["IlIlceyeGoreSatilanAdet"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RaporOlustur();
            }
        }

        private void RaporOlustur()
        {
            DataSet ds = this.SorguSonucListesi;

            DataTable dt1 = YuzdeDegerleriHesapla(ds.Tables[0]);
            DataTable dt2 = YuzdeDegerleriHesapla(ds.Tables[1]);
            DataTable dt3 = YuzdeDegerleriHesapla(ds.Tables[2]);

            GridDoldur(grdRaporIl, dt1);
            GridDoldur(grdRaporIlce, dt2);
            GridDoldur(grdRaporSemt, dt3);
        }

        private void GridDoldur(GridView gv, DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                gv.DataSource = dt;
                gv.DataBind();
            }
            else
            {
                gv.DataSource = null;
                gv.DataBind();
            }
        }

        private DataTable YuzdeDegerleriHesapla(DataTable dt)
        {
            decimal toplamAdet = Convert.ToDecimal(dt.AsEnumerable().Sum(a => Convert.ToInt32(a.Field<string>("Yillik"))).ToString());
            decimal yuzde;

            foreach (DataRow row in dt.Rows)
            {
                if (row["Yillik"] != DBNull.Value)
                {
                    yuzde = Convert.ToDecimal((Convert.ToDecimal(row["Yillik"].ToString()) / toplamAdet));
                    row["Yuzde(%)"] = (yuzde * 100).ToString("0.00", CultureInfo.InvariantCulture);
                }
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (dt.Rows[i][j] != DBNull.Value && dt.Rows[i][j].ToString() == "0")
                        dt.Rows[i][j] = string.Empty;
                }
            }

            return dt;
        }
    }
}