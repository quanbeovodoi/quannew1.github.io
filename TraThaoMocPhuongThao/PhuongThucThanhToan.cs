﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraThaoMocPhuongThao
{
    class PhuongThucThanhToan
    {
        public int Ma { get; set; }
        public string HinhThuc { get; set; }
        public int PhiThanhToan { get; set; }
        public override string ToString()
        {
            return this.HinhThuc;
        }
    }
}
