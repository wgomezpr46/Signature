namespace Signature.Shared.Entities.Requests
{
    public class FailedTicketRequest
    {
        #region Propiedades
        /// <summary>
        /// CodigoEmpresa
        /// </summary>
        public string CodigoEmpresa { get; set; }

        /// <summary>
        /// FechaIni
        /// </summary>
        public string FechaIni { get; set; }

        /// <summary>
        /// FechaFin
        /// </summary>
        public string FechaFin { get; set; }

        /// <summary>
        /// Operador
        /// </summary>
        public string Operador { get; set; }
        #endregion
    }
}