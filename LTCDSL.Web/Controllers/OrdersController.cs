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
    public class OrdersController : ControllerBase
    {
        private readonly OrdersSvc _svc;

        public OrdersController()
        {
            _svc = new OrdersSvc();
        }

        [HttpPost("pro_TimKiemOrderTheoCtyVaNhanVien")]
        public IActionResult pro_TimKiemOrderTheoCtyVaNhanVien([FromBody] DatePageSize keyword)
        {
            var res = new SingleRsp();
            res.Data = _svc.pro_TimKiemOrderTheoCtyVaNhanVien(keyword);
            return Ok(res);
        }

        [HttpPost("DanhSachDonHangTheoTenKhachHang_Linq")]
        public IActionResult DanhSachDonHangTheoTenKhachHang_Linq([FromBody] DatePageSize keyword)
        {
            var res = new SingleRsp();
            res.Data = _svc.DanhSachDonHangTheoTenKhachHang_Linq(keyword);
            return Ok(res);
        }

        [HttpPost("SoLuongHangHoaTrongKhoangThoiGian_Linq")]
        public IActionResult SoLuongHangHoaTrongKhoangThoiGian_Linq([FromBody] BetweenDateReq date)
        {
            var res = new SingleRsp();
            res.Data = _svc.SoLuongHangHoaTrongKhoangThoiGian_Linq(date);
            return Ok(res);
        }
    }
}