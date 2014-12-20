﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using WebFrame.Business;
using WebFrame.DataAccess;
using WebFrame.DataType.Common.Attributes;
using WebFrame.DataType.Common.Logging;

namespace ACKSiparisTakip.Business.ACKBusiness
{
    [ServiceConnectionNameAttribute("ACKconnectionString")]
    public class MontajBS : BusinessBase
    {
        public DataTable MontajlariListele(DateTime dtBaslangic, DateTime dtBitis)
        {
            IData data = GetDataObject();
            DataTable dt = new DataTable();

            data.AddSqlParameter("BASTAR", dtBaslangic, SqlDbType.DateTime, 50);
            data.AddSqlParameter("BITTAR", dtBitis, SqlDbType.DateTime, 50);

            string sqlKaydet = @"SELECT
	                                M.ID
                                    , M.TESLIMTARIH
	                                , S.SIPARISNO
                                    , S.ADET
	                                , S.MUSTERIAD + ' ' + S.MUSTERISOYAD AS MUSTERI
	                                , S.MUSTERIILCE +'/' + S.MUSTERIIL AS ILILCE
	                                , S.MUSTERIADRES AS ADRES
	                                , S.MUSTERICEPTEL AS TEL
	                                , dbo.MONTAJ_EKIP_LISTESI(M.ID) AS PERSONEL
                                    , dbo.MONTAJ_EKIP_ID_LISTESI(M.ID) AS PERSONELID
                                    , M.DURUM
                                FROM MONTAJ AS M
	                                INNER JOIN SIPARIS as S ON M.SIPARISNO = S.SIPARISNO
                                WHERE M.TESLIMTARIH >=@BASTAR AND M.TESLIMTARIH <=@BITTAR
                                ORDER BY M.TESLIMTARIH, S.SIPARISNO";
            data.GetRecords(dt, sqlKaydet);
            return dt;
        }

        public bool MontajGuncelle(string montajID, DateTime teslimTarihi, List<string> personelListesi, string montajDurumu)
        {
            IData data = GetDataObject();

            try
            {
                data.BeginTransaction();

                //Montaj tarihini guncelle
                data.AddSqlParameter("ID", montajID, SqlDbType.Int, 50);
                data.AddSqlParameter("TESLIMTARIH", teslimTarihi, SqlDbType.DateTime, 50);
                data.AddSqlParameter("DURUM", montajDurumu, SqlDbType.VarChar, 50);
                string sqlUpdate = @"UPDATE  MONTAJ 
                                      SET TESLIMTARIH=@TESLIMTARIH
                                          , DURUM=@DURUM
                                      WHERE ID=@ID";
                data.ExecuteStatement(sqlUpdate);

                if (personelListesi.Count > 0)
                {
                    //Montaj personelini sil
                    data.AddSqlParameter("ID", montajID, SqlDbType.Int, 50);
                    string sqlSil = @"DELETE FROM MONTAJ_PERSONEL WHERE MONTAJID=@ID";
                    data.ExecuteStatement(sqlSil);

                    //Montaj personeli ekle
                    string sqlInsert = @"INSERT INTO [dbo].[MONTAJ_PERSONEL] ([MONTAJID],[PERSONELID]) VALUES ({0} ,{1}); ";
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in personelListesi)
                    {
                        sb.Append(String.Format(sqlInsert, montajID, item));
                    }
                    data.ExecuteStatement(sb.ToString());
                }

                data.CommitTransaction();
                return true;
            }
            catch (Exception exc)
            {
                data.RollbackTransaction();
                new LogWriter().Write(AppModules.IsTakvimi, System.Diagnostics.EventLogEntryType.Error, exc, "ServerSide", "MontajGuncelle", "", null);
                return false;
            }
        }

