namespace Signature.WebAPI.Entities.Requests
{
    public class ArticleRequest
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        /// <summary>
        /// CodigoEmpresa
        /// </summary>
        public string CodigoEmpresa { get; set; }
        /// <summary>
        /// CodigoEAN
        /// </summary>
        public string CodigoEAN { get; set; }
        /// <summary>
        /// Referencia
        /// </summary>
        public string Referencia { get; set; }
        /// <summary>
        /// Caja
        /// </summary>
        public string Caja { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}