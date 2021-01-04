using LTCSDL.Common.DAL;
using LTCSDL.Common.Req;
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
    public class DoanQuiDongRep : GenericRep<NorthwindContext, Products>
    {
        //Câu 2 đề 5
        public List<object> pro_SanPhamKhongCoDonHangTrongNgay(DoanQuiDongReq keyword)
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

                cmd.CommandText = "pro_SanPhamKhongCoDonHangTrongNgay";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@date", keyword.date);
                cmd.Parameters.AddWithValue("@page", keyword.page);
                cmd.Parameters.AddWithValue("@size", keyword.size);

                da.SelectCommand = cmd;
                da.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            STT = row["STT"],
                            ProductID = row["ProductID"],
                            ProductName = row["ProductName"],
                            SupplierID = row["SupplierID"],
                            CategoryID = row["CategoryID"],
                            QuantityPerUnit = row["QuantityPerUnit"],
                            UnitPrice = row["UnitPrice"],
                            UnitsInStock = row["UnitsInStock"],
                            UnitsOnOrder = row["UnitsOnOrder"],
                            ReorderLevel = row["ReorderLevel"],
                            Discontinued = row["Discontinued"]
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

        //Câu 3 đề 5
        public int Them_Product(Products product)
        {
            int res = 0;
            var cnn = (SqlConnection)Context.Database.GetDbConnection();
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            try
            {
                string strSQL = "Insert into Products(ProductName, Discontinued) values(N'" + product.ProductName + "', '" + product.Discontinued + "')";

                SqlCommand cmd = new SqlCommand(strSQL, cnn);
                cmd.CommandType = CommandType.Text;

                res = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                res = -1;
            }

            return res;
        }

        //Câu 4 đề 5

        public object SoLuongHangHoaTrongKhoangThoiGian_Linq(DoanQuiDongReq_cau4 date)
        {

            var res = Context.Orders
               .Join(Context.OrderDetails, a => a.OrderId, b => b.OrderId, (a, b) => new
               {
                   a.OrderId,
                   a.OrderDate,
                   b.Quantity
               })
               .Where(x => x.OrderDate.HasValue
                && x.OrderDate.Value.Date >= date.NgayBatDau.Date
                && x.OrderDate.Value.Date <= date.NgayKetThuc.Date).ToList();

            var data = res.GroupBy(x => x.OrderDate)
                .Select(x => new
                {
                    x.First().OrderId,
                    x.First().OrderDate,
                    SoLuongHangHoa = x.Sum(t => t.Quantity)
                }).ToList();
            return data;
        }
    }
}
