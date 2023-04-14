using System;
using System.Collections.Generic;

namespace Envanter.Model;

public partial class Person
{
    public long Id { get; set; }

    public string PersonName { get; set; } = null!;

    public string PersonLastName { get; set; } = null!;

    public string IdentityNo { get; set; } = null!;

    public string? RecordNo { get; set; }

    public virtual ICollection<PersonWare> PersonWares { get; set; } = new List<PersonWare>();
}
