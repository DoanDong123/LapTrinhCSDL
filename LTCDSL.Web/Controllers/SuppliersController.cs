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
    public class SuppliersController : ControllerBase
    {
        private readonly SuppliersSvc _svc;

        public SuppliersController()
        {
            _svc = new SuppliersSvc();
        }

        [HttpPost("pro_ThemMoiSupplier")]
        public IActionResult pro_ThemMoiSupplier([FromBody] SuppliersReq keyword)
        {
            var res = new SingleRsp();
            res.Data = _svc.pro_ThemMoiSupplier(keyword);
            return Ok(res);
        }

        [HttpPost("pro_UpdateSupplier")]
        public IActionResult pro_UpdateSupplier([FromBody] SuppliersReq keyword)
        {
            var res = new SingleRsp();
            res.Data = _svc.pro_UpdateSupplier(keyword);
            return Ok(res);
        }
    }
}