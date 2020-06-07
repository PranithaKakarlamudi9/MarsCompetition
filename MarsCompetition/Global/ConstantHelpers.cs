using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsCompetition.Global
{
    class ConstantHelpers
    {
        public static String BaseUrl = "http://192.168.99.100:5000/Home";
        public static String ReportsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Reports\\");
        public static String TestDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\TestData\\MarsTestData.xlsx");

    }
}
