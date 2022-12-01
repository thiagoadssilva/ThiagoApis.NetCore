using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APiDotNet6.Application.DTOs
{
    public class PurchateDetailDTO
    {
        public int Id { get; set; }
        public string Person { get; set; }
        public string Product { get; set; }
        public DateTime Date { get; set; }

    }
}
