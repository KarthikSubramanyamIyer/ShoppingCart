using DataAccessLayer.DataAccessHandler;
using DataModellayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class GenderService
    {
        private static DBManager GetConnection() => new DBManager("connectionstring");
        public DBManager dBManager;

        public GenderService()
        {
            dBManager = GetConnection();
        }

        public System.Data.DataTable GetGender()
        {
            return dBManager.GetDataTable("SELECT * FROM  Gender", commandType: System.Data.CommandType.Text);
        }
        public bool SaveGender(Gender gender)
        {
            try
            {
                string commandText = "Insert into Gender(GenderName) Values('" + gender.GenderName + "')";
                dBManager.Insert(commandText, commandType: System.Data.CommandType.Text, null);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
