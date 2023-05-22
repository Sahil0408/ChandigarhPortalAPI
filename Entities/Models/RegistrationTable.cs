using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class RegistrationTable
{
    public int RegId { get; set; }

    public string? Fname { get; set; }

    public string? Lname { get; set; }

    public string? PhoneNo { get; set; }

    public int? CityId { get; set; }

    public int? StateId { get; set; }

    public int? CountryId { get; set; }

    public virtual CityTable? City { get; set; }

    public virtual CountryTable? Country { get; set; }

    public virtual ICollection<Login> Logins { get; set; } = new List<Login>();

    public virtual StateTable? State { get; set; }
}
