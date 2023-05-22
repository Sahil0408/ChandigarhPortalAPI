using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class CompanyDetail
{
    public int CompanyId { get; set; }

    public string? CompanyName { get; set; }

    public string? Address { get; set; }

    public int? CityId { get; set; }

    public int? StateId { get; set; }

    public string? Pin { get; set; }

    public string? ContactNo { get; set; }

    public string? Email { get; set; }

    public virtual CityTable? City { get; set; }

    public virtual ICollection<CompanyContactDetail> CompanyContactDetails { get; set; } = new List<CompanyContactDetail>();

    public virtual StateTable? State { get; set; }
}
