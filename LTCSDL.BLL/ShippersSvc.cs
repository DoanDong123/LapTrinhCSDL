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
    public class ShippersSvc : GenericSvc<ShippersRep, Shippers>
    {
        public int themShipper(ShippersReq req)
        {
            Shippers shipper = new Shippers();
            shipper.CompanyName = req.CompanyName;
            shipper.Phone = req.Phone;

            return _rep.themShipper(shipper);
        }

        public int UpdateShipper(ShippersReq req)
        {
            Shippers shipper = new Shippers();
            shipper.ShipperId = req.ShipperID;
            shipper.CompanyName = req.CompanyName;
            shipper.Phone = req.Phone;

            return _rep.UpdateShipper(shipper);

        }

        public SingleRsp UpdateShipper_Linq(ShippersReq req)
        {
            var res = new SingleRsp();
            Shippers shipper = new Shippers();
            shipper.ShipperId = req.ShipperID;
            shipper.CompanyName = req.CompanyName;
            shipper.Phone = req.Phone;

            res = _rep.UpdateShipper_Linq(shipper);

            return res;
        }

        public object DanhSachShipperTheoThangNam_Linq(MonthYearReq key)
        {
            return _rep.DanhSachShipperTheoThangNam_Linq(key);
        }
    }
}
