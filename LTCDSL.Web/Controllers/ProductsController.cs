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
    public class ProductsController : ControllerBase
    {
        private readonly ProductsSvc _svc;

        public ProductsController()
        {
            _svc = new ProductsSvc();
        }

        [HttpPost("pro_SanPhamKhongCoDonHangTrongNgay")]
        public IActionResult pro_SanPhamKhongCoDonHangTrongNgay([FromBody] DatePageSize keyword)
        {
            var res = new SingleRsp();
            res.Data = _svc.pro_SanPhamKhongCoDonHangTrongNgay(keyword);
            return Ok(res);
        }
    }
}