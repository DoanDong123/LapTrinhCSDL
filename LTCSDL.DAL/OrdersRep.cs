using LTCSDL.Common.DAL;
using LTCSDL.Common.Req;
using LTCSDL.DAL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LTCSDL.DAL
{
    public class OrdersRep : GenericRep<NorthwindContext, Orders>
    {
        public List<object> pro_TimKiemOrderTheoCtyVaNhanVien (DatePageSize keyword)
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

                cmd.CommandText = "pro_TimKiemOrderTheoCtyVaNhanVien";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@keyword", keyword.Keyword);
                cmd.Parameters.AddWithValue("@page", keyword.Page);
                cmd.Parameters.AddWithValue("@size", keyword.Size);

                da.SelectCommand = cmd;
                da.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        var x = new
                        {
                            STT = row["STT"],
                            OrderID = row["OrderID"],
                            CustomerID = row["CustomerID"],
                            EmployeeID = row["EmployeeID"],
                            OrderDate = row["OrderDate"]
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

        public object DanhSachDonHangTheoTenKhachHang_Linq(DatePageSize keyword)
        {
            

            var res = Context.Orders
                .Where(x => x.OrderDate.HasValue && x.OrderDate.Value.Date == keyword.date.Date).ToList();

            var offset = (keyword.Page - 1) * keyword.Size;
            var totalRecord = res.Count();
            int totalPage = (totalRecord % keyword.Size) == 0 ? (int)(totalRecord / keyword.Size) : (int)(totalRecord / keyword.Size) + 1;

            var data = res.Select(x => new
            {
               x.OrderId,
               x.CustomerId,
               x.OrderDate,
               x.ShipAddress
            })
            .OrderBy(x => x.OrderId).Skip(offset).Take(keyword.Size).ToList();
            var result = new
            {
                Data = data,
                TotalRecord = totalRecord,
                TotalPage = totalPage,
                Page = keyword.Page,
                Size = keyword.Size
            };

            return result;
        }

        public object SoLuongHangHoaTrongKhoangThoiGian_Linq(BetweenDateReq date)
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
                   x.First().OrderDate,
                   TongSoLuong = x.Sum(t => t.Quantity)
                }).ToList();
            return data;
        }
    }
}
