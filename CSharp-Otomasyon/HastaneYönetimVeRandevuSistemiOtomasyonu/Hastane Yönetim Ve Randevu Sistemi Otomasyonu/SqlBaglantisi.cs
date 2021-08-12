using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Hastane_Yönetim_Ve_Randevu_Sistemi_Otomasyonu
{
    public class SqlBaglantisi
    {
        public SqlConnection Connection()
        {
            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False

            SqlConnection connect = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HastaneOtomasyon;Integrated Security=True;");

            //SqlConnection connect = new SqlConnection("Data Source=DESKTOP-DR83AEK\\SQLEXPRESS;Initial Catalog=HastaneOtomasyon;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            
            connect.Open();

            return connect;
        }
    }
}
