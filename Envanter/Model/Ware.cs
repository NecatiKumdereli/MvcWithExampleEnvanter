using System;
using System.Collections.Generic;

namespace Envanter.Model;

public partial class Ware
{
    public long Id { get; set; }

    public string WareName { get; set; } = null!;

    public string WareDetail { get; set; } = null!;

    public virtual ICollection<PersonWare> PersonWares { get; set; } = new List<PersonWare>();
}
