using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class CompanyContactDetail
{
    public int Id { get; set; }

    public int? CompanyId { get; set; }

    public string? ContactPersonName { get; set; }

    public string? ContactPersonDesignation { get; set; }

    public string? ContactPersonEmailId { get; set; }

    public string? ContactPersonPhoneNo { get; set; }

    public bool? Status { get; set; }

    public virtual CompanyDetail? Company { get; set; }
}
