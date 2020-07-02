using System;
using System.Collections.Generic;
using System.Text;

namespace LTCSDL.Common.Req
{
    public class DatePageSize
    {
        public string Keyword { get; set; }
        public DateTime date { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
