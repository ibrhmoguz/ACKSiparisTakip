﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using System.Data;
using ACKSiparisTakip.Business.ACKBusiness;
using ACKSiparisTakip.Business.ACKBusiness.DataTypes;
using ACKSiparisTakip.Web.Helper;
using Telerik.Web.UI;

namespace ACKSiparisTakip.Web.Print
{
    public partial class Print : System.Web.UI.Page
    {
        private DataTable SiparisBilgileri
        {
            get
            {
                if (Session["SiparisBilgileri"] != null)
                    return Session["SiparisBilgileri"] as DataTable;
                else
                    return null;
            }
            set
            {
                Session["SiparisBilgileri"] = value;
            }
        }

        private string SeriAdi
        {
            get
            {
                if (!String.IsNullOrEmpty(Request.QueryString["SeriAdi"]))
                {
                    return Request.QueryString["SeriAdi"].ToString();
                }
                else
                    return String.Empty;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FormBilgileriniGetir();
            }
        }

        private void KapiTurAyarla(string siparisNo)
        {
            if (String.IsNullOrEmpty(siparisNo))
                return;

            switch (siparisNo[0].ToString())
            {
                case "N":
                    lblKapiTur.Text = "NOVA";
                    lblStandartOlcu.Text = "930 x 2010";
                    break;
                case "K":
                    lblKapiTur.Text = "KROMA";
                    lblStandartOlcu.Text = "940 x 2000";
                    break;
                case "G":
                    lblKapiTur.Text = "GUARD";
                    trGuard.Visible = true;
                    break;
            }
        }

