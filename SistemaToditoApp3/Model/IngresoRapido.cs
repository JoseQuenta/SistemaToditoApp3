using System.Collections.Generic;

namespace SistemaToditoApp3.Model
{
    public class IngresoRapido
    {
        public int IdIngresoRapido { get; set; }
        public Usuario oUsuario { get; set; }
        public string numeroDocumento { get; set; }
        public string numeroSerie { get; set; }
        public string numeroCorrelativo { get; set; }
        public bool procesado { get; set; }
        public string fechaRegistro { get; set; }
        public List<DetalleIngresoRapido> oDetalleIngresoRapido { get; set; }
    }
}