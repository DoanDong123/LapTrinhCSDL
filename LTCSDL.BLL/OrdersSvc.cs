using LTCSDL.Common.BLL;
using LTCSDL.Common.Req;
using LTCSDL.Common.Rsp;
using LTCSDL.DAL;
using LTCSDL.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LTCSDL.BLL
{
    public class OrdersSvc : GenericSvc<OrdersRep, Orders>
    {
        #region -- Overrides --

        /// <summary>
        /// Read single object
        /// </summary>
        /// <param name="id">Primary key</param>
        /// <returns>Return the object</returns>
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="m">The model</param>
        /// <returns>Return the result</returns>

        public List<object> pro_TimKiemOrderTheoCtyVaNhanVien(DatePageSize keyword)
        {
            return _rep.pro_TimKiemOrderTheoCtyVaNhanVien(keyword);
        }

        public object DanhSachDonHangTheoTenKhachHang_Linq(DatePageSize keyword)
        {
            return _rep.DanhSachDonHangTheoTenKhachHang_Linq(keyword);
        }

        public object SoLuongHangHoaTrongKhoangThoiGian_Linq(BetweenDateReq date)
        {
            return _rep.SoLuongHangHoaTrongKhoangThoiGian_Linq(date);
        }

        #endregion
    }
}
