namespace BLL.BllModels
{
    public class BllBorrowRequest
    {
        public int RequestId { get; set; }

        public int? ItemId { get; set; }

        public int UserId { get; set; }


        public DateTime? RequestDate { get; set; }

        public DateTime? ApprovalDate { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? UntilDate { get; set; }

        public decimal? TotalPrice { get; set; }


    }
}
