namespace Signature.WebAPI.Entities.Reposnse
{
    public class ArticleStockResponse
    {
        public List<ArticleStock> ArticleList { get; set; }
    }

    public class ArticleStock
    {
        public string BarCode { get; set; }
        public string Article { get; set; }
        public string Store { get; set; }
        public float Stock { get; set; }
        public float StockMin { get; set; }
        public float StockMax { get; set; }
        public string Reference { get; set; }
        public string Name { get; set; }
        public string TypeCode { get; set; }
        public string Type { get; set; }
        public float Pvp { get; set; }
        public float Iva { get; set; }
        public float PvpDto { get; set; }
        public string Tarifa { get; set; }
        public string CategoryCode { get; set; }
        public string Category { get; set; }
        public string FamilyCode { get; set; }
        public string Family { get; set; }
        public string SubFamilyCode { get; set; }
        public string SubFamily { get; set; }
    }
}