using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LTCSDL.BLL;
using LTCSDL.Common.Req;
using LTCSDL.Common.Rsp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LTCSDL.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController : ControllerBase
    {
        private readonly ShippersSvc _svc;

        public ShippersController()
        {
            _svc = new ShippersSvc();
        }

        [HttpPost("themShipper")]
        public IActionResult themShipper([FromBody]ShippersReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.themShipper(req);
            return Ok(res);
        }

        [HttpPost("update-Shipper")]
        public IActionResult UpdateShipper([FromBody]ShippersReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.UpdateShipper(req);
            return Ok(res);
        }

        [HttpPost("update-Shipper-Linq")]
        public IActionResult UpdateShipper_Linq([FromBody]ShippersReq req)
        {
            var res = _svc.UpdateShipper_Linq(req);
            return Ok(res);
        }

        [HttpPost("DanhSachShipperTheoThangNam_Linq")]
        public IActionResult DanhSachShipperTheoThangNam_Linq([FromBody] MonthYearReq key)
        {
            var res = new SingleRsp();
            res.Data = _svc.DanhSachShipperTheoThangNam_Linq(key);
            return Ok(res);
        }

    }
}