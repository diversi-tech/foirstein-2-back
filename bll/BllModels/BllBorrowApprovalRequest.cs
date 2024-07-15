using System;
using System.Collections.Generic;
using dal.models;

namespace BLL.BllModels;

public  class BllBorrowApprovalRequest
{
    public int RequestId { get; set; }

    public int ItemId { get; set; }

    public int UserId { get; set; }

    public int RequestStatus { get; set; }

    public DateTime RequestDate { get; set; }

    public DateTime? ApprovalDate { get; set; }

}
