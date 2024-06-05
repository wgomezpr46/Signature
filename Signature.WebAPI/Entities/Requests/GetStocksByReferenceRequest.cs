namespace Signature.WebAPI.Entities.Requests
{
    public class GetStocksByReferenceRequest
    {
        public string Company { get; set; }
        public string Store { get; set; }
        public List<Articlelist> articlelist { get; set; }
    }

    public class Articlelist
    {
        public string Reference { get; set; }
    }
}