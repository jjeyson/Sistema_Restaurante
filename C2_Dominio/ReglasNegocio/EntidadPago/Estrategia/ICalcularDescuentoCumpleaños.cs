﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using C2_Dominio.Entidades;

namespace C2_Dominio.ReglasNegocio.EntidadPago.Estrategia
{
    public interface ICalcularDescuentoCumpleaños
    {
        Double calcularDescuentoCumpleaños(Double subTotal, Cliente cliente);
    }
}
