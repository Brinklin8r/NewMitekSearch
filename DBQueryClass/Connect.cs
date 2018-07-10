using ConfigurationSetttings;
using System;
using System.Data.SqlClient;


namespace DBQueryClass
{
    public class Connect {
        private SqlConnection _objSQLConnection;
                                                  
        private string _sqlSourceName = "";
        private string _sqlInitialCatalog = "";
        private string _sqlUserID = "";
        private string _sqlPassword = "";

        public SqlConnection GetSQLConn() {
            return _objSQLConnection;
        }

        public string ConnectToDB(string DatabaseName) {
            _sqlInitialCatalog = DatabaseName;
       
            DisconnectFromDB();
            try {
                _objSQLConnection = new SqlConnection(
                    _CreateSQLConnectionString());
                _objSQLConnection.Open();
            } catch (Exception ex) {
                return "Error:  " + ex.Message.ToString();
            }

            return "Connected to " + _sqlInitialCatalog + "!";
        }

        public string ConnectToDB() {
            DisconnectFromDB();
            try {
                _objSQLConnection = new SqlConnection(
                    _CreateSQLConnectionString());
                _objSQLConnection.Open();
            } catch (Exception ex) {
                return "Error:  " + ex.Message.ToString();
            }

            return "Connected to " + _sqlInitialCatalog + "!";
        }

        public string DisconnectFromDB() {
            try {
                _objSQLConnection.Close();
            } catch (Exception ex) {
                return "Error:  " + ex.Message.ToString();
            }

            return "Closed DB Connection.";
        }

        private void _GetConfigValuse() {
            ConfigSettings _confSet = new ConfigSettings();

            if (_sqlSourceName == "")
                _sqlSourceName = _confSet.GetValue("Server");
            if (_sqlUserID == "")
                _sqlUserID = _confSet.GetValue("UserName");
            if (_sqlPassword == "")
                _sqlPassword = _confSet.GetValue("Password");
            if (_sqlSourceName == "")
                _sqlSourceName = _confSet.GetValue("Database");

        }

        private string _CreateSQLConnectionString() {
            string _connString = "";
            try {
                _GetConfigValuse();
                _connString += @"Data Source=" + _sqlSourceName;
                _connString += @";Initial Catalog=" + _sqlInitialCatalog;
                _connString += @";User ID=" + _sqlUserID;
                _connString += @";Password =" + _sqlPassword;
            } catch (Exception ex) {
                return "Error:  " + ex.Message.ToString();
            }
            return _connString;
        }
    }
}
