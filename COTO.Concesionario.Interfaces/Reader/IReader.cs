﻿using COTO.Concesionario.Interfaces.DTO;

namespace COTO.Concesionario.Interfaces.Reader
{
    public interface IReader
    {
        public List<VentaDTO>? Ventas { get; set; }
        public Task<List<VentaDTO>> GetVentas();
        public Task GuardarVentas();
    }
}
