using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class CountryTable
{
    public int CountryId { get; set; }

    public string? CountryName { get; set; }

    public virtual ICollection<RegistrationTable> RegistrationTables { get; set; } = new List<RegistrationTable>();

    public virtual ICollection<StateTable> StateTables { get; set; } = new List<StateTable>();
}