        private void FormBilgileriniGetir()
        {
            lblKapiTur.Text = this.SeriAdi;
            string adres, il, ilce, semt, ad, soyad;

            DataTable dt = this.SiparisBilgileri;
            if (dt.Rows.Count == 0)
                return;

            DataRow row = dt.Rows[0];

            string siparisNo = (row["SIPARISNO"] != DBNull.Value) ? row["SIPARISNO"].ToString() : String.Empty;
            lblSiparisNo.Text = siparisNo;
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
            lblDisKapiRengi.Text = (row["DISKAPIRENK"] != DBNull.Value) ? row["DISKAPIRENK"].ToString() : String.Empty;
            lblIcKapiRengi.Text = (row["ICKAPIRENK"] != DBNull.Value) ? row["ICKAPIRENK"].ToString() : String.Empty;
            lblKilitSistemi.Text = (row["KILITSISTEM"] != DBNull.Value) ? row["KILITSISTEM"].ToString() : String.Empty;
            lblCita.Text = (row["CITA"] != DBNull.Value) ? row["CITA"].ToString() : String.Empty;
            lblEsik.Text = (row["ESIK"] != DBNull.Value) ? row["ESIK"].ToString() : String.Empty;
            lblAluminyumRengi.Text = (row["ALUMINYUMRENK"] != DBNull.Value) ? row["ALUMINYUMRENK"].ToString() : String.Empty;
            lblContaRengi.Text = (row["CONTARENK"] != DBNull.Value) ? row["CONTARENK"].ToString() : String.Empty;
            lblTacTipi.Text = (row["TACTIP"] != DBNull.Value) ? row["TACTIP"].ToString() : String.Empty;
            lblIcPervazRenk.Text = (row["ICPERVAZRENK"] != DBNull.Value) ? row["ICPERVAZRENK"].ToString() : String.Empty;
            lblDisPervazRenk.Text = (row["DISPERVAZRENK"] != DBNull.Value) ? row["DISPERVAZRENK"].ToString() : String.Empty;
            lblAplikeRenk.Text = (row["APLIKERENK"] != DBNull.Value) ? row["APLIKERENK"].ToString() : String.Empty;
            lblKanatRenk.Text = (row["KANAT"] != DBNull.Value) ? row["KANAT"].ToString() : String.Empty;
            lblCitaRenk.Text = (row["KASACITARENK"] != DBNull.Value) ? row["KASACITARENK"].ToString() : String.Empty;
            lblZirhTipi.Text = (row["ZIRHTIP"] != DBNull.Value) ? row["ZIRHTIP"].ToString() : String.Empty;
            lblZirhRengi.Text = (row["ZIRHRENK"] != DBNull.Value) ? row["ZIRHRENK"].ToString() : String.Empty;
            lblCekmeKoluTakilmaSekli.Text = (row["CEKMEKOLTAKILMASEKLI"] != DBNull.Value) ? row["CEKMEKOLTAKILMASEKLI"].ToString() : String.Empty;
            lblCekmeKoluRengi.Text = (row["CEKMEKOLRENK"] != DBNull.Value) ? row["CEKMEKOLRENK"].ToString() : String.Empty;
            lblBolmeKayitSayisi.Text = (row["BOLMEKAYITSAYI"] != DBNull.Value) ? row["BOLMEKAYITSAYI"].ToString() : String.Empty;
            lblCamTipi.Text = (row["CAMTIP"] != DBNull.Value) ? row["CAMTIP"].ToString() : String.Empty;
            lblFerforje.Text = (row["FERFORJE"] != DBNull.Value) ? row["FERFORJE"].ToString() : String.Empty;
            lblFerforjeRenk.Text = (row["FERFORJERENK"] != DBNull.Value) ? row["FERFORJERENK"].ToString() : String.Empty;
            lblMetalRenk.Text = (row["METALRENK"] != DBNull.Value) ? row["METALRENK"].ToString() : String.Empty;
            lblKasaKaplama.Text = (row["KASAKAPLAMA"] != DBNull.Value) ? row["KASAKAPLAMA"].ToString() : String.Empty;
            lblPervazTipi.Text = (row["PERVAZTIP"] != DBNull.Value) ? row["PERVAZTIP"].ToString() : String.Empty;
            lblCekmeKolu.Text = (row["CEKMEKOLU"] != DBNull.Value) ? row["CEKMEKOLU"].ToString() : String.Empty;
            lblKayitsizKam.Text = (row["KAYITSIZKAMERA"] != DBNull.Value) ? row["KAYITSIZKAMERA"].ToString() : String.Empty; ;
            lblKayitYapanKam.Text = (row["KAYITYAPANKAMERA"] != DBNull.Value) ? row["KAYITYAPANKAMERA"].ToString() : String.Empty; ;
            lblAlarm.Text = (row["ALARM"] != DBNull.Value) ? row["ALARM"].ToString() : String.Empty; ;
            lblOtomatikKilit.Text = (row["OTOKILIT"] != DBNull.Value) ? row["OTOKILIT"].ToString() : String.Empty;
            lblBarelTipi.Text = (row["BARELTIP"] != DBNull.Value) ? row["BARELTIP"].ToString() : String.Empty;
            lblBaba.Text = (row["BABA"] != DBNull.Value) ? row["BABA"].ToString() : String.Empty;
            lblDurbun.Text = (row["DURBUN"] != DBNull.Value) ? row["DURBUN"].ToString() : String.Empty;
            lblTaktak.Text = (row["TAKTAK"] != DBNull.Value) ? row["TAKTAK"].ToString() : String.Empty;
            lblMontajdaTakilacaklar.Text = (row["MONTAJDATAKILACAK"] != DBNull.Value) ? row["MONTAJDATAKILACAK"].ToString() : String.Empty;
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
            //lblSiparisDurum.Text = (row["DURUM"] != DBNull.Value) ? row["DURUM"].ToString() : String.Empty;
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

            lblAcilim.Text = (row["ACILIM"] != DBNull.Value) ? row["ACILIM"].ToString() : String.Empty;
            lblIcKasaGenisligi.Text = (row["ICKASAGENISLIK"] != DBNull.Value) ? row["ICKASAGENISLIK"].ToString() : String.Empty;
            lblIcKasaYuksekligi.Text = (row["ICKASAYUKSEKLIK"] != DBNull.Value) ? row["ICKASAYUKSEKLIK"].ToString() : String.Empty;
            lblDisKasaIcPervazFarki.Text = (row["DISKASAICPERVAZFARK"] != DBNull.Value) ? row["DISKASAICPERVAZFARK"].ToString() : String.Empty;
            lblDuvarKalinligi.Text = (row["DUVARKALINLIK"] != DBNull.Value) ? row["DUVARKALINLIK"].ToString() : String.Empty;
            lblDisSolPervaz.Text = (row["DISSOLPERVAZ"] != DBNull.Value) ? row["DISSOLPERVAZ"].ToString() : String.Empty;
            lblDisUstPervaz.Text = (row["DISUSTPERVAZ"] != DBNull.Value) ? row["DISUSTPERVAZ"].ToString() : String.Empty;
            lblDisSagPervaz.Text = (row["DISSAGPERVAZ"] != DBNull.Value) ? row["DISSAGPERVAZ"].ToString() : String.Empty;
            lblIcSolPervaz.Text = (row["ICSOLPERVAZ"] != DBNull.Value) ? row["ICSOLPERVAZ"].ToString() : String.Empty;
            lblIcUstPervaz.Text = (row["ICUSTPERVAZ"] != DBNull.Value) ? row["ICUSTPERVAZ"].ToString() : String.Empty;
            lblIcSagPervaz.Text = (row["ICSAGPERVAZ"] != DBNull.Value) ? row["ICSAGPERVAZ"].ToString() : String.Empty;

            int siparisAdedi;
            if (Int32.TryParse(lblSiparisAdedi.Text, out siparisAdedi))
            {
                if (siparisAdedi > 1)
                {
                    lblSiparisNo.Text = siparisNo + ".1 / " + siparisNo + "." + siparisAdedi;
                }
            }

            KapiTurAyarla(siparisNo);
        }
    }
}