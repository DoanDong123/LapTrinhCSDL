using LTCSDL.Common.DAL;
using LTCSDL.Common.Req;
using LTCSDL.Common.Rsp;
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
    public class ShippersRep : GenericRep<NorthwindContext, Shippers>
    {

        public int themShipper(Shippers shipper)
        {
            int res = 0;
            var cnn = (SqlConnection)Context.Database.GetDbConnection();
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            try
            {
                string strSQL = "Insert into Shippers(CompanyName, Phone) values(N'" + shipper.CompanyName + "', '" + shipper.Phone + "')";

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

        public int UpdateShipper(Shippers shipper)
        {
            int res = 0;
            var cnn = (SqlConnection)Context.Database.GetDbConnection();
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            try
            {
                string strSQL = "Update Shippers set CompanyName = '" + shipper.CompanyName + 
                    "', Phone = '" + shipper.Phone + "' where ShipperID = " + shipper.ShipperId;
                    

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

        public SingleRsp UpdateShipper_Linq(Shippers shipper)
        {
            var res = new SingleRsp();
            using (var context = new NorthwindContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var t = context.Shippers.Update(shipper);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }   

        public object DanhSachShipperTheoThangNam_Linq(MonthYearReq key)
        {
            var res = Context.Shippers
               .Join(Context.Orders, a => a.ShipperId, b => b.ShipVia, (a, b) => new
               {
                   a.ShipperId,
                   a.CompanyName,
                   a.Phone,
                   b.ShippedDate,
                   b.Freight
               })
               .Where(x => x.ShippedDate.HasValue
                && x.ShippedDate.Value.Month == key.Thang
                && x.ShippedDate.Value.Year <= key.Nam).ToList();

            var data = res.GroupBy(x => x.ShippedDate)
                .Select(x => new
                {
                    x.First().ShipperId,
                    x.First().CompanyName,
                    x.First().Phone,
                    x.First().ShippedDate,
                    TongSoTien = x.Sum(t => t.Freight)
                }).ToList();
            return data;
        }
    }
}
