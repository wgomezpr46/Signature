namespace Signature.WebAPI.Entities.Requests
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
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public DeliveryNotesRequestV2()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private DeliveryNotesRequestV2(string _codigoEmpresa, string _proveedor)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            CodigoEmpresa = _codigoEmpresa;
            Proveedor = _proveedor;
        }
        #endregion
    }
}
