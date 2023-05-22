using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class CityTable
{
    public int CityId { get; set; }

    public string? CityName { get; set; }

    public int? StateId { get; set; }

    public virtual ICollection<CompanyDetail> CompanyDetails { get; set; } = new List<CompanyDetail>();

    public virtual ICollection<RegistrationTable> RegistrationTables { get; set; } = new List<RegistrationTable>();
}
