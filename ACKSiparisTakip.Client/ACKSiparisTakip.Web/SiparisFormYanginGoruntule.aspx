﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ACKMasterPage.Master" AutoEventWireup="true" CodeBehind="SiparisFormYanginGoruntule.aspx.cs" Inherits="ACKSiparisTakip.Web.SiparisFormYanginGoruntule" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="divSiparisForm" runat="server" style="width: 100%" class="RadGrid_Current_Theme">
        <br />
        <table class="AnaTablo" style="width: 100%">
            <tr>
                <td rowspan="6" style="text-align: center">
                    <telerik:RadBinaryImage ID="imgLogo" runat="server" ImageUrl="~/App_Themes/Theme/Raster/ackLogo.PNG" />
                </td>
                <td colspan="2" rowspan="3" style="width: 45%; font-size: x-large; text-align: center;">

                    <b>
                        <asp:Label ID="lblKapiTur" runat="server"></asp:Label></b>
                </td>
                <td style="width: 30%; text-align: left">
                    <b>ANKARA ÇELİK KAPI SAN. TİC. LTD. ŞTİ. </b>
                </td>
            </tr>
            <tr>

                <td style="font-size: smaller; text-align: left">
                    <b>Adres: </b>Alınteri Bulvarı No:212 Ostim/ANKARA
                </td>
            </tr>
            <tr>
                <td style="font-size: smaller; text-align: left">
                    <b>Telefon: </b>(0 312) 385 37 83 - 84
                </td>

            </tr>
            <tr>
                <td colspan="2" rowspan="3" style="font-size: x-large; text-align: center">
                    <b>SİPARİŞ FORMU</b>
                </td>
                <td style="font-size: smaller; text-align: left">
                    <b>Faks : </b>(0 312) 354 61 81
                </td>

            </tr>
            <tr>
                <td style="font-size: smaller; text-align: left">
                    <b>Web : </b>www.ankaracelikkapi.com.tr
                </td>

            </tr>
            <tr>
                <td style="font-size: smaller; text-align: left">
                    <b>e-posta : </b>ankara@celikkapi.net
                </td>

            </tr>

        </table>
        <br />
        <table class="AnaTablo" style="width: 100%">
            <tr>
                <th style="width: 15%">Ölçü Tarihi:   </th>
                <td style="width: 35%">
                    <asp:Label ID="lblOlcuTarihSaat" runat="server"></asp:Label>
                </td>
                <th style="width: 10%">Sipariş Tarihi :  </th>
                <td>
                    <asp:Label ID="lblSiparisTarih" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>Bayi Adı : </th>
                <td>
                    <asp:Label ID="lblBayiAdi" runat="server"></asp:Label>
                </td>
                <th>Sipariş No : </th>
                <td>
                    <asp:Label ID="lblSiparisNo" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2"></td>
                <th>Sipariş Durumu : </th>
                <td>
                    <asp:Label ID="lblSiparisDurum" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <table class="AnaTablo" style="width: 100%">
            <tr>
                <th colspan="4">MÜŞTERİ/FİRMA BİLGİLERİ </th>
            </tr>
            <tr>
                <th style="width: 15%">Firma Adı:
                </th>
                <td style="width: 35%">
                    <asp:Label ID="lblFirmaAdi" runat="server"></asp:Label>
                </td>
                <th style="width: 10%">Sipariş Adedi: </th>
                <td>
                    <asp:Label ID="lblSiparisAdedi" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>Adı : </th>
                <td>
                    <asp:Label ID="lblAd" runat="server"></asp:Label>
                </td>
                <th style="width: 10%">Soyadı </th>
                <td>
                    <asp:Label ID="lblSoyad" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th rowspan="3">Adresi : </th>
                <td rowspan="3">
                    <table>
                        <tr>
                            <td colspan="4">
                                <asp:Label ID="lblAdres" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <th>Ev Tel : </th>
                <td>
                    <asp:Label ID="lblEvTel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>iş Tel : </th>
                <td>
                    <asp:Label ID="lblIsTel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>Cep Tel : </th>
                <td>
                    <asp:Label ID="lblCepTel" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <table class="AnaTablo" style="width: 100%">
            <tr>

                <th style="width: 15%">Dış Kapı Modeli :</th>
                <td style="width: 35%">
                    <asp:Label ID="lblDisKapiModeli" runat="server"></asp:Label>
                </td>
                <th>Kapı Cinsi :</th>
                <td>
                    <asp:Label ID="lblYanginKapiCins" runat="server"></asp:Label>
                </td>

            </tr>
            <tr>
                <th style="width: 10%">İç Kapı Modeli :</th>
                <td>
                    <asp:Label ID="lblIcKapiModeli" runat="server"></asp:Label>
                </td>

                <th>Kasa Tipi :</th>
                <td>
                    <asp:Label ID="lblYanginKasaTipi" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>Metal Rengi :</th>
                <td>
                    <asp:Label ID="lblYanginMetalRengi" runat="server"></asp:Label>
                </td>
                <th>Eşik :</th>
                <td>
                    <asp:Label ID="lblEsik" runat="server"></asp:Label>
                </td>

            </tr>
            <tr>
                <th>Kilit Sistemi :</th>
                <td>
                    <asp:Label ID="lblKilitSistemi" runat="server"></asp:Label>
                </td>
                <th>Çekme Kolu :</th>
                <td>
                    <asp:Label ID="lblCekmeKolu" runat="server"></asp:Label>
                </td>
            </tr>
            <tr id="trYangin1" runat="server" visible="false">
                <th>Panik Bar :</th>
                <td>
                    <asp:Label ID="lblYanginPanikBar" runat="server"></asp:Label>
                </td>
                <th>Kol ve Dış Müdahale Kolu :</th>
                <td>
                    <asp:Label ID="lblYanginKol" runat="server"></asp:Label>
                </td>
            </tr>
            <tr id="trYangin2" runat="server" visible="false">
                <th>Menteşe Tipi :</th>
                <td>
                    <asp:Label ID="lblYanginMenteseTip" runat="server"></asp:Label>
                </td>
                <th>Hidrolik Kapatıcı :</th>
                <td>
                    <asp:Label ID="ddlYanginHidrolikKapatici" runat="server"></asp:Label>
                </td>
            </tr>
            <tr id="trPorte1" runat="server" visible="false">
                <th>Cumba :</th>
                <td>
                    <asp:Label ID="lblCumba" runat="server"></asp:Label>
                </td>
                <th>Dürbün :</th>
                <td>
                    <asp:Label ID="lblDurbun" runat="server"> </asp:Label>

                </td>
            </tr>
            <tr id="trPorte2" runat="server" visible="false">
                <th>Barel :</th>
                <td>
                    <asp:Label ID="lblBarelTipi" runat="server"></asp:Label>
                </td>
                <th>Taktak :</th>
                <td>
                    <asp:Label ID="lblTaktak" runat="server"></asp:Label>
                </td>
            </tr>

        </table>
        <br />
        <table class="AnaTablo" style="width: 100%">
            <tr>
                <td rowspan="6" colspan="2" style="width: 30%">
                    <telerik:RadBinaryImage ID="RadBinaryImage1" runat="server" ImageUrl="~/App_Themes/Theme/Raster/olcu1.png" />
                </td>
                <th colspan="2" style="text-align: center">ÖLÇÜM ve MONTAJ</th>
            </tr>
            <tr>
                <th style="width: 15%">Üretim Notları :</th>
                <td>
                    <asp:Label ID="lblOlcumBilgileri" runat="server" Width="400px" TextMode=""></asp:Label>
                </td>
            </tr>
            <tr>
                <th>Ölçümü Alan Kişi : </th>
                <td>
                    <asp:Label ID="lblOlcumAlan" runat="server"></asp:Label>
                </td>

            </tr>
            <tr>
                <th>Montaj Şekli </th>
                <td>
                    <asp:Label ID="lblMontajSekli" runat="server"></asp:Label>
                </td>

            </tr>
            <tr>
                <th>Teslim Şekli </th>
                <td>
                    <asp:Label ID="lblTeslimSekli" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <th>Teslim Tarihi</th>
                <td>
                    <asp:Label ID="lblTeslimTarihi" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td rowspan="3">
                    <telerik:RadBinaryImage ID="RadBinaryImage2" runat="server" ImageUrl="~/App_Themes/Theme/Raster/olcu2.png" />
                </td>
                <td rowspan="3">Dış kasanın altı,iç pervazın altından ....... mm kısa/uzun
                </td>
                <th>Standart Ölçü: </th>
                <td>
                    <asp:Label ID="lblStandartOlcu" runat="server"></asp:Label>
                </td>
            </tr>
            <%-- <tr>
                <th>En: </th>
                <td>
                    <asp:Label ID="RadTextBox1" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr>
                <th>Boy: </th>
                <td>
                    <asp:Label ID="RadTextBox2" runat="server" ></asp:Label>
                </td>
            </tr>--%>
        </table>
        <br />
        <table class="AnaTablo" style="width: 100%">
            <tr>
                <th>NOT
                </th>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblNot" runat="server"></asp:Label>
                </td>
            </tr>

        </table>
        <br />
        <table class="AnaTablo" runat="server" id="tbMusteriSozlesme" style="width: 100%">
            <tr>
                <th colspan="2" style="text-align: center; font-size: large;">MÜŞTERİ SÖZLEŞMESİ </th>
            </tr>
            <tr>
                <td style="width: 45%">
                    <table>
                        <tr>
                            <th style="width: 15%">Adı Soyadı : </th>
                            <td style="width: 35%">
                                <asp:Label ID="lblMusteriAdSoyad" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>Adresi : </th>
                            <td>
                                <asp:Label ID="lblMusteriAdres" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>Cep Tel : </th>
                            <td>
                                <asp:Label ID="lblMusteriCepTel" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>Fiyat : </th>
                            <td>
                                <asp:Label ID="lblFiyat" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>Vergi Dairesi : </th>
                            <td>
                                <asp:Label ID="lblVergiDairesi" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>Vergi Numarası : </th>
                            <td>
                                <asp:Label ID="lblVergiNumarasi" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="text-align: left">
                    <table>
                        <tr>
                            <td></td>
                            <th style="text-align: center">Peşin</th>
                            <th style="text-align: center">Kalan</th>
                            <th style="text-align: center">Ödeme Notu</th>
                        </tr>
                        <tr>
                            <th>Nakit:</th>
                            <td>
                                <asp:Label ID="lblNakitPesin" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblNakitKalan" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblNakitOdemeNotu" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>Kredi Kartı:</th>
                            <td>
                                <asp:Label ID="lblKKartiPesin" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblKKartiKalan" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblKKartiOdemeNotu" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>Çek:</th>
                            <td>
                                <asp:Label ID="lblCekPesin" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblCekKalan" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblCekOdemeNotu" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="4">Yukarıda yazılı olan şartlarda sipariş verdim. İhtilaf halinde Ankara Mahkemeleri yetkilidir.
                    <b>Müşteri tarafından aksi yazılı olarak Ankara Çelik Kapı'ya bildirilmedikçe kapıların ölçüleri ve
                    açılış yönleri mevcut takılı olan kapıya göre imal edilecektir.</b>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <b>MÜŞTERİ
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                       SİPARİŞ ALAN YETKİLİ</b>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center">
                    <br />
                    <telerik:RadButton ID="btnGuncelle" runat="server" Text="Güncelle" OnClick="btnGuncelle_Click">
                        <Icon PrimaryIconCssClass="rbOk" PrimaryIconLeft="4" PrimaryIconTop="3" />
                    </telerik:RadButton>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <telerik:RadButton ID="btnYazdir" runat="server" Text="Yazdır">
                        <Icon PrimaryIconCssClass="rbPrint" PrimaryIconLeft="4" PrimaryIconTop="3" />
                    </telerik:RadButton>
                </td>
            </tr>
        </table>
        <br />

    </div>
</asp:Content>