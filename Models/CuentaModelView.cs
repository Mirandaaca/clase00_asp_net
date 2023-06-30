﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace clase00_asp_net.Models
{
    public class CuentaModelView
    {
        public Cuenta cuenta { get; set; }
        public List<Lenguaje> lenguajes { get; set; }
        public SelectList cargos { get; set; }
    }
}
