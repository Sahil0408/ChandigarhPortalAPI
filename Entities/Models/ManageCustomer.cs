using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class ManageCustomer
{
    public int CustomerId { get; set; }

    public int? CompanyId { get; set; }

    public string? CustomerName { get; set; }

    public string? ParentName { get; set; }

    public string? CustomerEmail { get; set; }

    public string? Contact { get; set; }

    public int? Amount { get; set; }

    public int? TransactionId { get; set; }

    public string? PlotSize { get; set; }
}
