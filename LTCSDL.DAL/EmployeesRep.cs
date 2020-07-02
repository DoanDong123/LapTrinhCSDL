using LTCSDL.Common.DAL;
using LTCSDL.DAL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LTCSDL.DAL
{
    public class EmployeesRep : GenericRep<NorthwindContext, Employees>
    {
        public List<object> pro_doanhthutheongaythangnam(string date)
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

                cmd.CommandText = "pro_doanhthutheongaythangnam";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@date", date);

                da.SelectCommand = cmd;
                da.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            EmployeeID = row["EmployeeID"],
                            OrderDate = row["OrderDate"],
                            OrderID = row["OrderID"],
                            DoanhThu = row["DoanhThu"]
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

        public List<object> pro_doanhthutheothoigian (string beginDate, string endDate)
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

                cmd.CommandText = "pro_doanhthutheothoigian";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@batdau", beginDate);
                cmd.Parameters.AddWithValue("@ketthuc", endDate);


                da.SelectCommand = cmd;
                da.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            EmployeeID = row["EmployeeID"],
                            FirstName = row["FirstName"],
                            LastName = row["LastName"],
                            DoanhThu = row["DoanhThu"]
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

        public object DoanhThuTheoNgayThangNam_Linq(DateTime date)
        {
            var res = Context.Employees
                .Join(Context.Orders, a => a.EmployeeId, b => b.EmployeeId, (a, b) => new
                {
                    a.EmployeeId,
                    a.FirstName,
                    a.LastName,
                    b.OrderId,
                    b.OrderDate
                })
                .Join(Context.OrderDetails, a => a.OrderId, b => b.OrderId, (a, b) => new
                {
                    a.EmployeeId,
                    a.FirstName,
                    a.LastName,
                    a.OrderDate,
                    a.OrderId,
                    DoanhThu = b.UnitPrice * b.Quantity * (1 - ((decimal)b.Discount))
                })
                .Where(x => x.OrderDate.HasValue && x.OrderDate.Value.Date == date.Date).ToList();

            var data = res.GroupBy(x => x.EmployeeId)
                .Select(x => new
                {
                    x.First().EmployeeId,
                    x.First().FirstName,
                    x.First().LastName,
                    TongDoanhThu = x.Sum(t => t.DoanhThu)
                }).ToList();


            return data;
        }

    }
}
