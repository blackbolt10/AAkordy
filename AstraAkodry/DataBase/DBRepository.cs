using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AstraAkodry
{
    class DBRepository
    {
        public static SqlConnection DBConnection = null;
        public static SqlConnection DBConnectionThread;
        private int Timeout = 240;

        /*public DBRepository(Boolean connect)
        {
            DBConnection = null;
            ConnectDataBase();
        }
        */
        public DBRepository()
        {
            if(DBConnection == null)
            {
                string result = "";
                ConnectDataBase(ref result);
            }
        }

        public DBRepository(Int32 StartThreadConnection)
        {
            if(DBConnectionThread == null)
            {
                ConnectDataBaseThread();
            }
        }

        public Boolean ConnectDataBase(ref String result)
        {
            Boolean connectionResult = false;
            Passwords passwords = new Passwords();

            try
            {
                String DBLogin = passwords.GetInstanceUserName();
                String DBPassword = passwords.GetInstancePassword();
                String DBInstance = passwords.GetInstanceName();
                String DBName = passwords.GetDataBaseName();

                DBConnection = new SqlConnection(@"user id=" + DBLogin + "; password=" + DBPassword + "; Data Source=" + DBInstance + "; Initial Catalog=" + DBName + ";");
                DBConnection.Open();
                connectionResult = true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
            }

            return connectionResult;
        }

        public bool AkordyTestoweChangeForm_AddAkord(string nazwa, string archiwalny, ref string result)
        {
            String zapytanieString = "insert into GAL_AkordyTestowe values((select isnull(max(AKT_AkrID),0)+1 from GAL_AkordyTestowe), '" + nazwa + "', '" + DateTime.Now.ToString() + "'," + archiwalny + ")";
            try
            {
                query(zapytanieString);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("AkordyTestoweChangeForm_AddAkord()", exc.Message);
                return false;
            }
        }

        public bool ReindeksacjaForm_StartReindex(ref string result)
        {
            String zapytanie = "USE [master] exec dbo.proc_reindex Astra_Akordy, 5 USE [Astra_Akordy]";

            try
            {
                DataTable dt = query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("ReindeksacjaForm_StartReindex", result);
                return false;
            }
        }

        public bool RaportDziennyForm_ZaladujAkordyCB(ref DataTable akordyDT, ref string result)
        {
            String zapytanie = "Select 0 as AKT_AkrId, 'Wszyscy' as AKT_Nazwa union select AKT_AkrId, AKT_Nazwa from GAL_AkordyTestowe where AKT_Archiwalny <> 1";

            try
            {
                akordyDT = query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("RaportDziennyForm_ZaladujAkordyCB()", result);
                return false;
            }
        }

        public bool RaportDziennyForm_ZaladujRaportDGV(String akr_AkrId, string data, ref DataTable pomDataTable, ref string result)
        {
            String zapytanie = "select Pra_Imie as Imię, PRA_Nazwisko as Nazwisko, AKT_Nazwa as [Nazwa akordu], WAT_Wartosc as Wartość, WAT_Czas as Czas from GAL_WartAkorduTestowego left join GAL_AkordyTestowe on WAT_AkrId = AKT_AkrId left join GAL_Pracownicy on PRA_PracId = WAT_PracId where WAT_datawykonania = '"+data+"'";

            if(akr_AkrId != "0")
            {
                zapytanie += " and AKT_AkrId = " + akr_AkrId;
            }

            try
            {
                pomDataTable = query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("RaportDziennyForm_ZaladujRaportDGV()", result);
                return false;
            }
        }

        public bool ZarzadzanieTestowymiForm_ZaladujAkordyDGV(ref DataTable pomDataTable, bool @checked, ref string result)
        {
            String zapytanie = "SELECT * FROM GAL_AkordyTestowe";
            if(!@checked)
            {
                zapytanie += " where AKT_Archiwalny <> 1";
            }

            try
            {
                pomDataTable = query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("ZarzadzanieTestowymiForm_ZaladujAkordyDGV()", result);
                return false;
            }
        }

        public bool AkordyTestoweChangeForm_ChangeAkord(string AKR_AkrId, string nazwa, string archiwalny, ref string result)
        {
            String zapytanieString = "UPDATE [dbo].[GAL_AkordyTestowe] SET [AKT_Nazwa] = '" + nazwa + "',[AKT_Archiwalny] = " + archiwalny + " WHERE AKT_AkrId = " + AKR_AkrId;
            try
            {
                query(zapytanieString);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("AkordyTestoweChangeForm_ChangeAkord()", exc.Message);
                return false;
            }
        }

        public bool NieaktywPracForm_ZaladujRaportDGV(ref DataTable pomDataTable, ref string result)
        {
            String zapytanie = "select * from(SELECT distinct(WAK_PracId), pra_imie, pra_nazwisko, max(wak_datawykonania) as [Ostatnia data] FROM[dbo].GAL_WartAkordu left join[dbo].Gal_Pracownicy on wak_pracId = Pra_PracId where pra_archiwalny <> 1 group by wak_pracid, pra_imie, pra_nazwisko) as A";
            
            try
            {
                DateTime data = new DateTime();
                if(!GetServerTime(ref data))
                {
                    return false;
                }
                data = data.AddMonths(-6);

                zapytanie += " where [Ostatnia data] < '"+data.ToShortDateString()+"'";

                pomDataTable = query(zapytanie);

                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("NieaktywPracForm_ZaladujRaportDGV", result);
                return false;
            }
        }

        public bool RaportTestoweForm_ZaladujRaportDGV(String dataPocz, String dataKon, ref DataTable pomDataTable, ref string result)
        {
            String zapytanie = "select WAT_AkrId, AKT_Nazwa as Nazwa, ROUND(SUM(WAT_Wartosc),2) AS [Wartość], ROUND(SUM(WAT_Czas),2) as [Czas] from GAL_WartAkorduTestowego left join GAL_AkordyTestowe on WAT_AkrId = AKT_AkrId where WAT_datawykonania between '" + dataPocz+"' and '"+dataKon+ "' and AKT_Archiwalny <> 1 group by WAT_AkrId, AKT_Nazwa";
            try
            {
                pomDataTable = query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("RaportTestoweForm_ZaladujRaportDGV", result);
                return false;
            }
        }

        public bool NieaktywPracForm_UsunPracownika(String PracID, ref string result)
        {
            String zapytanie = "UPDATE [dbo].[GAL_Pracownicy] SET [PRA_Archiwalny] = 1 WHERE PRA_PracId =" + PracID;
            try
            {
                query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("NieaktywPracForm_UsunPracownika", result);
                return false;
            }
        }

        public bool MainForm_ZaladujCzcionke(ref string nazwa, ref string rozmiar, ref string result)
        {
            String zapytanie = "SELECT TOP 1 * from GAL_Parametry where PAR_PracID = "+MainForm.IDOperatora+" and PAR_Nazwa = 'CzcionkaNazwa' order by PAR_DataDodania desc";
            try
            {
                DataTable pomDataTable = query(zapytanie);
                if(pomDataTable.Rows.Count > 0)
                {
                    nazwa = pomDataTable.Rows[0]["PAR_Wartosc"].ToString();
                }
                else
                {
                    nazwa = "Microsoft Sans Serif";
                }

                zapytanie = "SELECT TOP 1 * from GAL_Parametry where PAR_PracID = " + MainForm.IDOperatora + " and PAR_Nazwa = 'CzcionkaRozmiar' order by PAR_DataDodania desc";
                pomDataTable = query(zapytanie);
                if(pomDataTable.Rows.Count > 0)
                {
                    rozmiar = pomDataTable.Rows[0]["PAR_Wartosc"].ToString();
                }
                else
                {
                    rozmiar = "10";
                }

                return true;
            }
            catch(Exception exc)
            {
                nazwa = "Microsoft Sans Serif";
                rozmiar = "10";

                result = exc.Message;
                ErrorReport("MainForm_ZaladujCzcionke()", result);
                return false;
            }
        }

        public bool RaportRecepcjaForm_ZaladujListeAkordow(ref DataTable pomDataTable, ref string result)
        {
            String zapytanie = "select a.akr_akrid, b.akr_nazwa, b.akr_norma, b.akr_archiwalny from (select akr_akrid,  max(akr_datadodania) akr_datadodania from GAL_Akordy where AKR_Archiwalny <> 1 group by akr_akrid) as A left outer join dbo.GAL_Akordy as B on a.AKR_AkrId=b.akr_akrid and a.akr_datadodania=b.akr_datadodania";
            try
            {
                pomDataTable = query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("RaportRecepcjaForm_ZaladujListeAkordow()", result);
                return false;
            }
        }

        public bool RaportyGlobalneksiegowoscForm_ZaladujRaportGlobalny(DateTime kalendarzSelectedDate, ref DataTable pomDataTable, ref string result)
        {
            DateTime dataPoczatkowa = new DateTime(kalendarzSelectedDate.Year, kalendarzSelectedDate.Month, 01, 00, 00, 00);
            DateTime dataKoncowa = new DateTime(kalendarzSelectedDate.Year, kalendarzSelectedDate.Month, DateTime.DaysInMonth(kalendarzSelectedDate.Year, kalendarzSelectedDate.Month), 23, 59, 59);

            String zapytanie = "select PRA_PracId, PRA_Nazwisko Nazwisko, PRA_Imie [Imię], round(h.wykonanie,2) [Wykonanie w %], round(wypłata_zlecenie,2) [Wypłata-Zlecenie] from dbo.GAL_Pracownicy as G inner join (select c.wak_pracid, sum(case when f.czas = 0 then 0 else c.Praca/f.czas*100 end) as Wykonanie from (select a.wak_pracid , a.wak_datawykonania, sum(b.wak_wartosc/b.WAK_WartoscNormy*8) Praca from ( select wak_pracid, wak_akrid, wak_datawykonania, max(wak_datamodyfikacji) wak_datamodyfikacji from dbo.GAL_WartAkordu where wak_datawykonania >= '" + dataPoczatkowa + "' and wak_datawykonania <= '" + dataKoncowa + "' and WAK_AkrId<>0 group by wak_pracid, wak_akrid, wak_datawykonania ) as A left outer join dbo.GAL_WartAkordu as B on a.wak_pracid=b.wak_pracid and a.wak_akrid=b.wak_akrid and  a.wak_datawykonania=b.wak_datawykonania and a.wak_datamodyfikacji=b.WAK_DataModyfikacji group by a.wak_pracid, a.wak_datawykonania ) as C left outer join (select d.wak_pracid,  sum(e.wak_wartosc) as czas from ( select wak_pracid, wak_akrid, wak_datawykonania, max(wak_datamodyfikacji) wak_datamodyfikacji from dbo.GAL_WartAkordu where wak_datawykonania >= '" + dataPoczatkowa + "' and wak_datawykonania <= '" + dataKoncowa + "' and WAK_AkrId=0 group by wak_pracid, wak_akrid, wak_datawykonania )  as d left outer join dbo.GAL_WartAkordu as E on d.wak_pracid=e.wak_pracid and d.wak_akrid=e.wak_akrid and  d.wak_datawykonania=e.wak_datawykonania and d.wak_datamodyfikacji=e.WAK_DataModyfikacji group by d.WAK_PracId)  as F on c.WAK_PracId=F.WAK_PracId group by c.WAK_PracId) as H on g.PRA_PracId=h.WAK_PracId join (select c.WAK_PracId, sum(zlecenie) Wypłata_zlecenie from (select a.WAK_PracId, (select AKC_Cena from GAL_AkordyCena where a.WAK_AkrId=AKC_AkrId) * b.WAK_Wartosc Zlecenie from (select wak_pracid, wak_akrid, wak_datawykonania, max(wak_datamodyfikacji) wak_datamodyfikacji from dbo.GAL_WartAkordu where wak_datawykonania >= '" + dataPoczatkowa + "' and wak_datawykonania <= '" + dataKoncowa + "' and WAK_AkrId<>0 group by wak_pracid, wak_akrid, wak_datawykonania) as A left outer join dbo.GAL_WartAkordu as B on a.wak_pracid=b.wak_pracid and a.wak_akrid=b.wak_akrid and  a.wak_datawykonania=b.wak_datawykonania and a.wak_datamodyfikacji=b.WAK_DataModyfikacji ) as C group by c.WAK_PracId) as J on h.wak_pracid=j.wak_pracid order by Nazwisko";
            try
            {
                pomDataTable = query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("RaportyGlobalneksiegowoscForm_ZaladujRaportGlobalny()", result);
                return false;
            }
        }

        public bool WprowadzanieAkordowTestowychForm_ZaladujListeAkordow(string idPracownika, DateTime dataKalendarz, DateTime dataKalendarzZero, ref DataTable pomDataTable, ref string result)
        {
            String zapytanie = "select ab.WAT_WatId, D.AKT_AkrId, E.akt_nazwa, ab.wat_Wartosc as Wartość, ab.wat_czas as Czas from (select AKT_AkrId, max(AKT_DataDodania) akt_datadodania from dbo.GAL_AkordyTestowe where AKT_DataDodania < '" + dataKalendarz+"' group by AKT_AkrId) as D left outer join dbo.GAL_AkordyTestowe as E on D.AKT_AkrId = E.akt_akrid and D.akt_datadodania = E.akt_datadodania left outer join(select A.wat_pracid, a.wat_akrid, a.wat_datawykonania, b.wat_watid, b.wat_wartosc, b.wat_czas from (select wat_pracid, wat_akrid, wat_datawykonania, max(wat_datamodyfikacji) wat_datamodyfikacji from dbo.GAL_WartAkorduTestowego group by wat_pracid, wat_akrid, wat_datawykonania) as A left outer join dbo.GAL_WartAkorduTestowego as B on a.wat_pracid = b.wat_PracId and a.wat_AkrId = b.wat_akrid and a.wat_datawykonania = b.wat_datawykonania and a.wat_datamodyfikacji = b.wat_DataModyfikacji where a.wat_pracid = "+idPracownika+" and a.wat_datawykonania = '"+dataKalendarzZero+"') as AB on d.AKT_AkrId = ab.wat_AkrId where AKt_Archiwalny <> 1 order by d.AKT_AkrId";
            try
            {
                pomDataTable = query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("WprowadzanieAkordowForm_ZaladujListeAkordow()", result);
                return false;
            }
        }

        public bool WprowadzanieAkordowForm_ZaladujListeAkordow(string idPracownika, DateTime dataKalendarz, DateTime dataKalendarzZero, ref DataTable pomDataTable, ref string result)
        {
            String zapytanie = "select D.akr_akrid, E.akr_nazwa, ab.WAK_Wartosc as Wartość from (select akr_akrid,  max(akr_datadodania) akr_datadodania from dbo.gal_Akordy where akr_datadodania < '" + dataKalendarz + "' group by akr_akrid ) as D  left outer join dbo.GAL_Akordy as E on D.AKR_AkrId=E.akr_akrid and D.akr_datadodania=E.akr_datadodania left outer join (select A.wak_pracid, a.wak_akrid, a.wak_datawykonania, b.Wak_wakid, b.wak_wartosc from (select wak_pracid, wak_akrid, wak_datawykonania, max(wak_datamodyfikacji) Wak_datamodyfikacji from dbo.gal_wartakordu group by wak_pracid, wak_akrid, wak_datawykonania) as A left outer join dbo.GAL_WartAkordu as B on a.wak_pracid=b.WAK_PracId and a.WAK_AkrId=b.wak_akrid and a.wak_datawykonania=b.wak_datawykonania and a.wak_datamodyfikacji=b.WAK_DataModyfikacji where a.wak_pracid=" + idPracownika + " and a.WAK_datawykonania='" + dataKalendarzZero + "') as AB on d.AKR_AkrId=ab.WAK_AkrId where  AKR_Archiwalny <> 1 order by d.AKR_AkrId";
            try
            {
                pomDataTable = query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("WprowadzanieAkordowForm_ZaladujListeAkordow()", result);
                return false;
            }
        }

        public bool UstawieniaForm_ZapiszCzcionke(string name, float size, ref string result)
        {
            try
            {
                String zapytanie = "INSERT INTO GAL_Parametry VALUES ("+MainForm.IDOperatora+", 'CzcionkaNazwa', '"+name+"', getdate())";
                query(zapytanie);

                zapytanie = "INSERT INTO GAL_Parametry VALUES (" + MainForm.IDOperatora + ", 'CzcionkaRozmiar', '" + size.ToString() + "', getdate())";
                query(zapytanie);

                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("RaportyGlobalneProdukcjaForm_ZaladujRaportPonizejNormy()", result);
                return false;
            }
        }

        public bool RaportyGlobalneProdukcjaForm_ZaladujRaportPonizejNormy(String dataPocz, String dataKon, ref DataTable pomDataTable, ref string result)
        {
            String zapytanie = "select PRA_PracId, PRA_Nazwisko Nazwisko, PRA_Imie [Imię], h.wykonanie [Wykonanie w %] from dbo.GAL_Pracownicy as G inner join (select c.wak_pracid , round(sum(case when f.czas = 0 then 0 else c.Praca/f.czas*100 end),2) as Wykonanie	from (select a.wak_pracid, a.wak_datawykonania, sum(b.wak_wartosc/b.WAK_WartoscNormy*8) Praca from (select wak_pracid, wak_akrid, wak_datawykonania, max(wak_datamodyfikacji) wak_datamodyfikacji from dbo.GAL_WartAkordu where wak_datawykonania >= '" + dataPocz + "' and wak_datawykonania <= '" + dataKon + "' and WAK_AkrId<>0 group by wak_pracid, wak_akrid, wak_datawykonania) as A left outer join dbo.GAL_WartAkordu as B on a.wak_pracid=b.wak_pracid and a.wak_akrid=b.wak_akrid and  a.wak_datawykonania=b.wak_datawykonania and a.wak_datamodyfikacji=b.WAK_DataModyfikacji group by a.wak_pracid, a.wak_datawykonania) as C left outer join (select d.wak_pracid,  sum(e.wak_wartosc) as czas from (select wak_pracid, wak_akrid, wak_datawykonania, max(wak_datamodyfikacji) wak_datamodyfikacji from dbo.GAL_WartAkordu where wak_datawykonania >= '" + dataPocz + "' and wak_datawykonania <= '" + dataKon + "' and WAK_AkrId=0 group by wak_pracid, wak_akrid, wak_datawykonania)  as d left outer join dbo.GAL_WartAkordu as E on d.wak_pracid=e.wak_pracid and d.wak_akrid=e.wak_akrid and  d.wak_datawykonania=e.wak_datawykonania and d.wak_datamodyfikacji=e.WAK_DataModyfikacji group by d.WAK_PracId)  as F on c.WAK_PracId=F.WAK_PracId group by c.WAK_PracId) as H on g.PRA_PracId=h.WAK_PracId where h.wykonanie <100 order by Nazwisko, [Imię]";
            try
            {
                pomDataTable = query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("RaportyGlobalneProdukcjaForm_ZaladujRaportPonizejNormy()", result);
                return false;
            }
        }

        public bool RaportyPracownikaKsiegowoscForm_RaportPoprawek(string idPracownika, string dataPoczatkowa, string dataKoncowa, ref DataTable pomDataTable, ref string result)
        {
            String zapytanie = "select (select pra_nazwisko+' '+pra_imie from dbo.gal_Pracownicy where a.WAK_PracId=pra_pracid) Pracownik, (select top(1) akr_nazwa from dbo.GAL_Akordy where AKR_AkrId=a.WAK_AkrId and AKR_DataDodania<=a.WAK_datawykonania order by AKR_Id desc) [Nazwa Akordu] , a.WAK_datawykonania Data	, b.WAK_DataModyfikacji [Data zapisu]	, b.wak_wartosc [Wartość akordu]	, (select opr_nazwisko+' '+opr_imie from dbo.GAL_Operatorzy where b.WAK_OprId=opr_oprid) [Wprowadził(a)] from (select WAK_pracid, wak_akrid, WAK_datawykonania, count(1)-1 IlośćModyfikacji from dbo.GAL_WartAkordu as A group by WAK_pracid, wak_akrid, WAK_datawykonania having count(1) >1  ) as A inner join dbo.gal_wartakordu as B on a.wak_pracid=b.wak_pracid and a.wak_akrid=b.wak_akrid and a.wak_datawykonania=b.wak_datawykonania where a.WAK_datawykonania >= '" + dataPoczatkowa + "' and a.WAK_datawykonania <= '" + dataKoncowa + "' order by 1, 2, 3 asc, 4 desc";
            try
            {
                pomDataTable = query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("RaportyPracownikaKsiegowoscForm_RaportPoprawek()", result);
                return false;
            }
        }

        public bool WprowadzanieAkordowForm_ZapiszNowyAkord(String IdPracownika, int IdAkordu, double wartoscAkr, DateTime dataKalendarz, ref string result)
        {
            String zapytanie = "insert into GAL_WartAkordu values(" + MainForm.IDOperatora + ", " + IdPracownika + ", " + IdAkordu + ", '" + dataKalendarz + "', getdate(), " + wartoscAkr.ToString().Replace(',','.') + ", (select top 1 akr_norma from dbo.GAL_Akordy where akr_akrid=" + IdAkordu + " and not (AKR_DataDodania > '" + dataKalendarz + "' )))";
            try
            {
                query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("WprowadzanieAkordowForm_ZapiszNowyAkord()", result);
                return false;
            }
        }

        public bool WprowadzanieAkordowTestowychForm_ZapiszNowyAkord(string idWiersza, string idPracownika, int idAkordu, double wartoscAkr, double czasAkr, DateTime dataKalendarz, ref string result)
        {
            String zapytanie = "";
            if(idWiersza == "")
            {
                zapytanie = "insert into GAL_WartAkorduTestowego values(" + MainForm.IDOperatora + ", " + idPracownika + ", " + idAkordu + ", '" + dataKalendarz + "', getdate(), " + wartoscAkr.ToString().Replace(',', '.') + ", " + czasAkr.ToString().Replace(',', '.') + ")";
            }
            else
            {
                zapytanie = "UPDATE [dbo].[GAL_WartAkorduTestowego] SET [WAT_DataModyfikacji] = getdate(), [WAT_Wartosc] =  " + wartoscAkr.ToString().Replace(',', '.') + ", [WAT_Czas] = " + czasAkr.ToString().Replace(',', '.') + " WHERE WAT_WatId = "+ idWiersza;
            }

            try
            {
                query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("WprowadzanieAkordowTestowychForm_ZapiszNowyAkord()", result);
                return false;
            }
        }

        public bool RaportyPracownikaKsiegowoscForm_RaportSzczegolowy(string idPracownika, string dataPoczatkowa, string dataKoncowa, ref DataTable pomDataTable, ref string result)
        {
            String zapytanie = "select (select opr_nazwisko+' '+opr_imie from dbo.GAL_Operatorzy where a.WAK_OprId=opr_oprid) [Wprowadził(a)], a.wak_datawykonania Data, (select top(1) akr_nazwa from dbo.GAL_Akordy where AKR_AkrId=a.WAK_AkrId and AKR_DataDodania<=a.WAK_datawykonania order by AKR_Id desc) [Nazwa Akordu] ,a.WAK_Wartosc [Wartość akordu] from dbo.GAL_WartAkordu as A where WAK_PracId=" + idPracownika + " and wak_datawykonania >= '" + dataPoczatkowa + "' and wak_datawykonania <= '" + dataKoncowa + "'";
            try
            {
                pomDataTable = query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("RaportyPracownikaKsiegowoscForm_RaportSzczegolowy()", result);
                return false;
            }
        }

        public bool RaportyPracownikaKsiegowoscForm_RaportLeni(string dataPoczatkowa, string dataKoncowa, ref DataTable pomDataTable, ref string result)
        {
            String zapytanie = "SELECT (select pra_nazwisko+' '+pra_imie from dbo.gal_Pracownicy where E.WAK_PracId=pra_pracid) Pracownik , E.WAK_datawykonania Data FROM  (select A.WAK_PracId, a.WAK_datawykonania, B.WAK_Wartosc from  (select WAK_PracId, WAK_AkrId, WAK_datawykonania, MAX(WAK_DataModyfikacji) Modyfikacja from gal_wartakordu group by WAK_PracId, WAK_AkrId, WAK_datawykonania) as A left outer join GAL_WartAkordu as B on A.WAK_PracId=B.WAK_PracId and A.WAK_datawykonania=B.WAK_datawykonania and a.WAK_AkrId=B.WAK_AkrId and A.Modyfikacja=B.WAK_DataModyfikacji where b.WAK_AkrId=0 and wak_wartosc <>0 ) AS E LEFT OUTER JOIN (select C.WAK_PracId, C.WAK_datawykonania, D.WAK_Wartosc from  (select WAK_PracId, WAK_AkrId, WAK_datawykonania, MAX(WAK_DataModyfikacji) Modyfikacja from gal_wartakordu group by WAK_PracId, WAK_AkrId, WAK_datawykonania) as C left outer join GAL_WartAkordu as D on C.WAK_PracId=D.WAK_PracId and C.WAK_datawykonania=D.WAK_datawykonania and C.WAK_AkrId=D.WAK_AkrId and C.Modyfikacja=D.WAK_DataModyfikacji where D.WAK_AkrId<>0  and D.WAK_Wartosc <>0 ) AS F ON E.WAK_PracId=F.WAK_PRACID AND E.WAK_datawykonania=F.WAK_datawykonania WHERE F.WAK_PracId IS NULL and E.WAK_datawykonania>='" + dataPoczatkowa + "' and E.WAK_datawykonania<='" + dataKoncowa + "' ORDER BY 1";
            try
            {
                pomDataTable = query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("RaportyPracownikaKsiegowoscForm_RaportLeni()", result);
                return false;
            }
        }

        public bool RaportyPracownikaProdukcjaForm_ZaladujListePracownikow(ref DataTable pomDataTable, ref string result)
        {
            String zapytanie = "SELECT * FROM GAL_Pracownicy where PRA_Archiwalny <> 1 order by PRA_Nazwisko";
            try
            {
                pomDataTable = query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("RaportRecepcjaForm_ZaladujListePracownikow()", result);
                return false;
            }
        }

        public bool RaportyPracownikaKsiegowoscForm_ZaladujListePracownikow(ref DataTable pomDataTable, ref string result)
        {
            String zapytanie = "SELECT * FROM GAL_Pracownicy where PRA_Archiwalny <> 1 order by PRA_Nazwisko";
            try
            {
                pomDataTable = query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("RaportyPracownikaKsiegowoscForm_ZaladujListePracownikow()", result);
                return false;
            }
        }

        public bool RaportyGlobalneProdukcjaForm_ZaladujRaportGlobalny(string dataPoczatkowa, string dataKoncowa, ref DataTable pomDataTable, ref string result)
        {
            String zapytanie = "select PRA_PracId, PRA_Nazwisko Nazwisko, PRA_Imie [Imię], h.wykonanie [Wykonanie w %] from dbo.GAL_Pracownicy as G inner join (select c.wak_pracid , round(sum(case when f.czas = 0 then 0 else c.Praca/f.czas*100 end),2) as Wykonanie	from (select a.wak_pracid, a.wak_datawykonania, sum(b.wak_wartosc/b.WAK_WartoscNormy*8) Praca from (select wak_pracid, wak_akrid, wak_datawykonania, max(wak_datamodyfikacji) wak_datamodyfikacji from dbo.GAL_WartAkordu where wak_datawykonania >= '" + dataPoczatkowa + "' and wak_datawykonania <= '" + dataKoncowa + "' and WAK_AkrId<>0 group by wak_pracid, wak_akrid, wak_datawykonania) as A left outer join dbo.GAL_WartAkordu as B on a.wak_pracid=b.wak_pracid and a.wak_akrid=b.wak_akrid and  a.wak_datawykonania=b.wak_datawykonania and a.wak_datamodyfikacji=b.WAK_DataModyfikacji group by a.wak_pracid, a.wak_datawykonania) as C left outer join (select d.wak_pracid,  sum(e.wak_wartosc) as czas from (select wak_pracid, wak_akrid, wak_datawykonania, max(wak_datamodyfikacji) wak_datamodyfikacji from dbo.GAL_WartAkordu where wak_datawykonania >= '" + dataPoczatkowa + "' and wak_datawykonania <= '" + dataKoncowa + "' and WAK_AkrId=0 group by wak_pracid, wak_akrid, wak_datawykonania)  as d left outer join dbo.GAL_WartAkordu as E on d.wak_pracid=e.wak_pracid and d.wak_akrid=e.wak_akrid and  d.wak_datawykonania=e.wak_datawykonania and d.wak_datamodyfikacji=e.WAK_DataModyfikacji group by d.WAK_PracId)  as F on c.WAK_PracId=F.WAK_PracId group by c.WAK_PracId) as H on g.PRA_PracId=h.WAK_PracId order by Nazwisko, [Imię]";
            try
            {
                pomDataTable = query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("RaportyGlobalneProdukcjaForm_ZaladujRaportLeni()", result);
                return false;
            }
        }

        public bool RaportyPracownikaProdukcjaForm_ZaladujRaportSzczegolowy(string idPracownika, string dataPoczatkowa, string dataKoncowa, ref DataTable pomDataTable, ref string result)
        {
            String zapytanie = "select PRA_PracId, PRA_Nazwisko Nazwisko, PRA_Imie [Imię], h.wykonanie [Wykonanie w %] from dbo.GAL_Pracownicy as G inner join (select c.wak_pracid , round(sum(case when f.czas = 0 then 0 else c.Praca/f.czas*100 end),2) as Wykonanie	from (select a.wak_pracid, a.wak_datawykonania, sum(b.wak_wartosc/b.WAK_WartoscNormy*8) Praca from (select wak_pracid, wak_akrid, wak_datawykonania, max(wak_datamodyfikacji) wak_datamodyfikacji from dbo.GAL_WartAkordu where wak_datawykonania >= '" + dataPoczatkowa + "' and wak_datawykonania <= '" + dataKoncowa + "' and WAK_AkrId<>0 group by wak_pracid, wak_akrid, wak_datawykonania) as A left outer join dbo.GAL_WartAkordu as B on a.wak_pracid=b.wak_pracid and a.wak_akrid=b.wak_akrid and  a.wak_datawykonania=b.wak_datawykonania and a.wak_datamodyfikacji=b.WAK_DataModyfikacji group by a.wak_pracid, a.wak_datawykonania) as C left outer join (select d.wak_pracid,  sum(e.wak_wartosc) as czas from (select wak_pracid, wak_akrid, wak_datawykonania, max(wak_datamodyfikacji) wak_datamodyfikacji from dbo.GAL_WartAkordu where wak_datawykonania >= '" + dataPoczatkowa + "' and wak_datawykonania <= '" + dataKoncowa + "' and WAK_AkrId=0 group by wak_pracid, wak_akrid, wak_datawykonania)  as d left outer join dbo.GAL_WartAkordu as E on d.wak_pracid=e.wak_pracid and d.wak_akrid=e.wak_akrid and  d.wak_datawykonania=e.wak_datawykonania and d.wak_datamodyfikacji=e.WAK_DataModyfikacji group by d.WAK_PracId)  as F on c.WAK_PracId=F.WAK_PracId group by c.WAK_PracId) as H on g.PRA_PracId=h.WAK_PracId order by Nazwisko, [Imię]";
            try
            {
                pomDataTable = query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("RaportyPracownikaProdukcjaForm_ZaladujRaportSzczegolowy()", result);
                return false;
            }
        }

        public bool RaportyPracownikaProdukcjaForm_ZaladujRaportZbiorczy(string idPracownika, string dataPoczatkowa, string dataKoncowa, ref DataTable pomDataTable, ref string result)
        {
            String zapytanie = "select nazwa [Nazwa akordu], sum(WAK_Wartosc) [Suma wartości] from(select a.wak_akrid, (select top(1) akr_nazwa from dbo.GAL_Akordy where AKR_AkrId=a.WAK_AkrId and AKR_DataDodania<=a.WAK_datawykonania order by AKR_Id desc) as Nazwa , b.WAK_Wartosc from (select WAK_PracId, WAK_AkrId, WAK_datawykonania, MAX(WAK_DataModyfikacji) WAK_datamodyfikacji from dbo.GAL_WartAkordu  group by WAK_PracId, WAK_AkrId, WAK_datawykonania) as A left outer join dbo.gal_wartakordu as B on a.wak_pracid=b.wak_pracid and a.wak_akrid=b.wak_akrid and a.wak_datawykonania=b.wak_datawykonania and a.WAK_datamodyfikacji=b.WAK_DataModyfikacji where a.WAK_PracId = " + idPracownika + " and a.wak_datawykonania >= '" + dataPoczatkowa + "' and a.wak_datawykonania <= '" + dataKoncowa + "') as C group by c.WAK_AkrId, nazwa order by WAK_Akrid";
            try
            {
                pomDataTable = query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("RaportyPracownikaProdukcjaForm_ZaladujRaportZbiorczy()", result);
                return false;
            }
        }

        public bool RaportyPracownikaProdukcjaForm_WyliczProcentNormy(string idPracownika, string dataPoczatkowa, string dataKoncowa, ref string result)
        {
            String zapytanie = "select round(sum(case when f.czas = 0 then 0 else c.Praca/f.czas*100 end),2) as Wykonanie from ( select a.wak_pracid , a.wak_datawykonania, sum(b.wak_wartosc/b.WAK_WartoscNormy*8) Praca from ( select wak_pracid, wak_akrid, wak_datawykonania, max(wak_datamodyfikacji) wak_datamodyfikacji from dbo.GAL_WartAkordu where wak_datawykonania >= '" + dataPoczatkowa + "' and wak_datawykonania <= '" + dataKoncowa + "' and WAK_PracId=" + idPracownika + " and WAK_AkrId<>0 group by wak_pracid, wak_akrid, wak_datawykonania ) as A left outer join dbo.GAL_WartAkordu as B on a.wak_pracid=b.wak_pracid and a.wak_akrid=b.wak_akrid and  a.wak_datawykonania=b.wak_datawykonania and a.wak_datamodyfikacji=b.WAK_DataModyfikacji group by a.wak_pracid, a.wak_datawykonania ) as C left outer join (select d.wak_pracid,  sum(e.wak_wartosc) as czas from ( select wak_pracid, wak_akrid, wak_datawykonania, max(wak_datamodyfikacji) wak_datamodyfikacji from dbo.GAL_WartAkordu where wak_datawykonania >= '" + dataPoczatkowa + "' and wak_datawykonania <= '" + dataKoncowa + "' and WAK_AkrId=0  group by wak_pracid, wak_akrid, wak_datawykonania )  as d   left outer join dbo.GAL_WartAkordu as E on d.wak_pracid=e.wak_pracid and d.wak_akrid=e.wak_akrid and  d.wak_datawykonania=e.wak_datawykonania and d.wak_datamodyfikacji=e.WAK_DataModyfikacji group by d.WAK_PracId)  as F on c.WAK_PracId=F.WAK_PracId group by c.WAK_PracId";
            try
            {
                DataTable pomDataTable = query(zapytanie);

                if(pomDataTable.Rows.Count == 0)
                {
                    result = "Brak aktywności w okresie";
                }
                else
                {
                    result = "Wykonano: " + pomDataTable.Rows[0]["Wykonanie"].ToString() + " % normy";
                }

                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("RaportyPracownikaProdukcjaForm_WyliczProcentNormy()", result);
                return false;
            }
        }

        public bool RaportyGlobalneProdukcjaForm_ZaladujRaportLeni(string dataPoczatkowa, string dataKoncowa, ref DataTable pomDataTable, ref string result)
        {
            String zapytanie = "SELECT (select pra_nazwisko+' '+pra_imie from dbo.gal_Pracownicy where E.WAK_PracId=pra_pracid) Pracownik , E.WAK_datawykonania Data FROM  (select A.WAK_PracId, a.WAK_datawykonania, B.WAK_Wartosc from  (select WAK_PracId, WAK_AkrId, WAK_datawykonania, MAX(WAK_DataModyfikacji) Modyfikacja from gal_wartakordu group by WAK_PracId, WAK_AkrId, WAK_datawykonania) as A left outer join GAL_WartAkordu as B on A.WAK_PracId=B.WAK_PracId and A.WAK_datawykonania=B.WAK_datawykonania and a.WAK_AkrId=B.WAK_AkrId and A.Modyfikacja=B.WAK_DataModyfikacji where b.WAK_AkrId=0 and wak_wartosc <>0 ) AS E LEFT OUTER JOIN (select C.WAK_PracId, C.WAK_datawykonania, D.WAK_Wartosc from  (select WAK_PracId, WAK_AkrId, WAK_datawykonania, MAX(WAK_DataModyfikacji) Modyfikacja from gal_wartakordu group by WAK_PracId, WAK_AkrId, WAK_datawykonania) as C left outer join GAL_WartAkordu as D on C.WAK_PracId=D.WAK_PracId and C.WAK_datawykonania=D.WAK_datawykonania and C.WAK_AkrId=D.WAK_AkrId and C.Modyfikacja=D.WAK_DataModyfikacji where D.WAK_AkrId<>0  and D.WAK_Wartosc <>0 ) AS F ON E.WAK_PracId=F.WAK_PRACID AND E.WAK_datawykonania=F.WAK_datawykonania WHERE F.WAK_PracId IS NULL and E.WAK_datawykonania>='" + dataPoczatkowa + "' and E.WAK_datawykonania<='" + dataKoncowa + "' ORDER BY 1";
            try
            {
                pomDataTable = query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("RaportyGlobalneProdukcjaForm_ZaladujRaportLeni()", result);
                return false;
            }
        }

        public bool WprowadzanieAkordowForm_ZaladujListePracownikow(ref DataTable pomDataTable, ref string result)
        {
            String zapytanie = "SELECT * FROM GAL_Pracownicy where PRA_Archiwalny <> 1 order by PRA_Nazwisko";
            try
            {
                pomDataTable = query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("WprowadzanieAkordowForm_ZaladujListePracownikow()", result);
                return false;
            }
        }

        public bool RaportRecepcjaForm_ZaladujListePracownikow(ref DataTable pomDataTable, ref string result)
        {
            String zapytanie = "SELECT * FROM GAL_Pracownicy where PRA_Archiwalny <> 1 order by PRA_Nazwisko";
            try
            {
                pomDataTable = query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("RaportRecepcjaForm_ZaladujListePracownikow()", result);
                return false;
            }
        }

        public bool PracownicyForm_ZaladujPracownicyDGV(ref DataTable pomDataTable, bool @checked, ref string result)
        {
            String zapytanie = "SELECT * FROM GAL_Pracownicy";
            if(!@checked)
            {
                zapytanie += " where PRA_Archiwalny <> 1";
            }

            try
            {
                pomDataTable = query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("PracownicyForm_ZaladujPracownicyDGV()", result);
                return false;
            }
        }

        public bool RaportLeniRecepcjaForm_ZaladujRaportDGV(String dataPoczatkowa, String dataKoncowa, ref DataTable pomDataTable, ref string result)
        {
            String zapytanie = "SELECT (select pra_nazwisko+' '+pra_imie from dbo.gal_Pracownicy where E.WAK_PracId=pra_pracid) Pracownik , E.WAK_datawykonania Data FROM  (select A.WAK_PracId, a.WAK_datawykonania, B.WAK_Wartosc from  (select WAK_PracId, WAK_AkrId, WAK_datawykonania, MAX(WAK_DataModyfikacji) Modyfikacja from gal_wartakordu group by WAK_PracId, WAK_AkrId, WAK_datawykonania) as A left outer join GAL_WartAkordu as B on A.WAK_PracId=B.WAK_PracId and A.WAK_datawykonania=B.WAK_datawykonania and a.WAK_AkrId=B.WAK_AkrId and A.Modyfikacja=B.WAK_DataModyfikacji where b.WAK_AkrId=0 and wak_wartosc <>0 ) AS E LEFT OUTER JOIN (select C.WAK_PracId, C.WAK_datawykonania, D.WAK_Wartosc from  (select WAK_PracId, WAK_AkrId, WAK_datawykonania, MAX(WAK_DataModyfikacji) Modyfikacja from gal_wartakordu group by WAK_PracId, WAK_AkrId, WAK_datawykonania) as C left outer join GAL_WartAkordu as D on C.WAK_PracId=D.WAK_PracId and C.WAK_datawykonania=D.WAK_datawykonania and C.WAK_AkrId=D.WAK_AkrId and C.Modyfikacja=D.WAK_DataModyfikacji where D.WAK_AkrId<>0  and D.WAK_Wartosc <>0 ) AS F ON E.WAK_PracId=F.WAK_PRACID AND E.WAK_datawykonania=F.WAK_datawykonania WHERE F.WAK_PracId IS NULL and E.WAK_datawykonania>='" + dataPoczatkowa + "' and E.WAK_datawykonania<='" + dataKoncowa + "' ORDER BY 1";

            try
            {
                pomDataTable = query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("PracownicyForm_ZaladujPracownicyDGV()", result);
                return false;
            }
        }

        public bool RaportRecepcjaForm_ZaladujRaportDGV(String idPracownika, String idAkordu, String dataPoczatkowa, String dataKoncowa, ref DataTable pomDataTable, ref string result)
        {
            String zapytanie = "select a.WAK_datawykonania [Data wykonania], b.WAK_Wartosc [Wartość Akordu] from (select WAK_PracId, WAK_AkrId, WAK_datawykonania, MAX(WAK_DataModyfikacji) WAK_datamodyfikacji from dbo.GAL_WartAkordu group by WAK_PracId, WAK_AkrId, WAK_datawykonania) as A left outer join dbo.gal_wartakordu as B on a.wak_pracid=b.wak_pracid and a.wak_akrid=b.wak_akrid and a.wak_datawykonania=b.wak_datawykonania and a.WAK_datamodyfikacji=b.WAK_DataModyfikacji where a.WAK_AkrId=" + idAkordu + " and a.WAK_PracId = " + idPracownika + " and a.wak_datawykonania >= '" + dataPoczatkowa + "' and a.wak_datawykonania <= '" + dataKoncowa + "' order by 1";
            try
            {
                pomDataTable = query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("RaportRecepcjaForm_ZaladujRaportDGV()", result);
                return false;
            }
        }

        public bool PracownicyChangeForm_AddNewPracownik(string imie, string nazwisko, string archiwalny, ref string result)
        {
            DateTime teraz = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            String zapytanieString = "insert into GAL_Pracownicy values('" + imie + "', '" + nazwisko + "', '" + teraz.ToString() + "'," + archiwalny + ")";

            try
            {
                query(zapytanieString);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("PracownicyChangeForm_AddNewPracownik()", exc.Message);
                return false;
            }
        }

        public bool AkordyForm_ZaladujAkordyDGV(ref DataTable pomDataTable, bool @checked, ref string result)
        {
            String zapytanie = "SELECT * FROM GAL_Akordy";
            if(!@checked)
            {
                zapytanie += " where AKR_Archiwalny <> 1";
            }

            try
            {
                pomDataTable = query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("AkordyForm_ZaladujAkordyDGV()", result);
                return false;
            }
        }

        public bool PracownicyChangeForm_ChangePracownik(string pRA_PracID, string imie, string nazwisko, string archiwalny, ref string result)
        {
            String zapytanieString = "update GAL_Pracownicy set PRA_Imie = '" + imie + "', PRA_Nazwisko = '" + nazwisko + "', PRA_Archiwalny = " + archiwalny + " where PRA_PracId = " + pRA_PracID;
            try
            {
                query(zapytanieString);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("PracownicyChangeForm_ChangePracownik()", exc.Message);
                return false;
            }
        }

        public bool OperatorzyForm_ZaladujOperatorzyDGV(ref DataTable pomDataTable, bool @checked, ref string result)
        {
            String zapytanie = "SELECT * FROM GAL_Operatorzy where OPR_OprId <> 1";
            if(!@checked)
            {
                zapytanie += " and OPR_Archiwalny <> 1";
            }

            try
            {
                pomDataTable =  query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("OperatorzyForm_ZaladujOperatorzyDGV()", result);
                return false;
            }
        }

        public bool AkordyChangeForm_AddAkord(string nazwa, string norma, string archiwalny, ref string result)
        {
            String AKR_AkrId = "";
            String error = "";

            if(AkordyChangeForm_GetMaxAkrID(ref AKR_AkrId, ref error))
            {
                String zapytanieString = "insert into GAL_Akordy values(" + AKR_AkrId + ", '" + nazwa + "', " + norma + ", '" + DateTime.Now.ToString() + "'," + archiwalny + ")";
                try
                {
                    query(zapytanieString);
                    return true;
                }
                catch(Exception exc)
                {
                    result = exc.Message;
                    ErrorReport("AkordyChangeForm_AddNewAkord()", exc.Message);
                    return false;
                }
            }
            else
            {
                result = error;
                return false;
            }            
        }

        public bool PracownicyForm_UsunPracownika(string idPracownika, ref string result)
        {
            String zapytanieString = "UPDATE GAL_Pracownicy SET PRA_Archiwalny = 1 WHERE PRA_PracId =" + idPracownika;
            try
            {
                query(zapytanieString);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("PracownicyForm_UsunPracownika()", exc.Message);
                return false;
            }
        }

        private bool AkordyChangeForm_GetMaxAkrID(ref String AKR_AkrId, ref String error)
        {
            String zapytanieString = "select max(AKR_AkrID)+1 from GAL_Akordy";
            try
            {
                DataTable pomDataTable =  query(zapytanieString);

                AKR_AkrId = pomDataTable.Rows[0][0].ToString();

                return true;
            }
            catch(Exception exc)
            {
                error = exc.Message;
                ErrorReport("AkordyChangeForm_AddNewAkord()", error);
                return false;
            }
        }

        public bool AkordyChangeForm_ChangeAkord(String AKR_AkrId, String nazwa, String norma, String archiwalny, ref String result)
        {
            String zapytanieString = "insert into GAL_Akordy values(" + AKR_AkrId + ", '" + nazwa + "', '" + norma + "', '" + DateTime.Now.ToString() + "'," + archiwalny + ")";
            try
            {
                query(zapytanieString);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("AkordyChangeForm_AddNewAkord()", exc.Message);
                return false;
            }
        }

        public bool UstawieniaForm_ZmienHaslo(String noweHaslo, ref string result)
        {
            String zapytanie = "update GAL_Operatorzy set OPR_Haslo = '" + noweHaslo + "' where OPR_OprId = " + MainForm.IDOperatora;

            try
            {
                query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("UstawieniaForm_ZmienHaslo()", result);
                return false;
            }
        }

        public bool AkordyForm_UsunAkord(string IDAkordu, ref string result)
        {
            String zapytanieString = "UPDATE GAL_Akordy SET AKR_Archiwalny = 1 WHERE AKR_Id =" + IDAkordu;
            try
            {
                query(zapytanieString);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("AkordyForm_UsunAkord()", exc.Message);
                return false;
            }
        }

        public bool ZarzadzanieTestowymiForm_UsunAkord(string IDAkordu, ref string result)
        {
            String zapytanieString = "UPDATE GAL_AkordyTestowe SET AKT_Archiwalny = 1 WHERE AKT_Id =" + IDAkordu;
            try
            {
                query(zapytanieString);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("ZarzadzanieTestowymiForm_UsunAkord()", exc.Message);
                return false;
            }
        }

        public bool OperatorzyChangeForm_AddNewOperator(string imie, string nazwisko, int uprawnienia, string archiwalny, ref string result)
        {
            String zapytanieString = "INSERT INTO GAL_Operatorzy VALUES ('"+ imie + "', '"+ nazwisko + "', '', " + uprawnienia+", "+ archiwalny + ")";
            try
            {
                query(zapytanieString);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("OperatorzyChangeForm_AddNewOperator()", exc.Message);
                return false;
            }
        }

        public bool OperatorzyForm_UsunOperatora(string IDOperatora, ref string result)
        {
            String zapytanieString = "UPDATE GAL_Operatorzy SET OPR_Archiwalny = 1 WHERE OPR_OprId ="+ IDOperatora;
            try
            {
                query(zapytanieString);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("OperatorzyForm_UsunOperatora()", exc.Message);
                return false;
            }
        }

        public bool OperatorzyChangeForm_ChangeOperator(string oPR_OprId, string imie, string nazwisko, int uprawnienia, string archiwalny, ref string result)
        {
            String zapytanieString = "UPDATE GAL_Operatorzy SET OPR_Imie = '"+ imie + "',OPR_Nazwisko = '"+ nazwisko + "',OPR_Uprwnienia = " + uprawnienia + " ,OPR_Archiwalny = " + archiwalny + " WHERE OPR_OprId = " + oPR_OprId;
            try
            {
                query(zapytanieString);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("OperatorzyChangeForm_ChangeOperator()", exc.Message);
                return false;
            }
        }

        public Boolean GetAppVersion(ref String result, ref String error)
        {
            try
            {
                DataTable tabPom = query("SELECT TOP 1 ust_wpis FROM GAL_Ustawienia");

                result = tabPom.Rows[0]["UST_Wpis"].ToString();
                return true;
            }
            catch(Exception exc)
            {
                error = exc.Message;
                ErrorReport("GetAppVersion()", exc.Message);
                return false;
            }
        }

        public bool OperatorzyForm_UsunHasloOperatora(string opr_OprId, ref string result)
        {
            String zapytanie = "UPDATE GAL_Operatorzy SET OPR_Haslo = '' WHERE OPR_OprId = " + opr_OprId;
            try
            {
                query(zapytanie);
                return true;
            }
            catch(Exception exc)
            {
                result = exc.Message;
                ErrorReport("OperatorzyForm_UsunHasloOperatora()", result);
                return false;
            }
        }

        public void ErrorReport(string modul, string message)
        {
            try
            {
                DateTime teraz = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                String nazwaKompOper = Environment.MachineName + "\\" + Environment.UserName;
                String zapytanie = "insert into gal_ustawienia values('"+modul+" - "+ message + "', '"+ MainForm.nazwaOperatora + "', '"+ teraz.ToString()+"', '"+ nazwaKompOper+"')";
            
                query(zapytanie);
            }
            catch(Exception){}
        }

        public Boolean GetServerTime(ref String data)
        {
            try
            {
                DataTable pomDataTable = query("SELECT left(CONVERT(VARCHAR(10),GETDATE(),21),11)as data");

                if(pomDataTable.Rows.Count == 1)
                {
                    data = pomDataTable.Rows[0]["data"].ToString();
                }
                return true;
            }
            catch(Exception exc)
            {
                ErrorReport("GetServerTime()", exc.Message);
            }
            return false;
        }

        public Boolean GetServerTime(ref DateTime data)
        {
            try
            {
                DataTable pomDataTable = query("SELECT left(CONVERT(VARCHAR(10),GETDATE(),21),11)as data");

                if(pomDataTable.Rows.Count == 1)
                {
                    data = DateTime.Parse(pomDataTable.Rows[0]["data"].ToString());
                }
                return true;
            }
            catch(Exception exc)
            {
                ErrorReport("GetServerTime()", exc.Message);
            }
            return false;
        }

        public Boolean ConnectDataBaseThread()
        {
            Boolean connectionResult = false;
            Passwords passwords = new Passwords();

            try
            {
                String DBLogin = passwords.GetInstanceUserName();
                String DBPassword = passwords.GetInstancePassword();
                String DBInstance = passwords.GetInstanceName();
                String DBName = passwords.GetDataBaseName();

                DBConnectionThread = new SqlConnection(@"user id=" + DBLogin + "; password=" + DBPassword + "; Data Source=" + DBInstance + "; Initial Catalog=" + DBName + ";");
                DBConnectionThread.Open();
                DBConnectionThread.Close();
                connectionResult = true;
            }
            catch(Exception) { }

            return connectionResult;
        }

        public Boolean LoginForm_WczytajOperatorowDT(Boolean archiwalni, ref DataTable operatorzyDT, ref String error)
        {
            String zapytanieString = "SELECT * FROM GAL_Operatorzy";

            if(!archiwalni)
            {
                zapytanieString += " where OPR_Archiwalny = 0";
            }

            zapytanieString += " order by OPR_Nazwisko asc";

            try
            {
                operatorzyDT = query(zapytanieString);
                return true;
            }
            catch(Exception exc)
            {
                error = exc.Message;
                ErrorReport("LoginForm_WczytajOperatorowDT()", error);
            }
            return false;
        }

        public DataTable query(string queryString)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable tempDataTable = new DataTable();

            SqlCommand SQLCommnad = new SqlCommand(queryString);
            SQLCommnad.CommandTimeout = Timeout;
            SQLCommnad.Connection = DBConnection;
            da = new SqlDataAdapter(SQLCommnad);

            da.Fill(tempDataTable);

            return tempDataTable;
        }

        public DataTable queryThread(string queryString)
        {
            DBConnectionThread.Open();

            SqlDataAdapter da = new SqlDataAdapter();
            DataTable tempDataTable = new DataTable();

            SqlCommand polecenieSQL = new SqlCommand(queryString);
            polecenieSQL.CommandTimeout = Timeout;
            polecenieSQL.Connection = DBConnection;
            da = new SqlDataAdapter(polecenieSQL);
            da.Fill(tempDataTable);

            DBConnectionThread.Close();

            return tempDataTable;
        }
    }
}
