namespace Signature.Shared.Entities.Requests
{
    /// <summary>
    /// DeliveryNotesRequest
    /// </summary>
    public class DeliveryNotesRequest
    {
        #region Propiedades

        /// <summary>
        /// CodigoEmpresa
        /// </summary>
        public string CodigoEmpresa { get; set; }

        /// <summary>
        /// Numero_Albaran
        /// </summary>
        public string NumeroAlbaran { get; set; }

        /// <summary>
        /// Proveedor
        /// </summary>
        public string Proveedor { get; set; }

        /// <summary>
        /// FechaIni
        /// </summary>
        public string FechaIni { get; set; }

        /// <summary>
        /// FechaFin
        /// </summary>
        public string FechaFin { get; set; }

        #endregion

        #region Constructor

        public DeliveryNotesRequest()
        {
        }

        private DeliveryNotesRequest(string _codigoEmpresa, string _proveedor)
        {
            CodigoEmpresa = _codigoEmpresa;
            Proveedor = _proveedor;
        }

        #endregion
    }
}