        public DataTable MontajBilgisiGetir(string siparisNo)
        {
            DataTable dt = new DataTable();
            IData data = GetDataObject();

            data.AddSqlParameter("SIPARISNO", siparisNo, SqlDbType.VarChar, 50);

            string sqlText = @"SELECT * FROM MONTAJ WHERE SIPARISNO=@SIPARISNO";
            data.GetRecords(dt, sqlText);
            return dt;

        }

        public DataTable MontajKotaListele()
        {
            IData data = GetDataObject();
            DataTable dt = new DataTable();

            string sqlKaydet = @"SELECT 
                                     ROW_NUMBER() OVER(ORDER BY MONTAJTARIHI DESC) AS ID
                                      , ID AS MONTAJKOTAID
                                      ,CONVERT(VARCHAR(10), [MONTAJTARIHI],104) AS [MONTAJTARIHI]
                                      ,[MAXMONTAJSAYI]
                                      ,CASE WHEN MONTAJKABUL = 0 THEN 'KAPALI' ELSE 'AÇIK' END AS MONTAJKABUL
                                  FROM [ACKAppDB].[dbo].[MONTAJKOTA]
                                ORDER BY MONTAJTARIHI DESC, MAXMONTAJSAYI, MONTAJKABUL";
            data.GetRecords(dt, sqlKaydet);
            return dt;
        }

        public bool MontajKotaKaydet(DateTime dtMontaj, int montajKota, bool montajKabul)
        {
            DataTable dtKotaToplam = GünlükMontajKotaBilgisiGetir(dtMontaj);
            if (dtKotaToplam.Rows.Count > 0)
                return false;

            IData data = GetDataObject();

            data.AddSqlParameter("MONTAJTARIHI", dtMontaj, SqlDbType.DateTime, 50);
            data.AddSqlParameter("MONTAJKOTA", montajKota, SqlDbType.Int, 50);
            data.AddSqlParameter("MONTAJKABUL", montajKabul, SqlDbType.Bit, 50);

            string sqlInsert = @"INSERT INTO [ACKAppDB].[dbo].[MONTAJKOTA]
                                               ([MONTAJTARIHI]
                                               ,[MAXMONTAJSAYI]
                                               ,[MONTAJKABUL])
                                         VALUES(@MONTAJTARIHI,@MONTAJKOTA,@MONTAJKABUL)";
            data.ExecuteStatement(sqlInsert);

            return true;
        }

        public int GünlükMontajSayisiniGetir(DateTime dt)
        {
            IData data = GetDataObject();
            data.AddSqlParameter("TESLIMTARIH", dt.ToShortDateString(), SqlDbType.DateTime, 50);

            string sqlInsert = @"SELECT COUNT(*) AS SAYI
                                  FROM [ACKAppDB].[dbo].[MONTAJ]
                                  WHERE TESLIMTARIH = @TESLIMTARIH";

            return Convert.ToInt32(data.ExecuteScalar(sqlInsert, CommandType.Text));
        }

        public DataTable GünlükMontajKotaBilgisiGetir(DateTime dtMontajTarihi)
        {
            IData data = GetDataObject();
            DataTable dt = new DataTable();

            data.AddSqlParameter("MONTAJTARIHI", dtMontajTarihi.ToShortDateString(), SqlDbType.DateTime, 50);
            string sqlInsert = @"SELECT 
                                  [ID]
                                  ,[MONTAJTARIHI]
                                  ,[MAXMONTAJSAYI]
                                  ,[MONTAJKABUL]
                              FROM [ACKAppDB].[dbo].[MONTAJKOTA]
                              WHERE [MONTAJTARIHI] = @MONTAJTARIHI";

            data.GetRecords(dt, sqlInsert);
            return dt;
        }

        public bool MontajKotaSil(string p)
        {
            IData data = GetDataObject();
            data.AddSqlParameter("ID", p, SqlDbType.Int, 50);

            string sqlInsert = @"DELETE FROM [ACKAppDB].[dbo].[MONTAJKOTA]
                                 WHERE ID= @ID";

            data.ExecuteStatement(sqlInsert);
            return true;
        }
    }
}
