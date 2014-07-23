using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Raven.OPTIMUS.Common
{
    public static class Helper
    {
        /// <summary>
        /// To convert the passing datetime value into DateTime format
        /// </summary>
        /// <param name="value">Format:yyyymmdd</param>
        /// <returns>DateTime</returns>
        public static DateTime DateInStringToDateTime(string value)
        {
            DateTime theTime = DateTime.ParseExact(value,
                                        "yyyyMMdd",
                                        CultureInfo.InvariantCulture,
                                        DateTimeStyles.None);
            return theTime;
        }

        public static String GenerateTransactionNo(SqlConnection _mainConnection, String transactionCode, SqlDateTime date)
        {
            String retval = "";
            SqlCommand cmdToExecute = new SqlCommand();
            cmdToExecute.CommandText = "GenerateTransactionNo";
            cmdToExecute.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmdToExecute);
            cmdToExecute.Connection = _mainConnection;
            try
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Result";
                param.SqlDbType = SqlDbType.VarChar;
                param.Size = 20;
                param.Direction = ParameterDirection.Output;

                cmdToExecute.Parameters.Add("@TransactionCode", transactionCode);
                cmdToExecute.Parameters.Add("@TransactionDate", date);
                cmdToExecute.Parameters.Add(param);

                _mainConnection.Open();

                cmdToExecute.ExecuteNonQuery();

                retval = param.Value.ToString();

                _mainConnection.Close();
                cmdToExecute.Dispose();
                adapter.Dispose();
            }
            catch (Exception ex)
            {
                _mainConnection.Close();
                cmdToExecute.Dispose();
                adapter.Dispose();
                throw ex;
            }
            return retval;
        }

        public static DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();


            // column names
            PropertyInfo[] oProps = null;


            if (varlist == null) return dtReturn;


            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;


                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }


                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }


                DataRow dr = dtReturn.NewRow();


                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }


                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }

        public static String MoneyInWords(Int64 amount)
        {
            StringBuilder strbuild = new StringBuilder("RUPIAH");
            String[] arrBil = { "", "SATU ", "DUA ", "TIGA ", "EMPAT ", "LIMA ", "ENAM ", "TUJUH ", "DELAPAN ", "SEMBILAN ", "SE" };
            String[] arrSatKecil = { "", "PULUH ", "RATUS " };
            String[] arrSatBesar = { "", "RIBU ", "JUTA ", "MILYAR " };
            int ctrKecil = 0;
            int ctrBesar = 0;
            if (amount == 0)
            {
                return "NOL RUPIAH";
            }
            else
            {
                while (amount > 0)
                {
                    long a = amount % 10;
                    amount /= 10;

                    if(a>0)
                        strbuild.Insert(0, arrSatKecil[ctrKecil]);

                    if (a == 1 && ctrKecil > 0)
                        strbuild.Insert(0, arrBil[10]);
                    else if (ctrKecil == 0 && amount % 10 == 1)
                    {
                        strbuild.Insert(0, "belas ");
                        strbuild.Insert(0, arrBil[a]);
                        amount /= 10;
                        ctrKecil++;
                    }
                    else
                        strbuild.Insert(0, arrBil[a]);

                    ctrKecil++;
                    if (ctrKecil % 3 == 0)
                    {
                        ctrBesar++;
                        ctrKecil = 0;
                        if (amount > 0 && amount % 1000 > 0)
                        {
                            strbuild.Insert(0, arrSatBesar[ctrBesar]);
                        }
                    }
                    
                }
                return strbuild.ToString();
            }


        }
    }
}
