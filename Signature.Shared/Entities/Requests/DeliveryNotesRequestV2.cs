namespace Signature.Shared.Entities.Requests
{
    public class DeliveryNotesRequestV2
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

        /// <summary>
        /// BuscarPor
        /// </summary>
        public string BuscarPor { get; set; }

        #endregion

        #region Constructor

        public DeliveryNotesRequestV2()
        {
        }

        private DeliveryNotesRequestV2(string _codigoEmpresa, string _proveedor)
        {
            CodigoEmpresa = _codigoEmpresa;
            Proveedor = _proveedor;
        }

        #endregion
    }
}