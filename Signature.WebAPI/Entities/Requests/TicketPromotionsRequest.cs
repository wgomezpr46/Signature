using System.ComponentModel.DataAnnotations;

namespace Signature.WebAPI.Entities.Requests
{
    public class TicketPromotionsRequest : IEquatable<TicketPromotionsRequest>
    {
        #region Properties

        public string PosGuid { get; set; }

        public string CashBoxId { get; set; }

        public string OperatorCode { get; set; }

        public string DocumentId { get; set; }

        public string SeriesId { get; set; }

        public string CurrencyId { get; set; }

        public string Date { get; set; }

        public string Kilometers { get; set; }

        public string CustomerId { get; set; }

        public string CardId { get; set; }

        public string Plate { get; set; }

        public string AnnulatedDocument { get; set; }

        public string TotalAmountWithTax { get; set; }

        public string TotalTaxableAmount { get; set; }

        public string TotalTaxAmount { get; set; }

        public string DiscountPercentage { get; set; }

        public string GivenAmount { get; set; }

        public string ChangeDelivered { get; set; }

        [Required]
        public List<ItemsDetail> ItemsDetails { get; set; }

        public List<PaymentDetail> PaymentDetails { get; set; }

        public List<ClassExtraData> ExtraData { get; set; }

        public string SeriesType { get; set; }

        public string TotalDiscountedAmount { get; set; }

        public string BusinessDate { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Empty constructor required by some serializers.
        /// Use Articulo.Builder() for instance creation instead.
        /// </summary>
        //[Obsolete]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public TicketPromotionsRequest()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
        }
        #endregion

        #region Clases
        /// <summary>
        /// Clase ItemsDetail
        /// </summary>
        public class ItemsDetail
        {
            #region Propiedades
            [Required]
            [RegularExpression(@"^-?(?!0\d|$)\d*(\.\d{1,2})?$", ErrorMessage = " - El campo Quantity solo acepta valores numericos hasta con dos decimales, usando el caracter punto como separardor decimal. ")]
            public string Quantity { get; set; }

            [Required]
            [RegularExpression(@"^-?(?!0\d|$)\d*", ErrorMessage = " El campo LineNumber solo acepta valores numericos. ")]
            public string LineNumber { get; set; }

            [Required]
            [RegularExpression(@"^-?(?!0\d|$)\d*(\.\d{1,2})?$", ErrorMessage = " El campo TotalLineAmount solo acepta valores numericos hasta con dos decimales, usando el caracter punto como separardor decimal. ")]
            public string TotalLineAmount { get; set; }

            [Required]
            [RegularExpression(@"^(?!0\d|$)\d*(\.\d{1,2})?$", ErrorMessage = " El campo UnitaryPriceWithTax solo acepta valores numericos hasta con dos decimales, usando el caracter punto como separardor decimal. ")]
            public string UnitaryPriceWithTax { get; set; }

            //[Required]
            [RegularExpression(@"^-?(?!0\d|$)\d*(\.\d{1,3})?$", ErrorMessage = " El campo TotalDiscountedAmount solo acepta valores numericos hasta con tres decimales, usando el caracter punto como separardor decimal. ")]
            public string TotalDiscountedAmount { get; set; }

            [Required]
            public string ReferenceId { get; set; }

            public string Description { get; set; }

            [Required]
            [RegularExpression(@"^(?!0\d|$)\d*(\.\d{1,2})?$", ErrorMessage = " El campo DiscountPercentage solo acepta valores numericos hasta con dos decimales, usando el caracter punto como separardor decimal. ")]
            public string DiscountPercentage { get; set; }

            [Required]
            public string TaxPercentage { get; set; }

            [Required]
            [RegularExpression(@"^-?(?!0\d|$)\d*(\.\d{1,2})?$", ErrorMessage = " El campo TotalTaxAmount solo acepta valores numericos hasta con dos decimales, usando el caracter punto como separardor decimal. ")]
            public string TotalTaxAmount { get; set; }

            public List<PromotionsApplied> PromotionsApplied { get; set; }
            #endregion

