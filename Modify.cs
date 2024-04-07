using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ReportingServices.Diagnostics.Internal;

namespace QLChungCuMini
{
    internal class Modify
    {
        SqlConnection connection;
        //String str = "Data Source=DESKTOP-0HMGH3I;Initial Catalog=QLChungCuMini;Integrated Security=True;Encrypt=False";
        //data của mạnh
        String str = "Data Source=MANHCAO\\SQLEXPRESS;Initial Catalog=QLChungCuMini;Integrated Security=True";
        //data đức dz
        // String str = "Data Source=LAPTOP-ACERI5\\SQLEXPRESS;Initial Catalog=QLChungCuMini;Integrated Security=True;";
        SqlDataAdapter adapter;

        public Modify()
        {
        }
        public DataTable Table(String query)
        {
            DataTable dataTable = new DataTable();
            using (connection = new SqlConnection(str))
            {
                connection.Open();
                adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(dataTable);
                connection.Close();
            }
            return dataTable;
        }
    }
}
