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
    public class DoanQuiDongSvc : GenericSvc<DoanQuiDongRep, Products>
    {
        //Câu 2 đề 5
        public List<object> pro_SanPhamKhongCoDonHangTrongNgay(DoanQuiDongReq keyword)
        {
            return _rep.pro_SanPhamKhongCoDonHangTrongNgay(keyword);
        }

        // Câu 3 đề 5
        public int Them_Product(DoanQuiDongReq_cau3 req)
        {
            Products products = new Products();
            products.ProductName = req.ProductName;
            products.Discontinued = req.Discontinued;

            return _rep.Them_Product(products);
        }

        //Câu 4 đề 5
        public object SoLuongHangHoaTrongKhoangThoiGian_Linq(DoanQuiDongReq_cau4 date)
        {
            return _rep.SoLuongHangHoaTrongKhoangThoiGian_Linq(date);
        }
    }
}
