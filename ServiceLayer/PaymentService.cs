﻿using DataAccessLayer.DataAccessHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class PaymentService
    {
        private static DBManager GetConnection() => new DBManager("connectionstring");
        public DBManager dBManager;
        public PaymentService()
        {
            dBManager = GetConnection();
        }
    }
}
