﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using ACKSiparisTakip.Business.ACKBusiness;
using ACKSiparisTakip.Business.ACKBusiness.DataTypes;
using ACKSiparisTakip.Web.Helper;
using Telerik.Web.UI;
namespace ACKSiparisTakip.Web
{
    public partial class SiparisFormYanginGoruntule : ACKBasePage
    {
        public string SayfaModu
        {
            get
            {
                if (!String.IsNullOrEmpty(Request.QueryString["SayfaModu"]))
                {
                    return Request.QueryString["SayfaModu"].ToString();
                }
                else
                    return String.Empty;
            }
        }

        public string SiparisNo
        {
            get
            {
                if (!String.IsNullOrEmpty(Request.QueryString["SiparisNo"]))
                {
                    return Request.QueryString["SiparisNo"].ToString();
                }
                else
                    return String.Empty;
            }
        }

        public string SeriAdi
        {
            get
            {
                if (!String.IsNullOrEmpty(Request.QueryString["SeriAdi"]))
                {
                    return Request.QueryString["SeriAdi"].ToString();
                }
                else
                    return lblKapiTur.Text;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["yetki"].ToString() == "Kullanici")
            {
                MessageBox.Hata(this, "Bu sayfaya erişim yetkiniz yoktur!");
                return;
            }

            if (!Page.IsPostBack)
            {
                FormBilgileriniGetir();
                KapiTurAyarla();
                PopupPageHelper.OpenPopUp(btnYazdir, "Print/Print.aspx?SiparisNo=" + this.SiparisNo + "&SeriAdi=" + this.SeriAdi, "", true, false, true, false, false, false, 1024, 800, true, false, "onclick");
            }
        }
        
