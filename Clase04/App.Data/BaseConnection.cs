using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public class BaseConnection
    {
        public string ConnectionString {
            get
            {
                string dts = "Data Source=MI607-ST; Initial Catalog=Chinook; User Id=Jmitacc; Password=P@$$w0rd";
                return dts;
            }
        }
    }
}
