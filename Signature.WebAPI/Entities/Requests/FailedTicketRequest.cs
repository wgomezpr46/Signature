namespace Signature.WebAPI.Entities.Requests
{
    public class FailedTicketRequest
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        /// <summary>
        /// CodigoEmpresa
        /// </summary>
        public string Empresa { get; set; }
        /// <summary>
        /// FechaIni
        /// </summary>
        public string FechaIni { get; set; }
        /// <summary>
        /// FechaFin
        /// </summary>
        public string FechaFin { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