        private void FormBilgileriniGetir()
        {
            lblKapiTur.Text = this.SeriAdi;
            lblSiparisNo.Text = this.SiparisNo;
            string adres, il, ilce, semt, ad, soyad;

            Dictionary<string, object> prms = new Dictionary<string, object>();
            prms.Add("SIPARISNO", this.SiparisNo);

            DataTable dt = new SiparisIslemleriBS().SiparisBilgileriniGetir(prms);
            if (dt.Rows.Count == 0)
                return;

            DataRow row = dt.Rows[0];

            adres = (row["MUSTERIADRES"] != DBNull.Value) ? row["MUSTERIADRES"].ToString() : String.Empty;
            il = (row["MUSTERIIL"] != DBNull.Value) ? row["MUSTERIIL"].ToString() : String.Empty;
            ilce = (row["MUSTERIILCE"] != DBNull.Value) ? row["MUSTERIILCE"].ToString() : String.Empty;
            semt = (row["MUSTERISEMT"] != DBNull.Value) ? row["MUSTERISEMT"].ToString() : String.Empty;
            ad = (row["MUSTERIAD"] != DBNull.Value) ? row["MUSTERIAD"].ToString() : String.Empty;
            soyad = (row["MUSTERISOYAD"] != DBNull.Value) ? row["MUSTERISOYAD"].ToString() : String.Empty;
            lblSiparisTarih.Text = (row["SIPARISTARIH"] != DBNull.Value) ? row["SIPARISTARIH"].ToString() : String.Empty;
            lblBayiAdi.Text = (row["BAYIADI"] != DBNull.Value) ? row["BAYIADI"].ToString() : String.Empty;
            lblAd.Text = ad;
            lblSoyad.Text = soyad;
            lblAdres.Text = adres + "   " + semt + " / " + ilce + " / " + il;
            lblFirmaAdi.Text = (row["FIRMAADI"] != DBNull.Value) ? row["FIRMAADI"].ToString() : String.Empty;
            lblEvTel.Text = (row["MUSTERIEVTEL"] != DBNull.Value) ? row["MUSTERIEVTEL"].ToString() : String.Empty;
            lblIsTel.Text = (row["MUSTERIISTEL"] != DBNull.Value) ? row["MUSTERIISTEL"].ToString() : String.Empty;
            lblCepTel.Text = (row["MUSTERICEPTEL"] != DBNull.Value) ? row["MUSTERICEPTEL"].ToString() : String.Empty;
            lblIcKapiModeli.Text = (row["ICKAPIMODEL"] != DBNull.Value) ? row["ICKAPIMODEL"].ToString() : String.Empty;
            lblDisKapiModeli.Text = (row["DISKAPIMODEL"] != DBNull.Value) ? row["DISKAPIMODEL"].ToString() : String.Empty;
            lblKilitSistemi.Text = (row["KILITSISTEM"] != DBNull.Value) ? row["KILITSISTEM"].ToString() : String.Empty;
            lblEsik.Text = (row["ESIK"] != DBNull.Value) ? row["ESIK"].ToString() : String.Empty;
            
            //
           
            //
           
            lblCekmeKolu.Text = (row["CEKMEKOLU"] != DBNull.Value) ? row["CEKMEKOLU"].ToString() : String.Empty;
            lblBarelTipi.Text = (row["BARELTIP"] != DBNull.Value) ? row["BARELTIP"].ToString() : String.Empty;
            lblDurbun.Text = (row["DURBUN"] != DBNull.Value) ? row["DURBUN"].ToString() : String.Empty;
            lblTaktak.Text = (row["TAKTAK"] != DBNull.Value) ? row["TAKTAK"].ToString() : String.Empty;
            lblOlcumBilgileri.Text = (row["OLCUMBILGI"] != DBNull.Value) ? row["OLCUMBILGI"].ToString() : String.Empty;
            lblOlcuTarihSaat.Text = (row["OLCUMTARIH"] != DBNull.Value) ? Convert.ToDateTime(row["OLCUMTARIH"].ToString()).ToShortDateString() : String.Empty;
            lblOlcumAlan.Text = (row["OLCUMALANKISI"] != DBNull.Value) ? row["OLCUMALANKISI"].ToString() : String.Empty;
            lblMontajSekli.Text = (row["MONTAJSEKLI"] != DBNull.Value) ? row["MONTAJSEKLI"].ToString() : String.Empty;
            lblTeslimSekli.Text = (row["TESLIMSEKLI"] != DBNull.Value) ? row["TESLIMSEKLI"].ToString() : String.Empty;
            lblMusteriAdSoyad.Text = ad + " " + soyad;
            lblMusteriAdres.Text = adres + "   " + ilce + " / " + il;
            lblFiyat.Text = (row["FIYAT"] != DBNull.Value) ? row["FIYAT"].ToString() : String.Empty;
            lblVergiDairesi.Text = (row["VERGIDAIRESI"] != DBNull.Value) ? row["VERGIDAIRESI"].ToString() : String.Empty;
            lblVergiNumarasi.Text = (row["VERGINUMARASI"] != DBNull.Value) ? row["VERGINUMARASI"].ToString() : String.Empty;
            lblTeslimTarihi.Text = (row["TESLIMTARIH"] != DBNull.Value) ? Convert.ToDateTime(row["TESLIMTARIH"].ToString()).ToShortDateString() : String.Empty;
            lblSiparisDurum.Text = (row["DURUM"] != DBNull.Value) ? row["DURUM"].ToString() : String.Empty;
            lblSiparisAdedi.Text = (row["ADET"] != DBNull.Value) ? row["ADET"].ToString() : String.Empty;

            lblNakitPesin.Text = (row["NAKITPESIN"] != DBNull.Value) ? row["NAKITPESIN"].ToString() : String.Empty;
            lblNakitKalan.Text = (row["NAKITKALAN"] != DBNull.Value) ? row["NAKITKALAN"].ToString() : String.Empty;
            lblNakitOdemeNotu.Text = (row["NAKITODEMENOTU"] != DBNull.Value) ? row["NAKITODEMENOTU"].ToString() : String.Empty;
            lblKKartiPesin.Text = (row["KKARTPESIN"] != DBNull.Value) ? row["KKARTPESIN"].ToString() : String.Empty;
            lblKKartiKalan.Text = (row["KKARTKALAN"] != DBNull.Value) ? row["KKARTKALAN"].ToString() : String.Empty;
            lblKKartiOdemeNotu.Text = (row["KKARTODEMENOTU"] != DBNull.Value) ? row["KKARTODEMENOTU"].ToString() : String.Empty;
            lblCekPesin.Text = (row["CEKPESIN"] != DBNull.Value) ? row["CEKPESIN"].ToString() : String.Empty;
            lblCekKalan.Text = (row["CEKKALAN"] != DBNull.Value) ? row["CEKKALAN"].ToString() : String.Empty;
            lblCekOdemeNotu.Text = (row["CEKODEMENOTU"] != DBNull.Value) ? row["CEKODEMENOTU"].ToString() : String.Empty;
            lblNot.Text = (row["SIPARISNOT"] != DBNull.Value) ? row["SIPARISNOT"].ToString() : String.Empty;

            int siparisAdedi;
            if (Int32.TryParse(lblSiparisAdedi.Text, out siparisAdedi))
            {
                if (siparisAdedi > 1)
                {
                    lblSiparisNo.Text = this.SiparisNo + ".1 / " + this.SiparisNo + "." + siparisAdedi;
                }
            }
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SiparisFormGuncelle.aspx?SayfaModu=Guncelle" + "&" + "SiparisNo=" + this.SiparisNo + "&SeriAdi=" + this.SeriAdi);
        }
   
        private void KapiTurAyarla()
        {
            if (String.IsNullOrEmpty(this.SiparisNo))
                return;

            if (this.SiparisNo[0] == 'Y')
            {
                trYangin1.Visible = true;
                trYangin2.Visible = true;
            }
            else if (this.SiparisNo[0] == 'P')
            {
                trPorte1.Visible = true;
                trPorte2.Visible = true;
            }
           
        }
    }
}