            #region Constructor
            public ItemsDetail()
            {
                Quantity = string.Empty;
                LineNumber = string.Empty;
                TotalLineAmount = string.Empty;
                UnitaryPriceWithTax = string.Empty;
                TotalDiscountedAmount = string.Empty;
                ReferenceId = string.Empty;
                Description = string.Empty;
                DiscountPercentage = string.Empty;
                TaxPercentage = string.Empty;
                TotalTaxAmount = string.Empty;
                PromotionsApplied = new List<PromotionsApplied>();
            }
            #endregion
        }

        /// <summary>
        /// Clase PaymentDetail
        /// </summary>
        public class PaymentDetail
        {
            #region Propiedades
            [Required]
            public string PaymentMethodId { get; set; }
            [Required]
            public string CurrencyId { get; set; }
            [Required]
            [RegularExpression(@"^-?(?!0\d|$)\d*(\.\d{1,2})?$", ErrorMessage = " - El campo Amount solo acepta valores numericos hasta con dos decimales, usando el caracter punto como separardor decimal. ")]
            public string Amount { get; set; }
            [Required]
            [RegularExpression(@"^(?!0\d|$)\d*(\.\d{1,2})?$", ErrorMessage = " El campo ExchangeFactor solo acepta valores numericos hasta con dos decimales, usando el caracter punto como separardor decimal. ")]
            public string ExchangeFactor { get; set; }
            [Required]
            [RegularExpression(@"^-?(?!0\d|$)\d*(\.\d{1,2})?$", ErrorMessage = " El campo GivenAmount solo acepta valores numericos hasta con dos decimales, usando el caracter punto como separardor decimal. ")]
            public string GivenAmount { get; set; }
            public List<cExtraInfo> ExtraInfo { get; set; }
            #endregion

            #region Constructor
            public PaymentDetail()
            {
                PaymentMethodId = string.Empty;
                CurrencyId = string.Empty;
                Amount = string.Empty;
                ExchangeFactor = string.Empty;
                GivenAmount = string.Empty;
                ExtraInfo = new List<cExtraInfo>();
                //{
                //    new cExtraInfo()
                //};
            }
            #endregion
        }

        /// <summary>
        /// Clase PromotionsApplied
        /// </summary>
        public class PromotionsApplied
        {
            #region Propiedades
            [Required]
            public string PromotionId { get; set; }

            public string PromotionDescription { get; set; }

            //[Required]
            [RegularExpression(@"^-?(?!0\d|$)\d*(\.\d{1,3})?$", ErrorMessage = " - El campo TotalDiscountedAmount solo acepta valores numericos negativos hasta con tres decimales, usando el caracter punto como separardor decimal. ")]
            public string TotalDiscountedAmount { get; set; }

            [Required]
            [RegularExpression(@"^(?!0\d|$)\d*", ErrorMessage = " El campo TotalDiscountPercentage solo acepta valores numericos enteros. Por defecto cero. ")]
            public string TotalDiscountPercentage { get; set; }
            #endregion

            #region Constructor
            public PromotionsApplied()
            {
                PromotionId = string.Empty;
                PromotionDescription = string.Empty;
                TotalDiscountedAmount = string.Empty;
                TotalDiscountPercentage = string.Empty;
            }
            #endregion
        }

        /// <summary>
        /// Clase ExtraData
        /// </summary>
        public class ClassExtraData
        {
            #region Propiedades
            public string Key { get; set; }
            public string Value { get; set; }
            #endregion

            #region Constructor
            public ClassExtraData()
            {
                Key = string.Empty;
                Value = string.Empty;
            }
            #endregion
        }

        /// <summary>
        /// Clase ExtraInfo
        /// </summary>
        public class cExtraInfo
        {
            #region Propiedades
            public string Key { get; set; }
            public string Value { get; set; }
            #endregion

            #region Constructor
            public cExtraInfo()
            {
                Key = string.Empty;
                Value = string.Empty;
            }
            #endregion
        }

        #endregion

        #region Methods
        public override string ToString()
        {
            return ToString();
        }

#pragma warning disable CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        public override bool Equals(object obj)
#pragma warning restore CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
        {
            return Equals(obj);
        }

#pragma warning disable CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
        public bool Equals(TicketPromotionsRequest other)
#pragma warning restore CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
        {
            return Equals((object)other);
        }

        public override int GetHashCode()
        {
            return GetHashCode();
        }
        #endregion
    }
}