﻿using System;
using System.Collections.Generic;

namespace Envanter.Model;

public partial class PersonWare
{
    public long Id { get; set; }

    public long PersonId { get; set; }

    public long WareId { get; set; }

    public long? Detail { get; set; }

    public string? CreateDate { get; set; }

    public virtual Person Person { get; set; } = null!;

    public virtual Ware Ware { get; set; } = null!;
}
