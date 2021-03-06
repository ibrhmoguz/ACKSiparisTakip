﻿using ACKSiparisTakip.Business.ACKBusiness;
using ACKSiparisTakip.Web.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFrame.DataType.Common.Attributes;
using WebFrame.DataType.Common.Logging;

namespace ACKSiparisTakip.Web
{
    public partial class MontajKotaTanimla : ACKBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MontajKotalariListele();
            }
        }

        private void MontajKotalariListele()
        {
            DataTable dt = new MontajBS().MontajKotaListele();
            if (dt != null && dt.Rows.Count > 0)
            {
                grdMontajKota.DataSource = dt;
                grdMontajKota.DataBind();
            }
            else
            {
                grdMontajKota.DataSource = null;
                grdMontajKota.DataBind();
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if (rdtMontajTarih.SelectedDate == null)
            {
                MessageBox.Uyari(this.Page, "Montaj tarihi seçmelisiniz!");
                return;
            }

            int kota;
            if (string.IsNullOrEmpty(txtMontajKota.Text) || !Int32.TryParse(txtMontajKota.Text, out kota))
            {
                MessageBox.Uyari(this.Page, "Montaj kotası girmelisiniz!");
                return;
            }

            bool islemDurumu = new MontajBS().MontajKotaKaydet(rdtMontajTarih.SelectedDate.Value, kota, !chcBoxMontajKabul.Checked);
            MontajKotalariListele();
            if (islemDurumu)
            {
                MessageBox.Basari(this.Page, "Montaj kota bilgisi eklendi.");
                txtMontajKota.Text = string.Empty;
                rdtMontajTarih.SelectedDate = null;
                chcBoxMontajKabul.Checked = false;
            }
            else
                MessageBox.Hata(this.Page, "Montaj kota bilgisi eklenmedi.");
        }

        protected void grdMontajKota_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            bool islemDurum = new MontajBS().MontajKotaSil(e.Keys[0].ToString());
            MontajKotalariListele();
            if (islemDurum)
            {
                MessageBox.Basari(this.Page, "Montaj kota bilgisi silindi.");
            }
            else
                MessageBox.Hata(this.Page, "Montaj kota bilgisi silinmedi.");
        }
    }
}