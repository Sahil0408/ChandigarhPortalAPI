using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class StateTable
{
    public int StateId { get; set; }

    public string? StateName { get; set; }

    public int? CountryId { get; set; }

    public virtual ICollection<CompanyDetail> CompanyDetails { get; set; } = new List<CompanyDetail>();

    public virtual CountryTable? Country { get; set; }

    public virtual ICollection<RegistrationTable> RegistrationTables { get; set; } = new List<RegistrationTable>();
}
