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
    public class SuppliersSvc : GenericSvc<SuppliersRep, Suppliers>
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

        public List<object> pro_ThemMoiSupplier(SuppliersReq keyword)
        {
            return _rep.pro_ThemMoiSupplier(keyword);
        }

        public List<object> pro_UpdateSupplier(SuppliersReq keyword)
        {
            return _rep.pro_UpdateSupplier(keyword);
        }

        #endregion
    }
}
