using DAL.models;
using System;
using System.Collections.Generic;


namespace BLL.BllModels;

public  class BllBorrowApprovalRequest
{
    public int RequestId { get; set; }

    public int? ItemId { get; set; }

    public int UserId { get; set; }

    public int RequestStatus { get; set; }

    public DateTime? RequestDate { get; set; }

    public DateTime? ApprovalDate { get; set; }

    public int LibrariansId { get; set; }

    public bool? IsReturned { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? UntilDate { get; set; }



}
