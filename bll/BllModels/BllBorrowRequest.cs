using dal.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BllModels
{
    public class BllBorrowRequest
    {
        public int RequestId { get; set; }

        public int? ItemId { get; set; }

        public int UserId { get; set; }

        public int RequestStatus { get; set; }

        public DateTime? RequestDate { get; set; }

        public DateTime? ApprovalDate { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? UntilDate { get; set; }

        public decimal? TotalPrice { get; set; }

    
    }
}
