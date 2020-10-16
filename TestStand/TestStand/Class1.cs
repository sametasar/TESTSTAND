using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace teststand
{

    public class YamahaHex
    {
        public string[] GetHexFileName(string Barcode)
        {
            string[] Liste = new string[30];

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.UserID = "PAG";
            builder.Password = "PAG-1234";
            builder.DataSource = "30.30.0.12";
            //builder.DataSource = "10.5.100.23";
            builder.InitialCatalog = "YAMAHA_VLE";

            string query = @"select DISTINCT ys.componentId, yh.HexFile,yh.Filter from YAMAHA_HEX yh, YAMAHA_SRV ys where SUBSTRING (barcode ,0 , 9) = yh.ProjectName and
              yh.ComponentID = ys.componentId and
              yh.GroupNo = (select GroupNo from
              (SELECT top 1 count(GroupNo) toplam, GroupNo FROM YAMAHA_HEX yh, YAMAHA_SRV ys where yh.ComponentID = ys.componentId and
              ys.barcode = '" + Barcode + @"' and
              SUBSTRING(barcode, 0, 9) = yh.ProjectName group by GroupNo order by toplam desc)xxx) and
              SUBSTRING(barcode, 0, 9) = yh.ProjectName and
              ys.barcode = '" + Barcode + "'";

            SqlConnection baglan = new SqlConnection(builder.ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter(query, baglan);
            DataTable dt = new DataTable();
            da.Fill(dt);


            string yazi = "";

            int i = 0;

            foreach (DataRow r in dt.Rows)
            {
                yazi = "";
                yazi += r["Filter"].ToString() + "|";
                yazi += r["HexFile"].ToString();
                Liste[i] = yazi;

                i++;

            }

            return Liste;

        }
    }

}