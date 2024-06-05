namespace Signature.WebAPI.Entities.Requests
{
    public class ArticlesRequest
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string codigoEmpresa { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public int NumeroPagina { get; set; }
    }
}