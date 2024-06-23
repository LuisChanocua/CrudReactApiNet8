using System;
using System.Collections.Generic;

namespace CruedReactApiNet8.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public double? Sueldo { get; set; }
}
