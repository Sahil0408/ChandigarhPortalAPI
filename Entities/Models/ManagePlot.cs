using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class ManagePlot
{
    public int Id { get; set; }

    public string? PlotNo { get; set; }

    public string? Block { get; set; }

    public string? PlotSize { get; set; }

    public string? Unit { get; set; }

    public string? Price { get; set; }

    public string? TokenAmount { get; set; }
}
