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
                ConnectDataBase();
            }
        }

        public DBRepository(Int32 StartThreadConnection)
        {
            if(DBConnectionThread == null)
            {
                ConnectDataBaseThread();
            }
        }

        public Boolean ConnectDataBase()
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
            catch(Exception) { }

            return connectionResult;
        }

        public bool HasloForm_ZmienHaslo(String noweHaslo, ref string result)
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
                ErrorReport("HasloForm_ZmienHaslo()", result);
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
            }

            return false;
        }

        private void ErrorReport(string v, string message)
        {
            throw new NotImplementedException();
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
