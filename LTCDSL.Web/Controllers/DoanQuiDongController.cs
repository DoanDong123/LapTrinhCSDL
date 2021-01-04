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
    public class DoanQuiDongController : ControllerBase
    {
        private readonly DoanQuiDongSvc _svc;

        public DoanQuiDongController()
        {
            _svc = new DoanQuiDongSvc();
        }
        
        // Câu 2 đề 5
        [HttpPost("pro_SanPhamKhongCoDonHangTrongNgay")]
        public IActionResult pro_SanPhamKhongCoDonHangTrongNgay([FromBody] DoanQuiDongReq keyword)
        {
            var res = new SingleRsp();
            res.Data = _svc.pro_SanPhamKhongCoDonHangTrongNgay(keyword);
            return Ok(res);
        }

        //Câu 3 đề 5

        [HttpPost("Them_Product")]
        public IActionResult Them_Product([FromBody]DoanQuiDongReq_cau3 req)
        {
            var res = new SingleRsp();
            res.Data = _svc.Them_Product(req);
            return Ok(res);
        }

        //Câu 4 đề 5

        [HttpPost("SoLuongHangHoaTrongKhoangThoiGian_Linq")]
        public IActionResult SoLuongHangHoaTrongKhoangThoiGian_Linq([FromBody] DoanQuiDongReq_cau4 date)
        {
            var res = new SingleRsp();
            res.Data = _svc.SoLuongHangHoaTrongKhoangThoiGian_Linq(date);
            return Ok(res);
        }
    }
}