using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Domain.Entities;

public abstract class Entity
{
    public int Id { get; protected set; }
}
