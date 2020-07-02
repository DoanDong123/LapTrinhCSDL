using LTCSDL.Common.BLL;
using LTCSDL.Common.Rsp;
using LTCSDL.DAL;
using LTCSDL.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LTCSDL.BLL
{
    public class EmployeesSvc : GenericSvc<EmployeesRep, Employees>
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
        
        public List<object> pro_doanhthutheongaythangnam (string date)
        {
            return _rep.pro_doanhthutheongaythangnam(date);
        }

        public List<object> pro_doanhthutheothoigian(string beginDate, string endDate)
        {
            return _rep.pro_doanhthutheothoigian(beginDate, endDate);
        }

        public object DoanhThuTheoNgayThangNam_Linq(DateTime date)
        {
            return _rep.DoanhThuTheoNgayThangNam_Linq(date);
        }

        #endregion
    }
}
