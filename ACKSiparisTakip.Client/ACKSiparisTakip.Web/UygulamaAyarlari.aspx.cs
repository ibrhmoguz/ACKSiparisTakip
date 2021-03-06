﻿using ACKSiparisTakip.Business.ACKBusiness;
using ACKSiparisTakip.Web.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ACKSiparisTakip.Web
{
    public partial class UygulamaAyarlari : ACKBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FormVerileriniGetir();
            }
        }

        private void FormVerileriniGetir()
        {
            DataTable dt = new ConfigBS().ConfigBilgileriniGetir();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                if (row != null)
                {
                    if (row["ConfigName"] != DBNull.Value && row["ConfigName"].ToString() == "MONTAJ_KOTA_KONTROLU")
                        if (row["ConfigValue"].ToString() == "1")
                            chcBoxMontajKotaKontrolu.Checked = true;
                        else
                            chcBoxMontajKotaKontrolu.Checked = false;

                }
                DataRow row1 = dt.Rows[1];
                if (row1 != null)
                {
                    if (row1["ConfigName"] != DBNull.Value && row1["ConfigName"].ToString() == "MONTAJ_KOTA_VARSAYILAN")
                        txtMontajKotaVarsayilan.Text = row1["ConfigValue"].ToString();
                }
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            string varsayilan;
            if (chcBoxMontajKotaKontrolu.Checked)
            {
                if (string.IsNullOrEmpty(txtMontajKotaVarsayilan.Text))
                {
                    MessageBox.Uyari(this.Page, "Montaj kota varsayılan değeri giriniz.");
                    return;
                }
                varsayilan = txtMontajKotaVarsayilan.Text;

                Session["MONTAJ_KOTA_KONTROLU"] = "1";
                Session["MONTAJ_KOTA_VARSAYILAN"] = varsayilan;
            }
            else
            {
                varsayilan = "0";
                Session["MONTAJ_KOTA_KONTROLU"] = "0";
                Session["MONTAJ_KOTA_VARSAYILAN"] = "0";
            }

            bool islemDurumu = new ConfigBS().ConfigDegerleriniKaydet(chcBoxMontajKotaKontrolu.Checked, varsayilan);

            if (islemDurumu)
            {
                MessageBox.Basari(this.Page, "Değerler kayıt edildi.");
                FormVerileriniGetir();
            }
            else
                MessageBox.Hata(this.Page, "Hata Oluştu");
        }
    }
}