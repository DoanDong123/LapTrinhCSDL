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
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeesSvc _svc;

        public EmployeesController()
        {
            _svc = new EmployeesSvc();
        }

        [HttpPost("pro_doanhthutheongaythangnam")]
        public IActionResult pro_doanhthutheongaythangnam([FromBody] SimpleReq date)
        {
            var res = new SingleRsp();
            res.Data = _svc.pro_doanhthutheongaythangnam(date.Keyword);
            return Ok(res);
        }

        [HttpPost("pro_doanhthutheothoigian")]
        public IActionResult pro_doanhthutheothoigian([FromBody] BetweenDateReq date)
        {
            var res = new SingleRsp();
            res.Data = _svc.pro_doanhthutheothoigian(date.begin_string, date.end_string);
            return Ok(res);
        }

        [HttpPost("DoanhThuTheoNgayThangNam_Linq")]
        public IActionResult DoanhThuTheoNgayThangNam_Linq([FromBody] DateTime date)
        {
            var res = new SingleRsp();
            res.Data = _svc.DoanhThuTheoNgayThangNam_Linq(date);
            return Ok(res);
        }
    }
}