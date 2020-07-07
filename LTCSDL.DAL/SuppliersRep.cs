using LTCSDL.Common.DAL;
using LTCSDL.Common.Req;
using LTCSDL.DAL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LTCSDL.DAL
{
    public class SuppliersRep : GenericRep<NorthwindContext, Suppliers>
    {
        public List<object> pro_ThemMoiSupplier(SuppliersReq keyword)
        {
            List<object> res = new List<object>();
            var cnn = (SqlConnection)Context.Database.GetDbConnection();
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                var cmd = cnn.CreateCommand();

                cmd.CommandText = "pro_ThemMoiSupplier";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CompanyName", keyword.CompanyName);
                cmd.Parameters.AddWithValue("@ContactName", keyword.ContactName);
                cmd.Parameters.AddWithValue("@ContactTitle", keyword.ContactTitle);
                cmd.Parameters.AddWithValue("@Address", keyword.Address);
                cmd.Parameters.AddWithValue("@City", keyword.City);

                da.SelectCommand = cmd;
                da.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            SupplierID = row["SupplierID"],
                            CompanyName = row["CompanyName"],
                            ContactName = row["ContactName"],
                            ContactTitle = row["ContactTitle"],
                            Address = row["Address"],
                            City = row["City"]
                        };
                        res.Add(x);
                    }
                }
            }
            catch (Exception ex)
            {
                res = null;
            }

            return res;
        }

        public List<object> pro_UpdateSupplier(SuppliersReq keyword)
        {
            List<object> res = new List<object>();
            var cnn = (SqlConnection)Context.Database.GetDbConnection();
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                var cmd = cnn.CreateCommand();

                cmd.CommandText = "pro_UpdateSupplier";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SupplierID", keyword.SupplierID);
                cmd.Parameters.AddWithValue("@CompanyName", keyword.CompanyName);
                cmd.Parameters.AddWithValue("@ContactName", keyword.ContactName);
                cmd.Parameters.AddWithValue("@ContactTitle", keyword.ContactTitle);
                cmd.Parameters.AddWithValue("@Address", keyword.Address);
                cmd.Parameters.AddWithValue("@City", keyword.City);

                da.SelectCommand = cmd;
                da.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            SupplierID = row["SupplierID"],
                            CompanyName = row["CompanyName"],
                            ContactName = row["ContactName"],
                            ContactTitle = row["ContactTitle"],
                            Address = row["Address"],
                            City = row["City"]
                        };
                        res.Add(x);
                    }
                }
            }
            catch (Exception ex)
            {
                res = null;
            }

            return res;
        }
    }
}
