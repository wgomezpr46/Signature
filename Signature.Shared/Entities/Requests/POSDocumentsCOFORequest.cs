using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Signature.Shared.Entities.Requests
{
    public class POSDocumentsCOFORequest : IEquatable<POSDocumentsCOFORequest>
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
        public POSDocumentsCOFORequest()
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
                Quantity = String.Empty;
                LineNumber = String.Empty;
                TotalLineAmount = String.Empty;
                UnitaryPriceWithTax = String.Empty;
                TotalDiscountedAmount = String.Empty;
                ReferenceId = String.Empty;
                Description = String.Empty;
                DiscountPercentage = String.Empty;
                TaxPercentage = String.Empty;
                TotalTaxAmount = String.Empty;
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
                PaymentMethodId = String.Empty;
                CurrencyId = String.Empty;
                Amount = String.Empty;
                ExchangeFactor = String.Empty;
                GivenAmount = String.Empty;
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
                PromotionId = String.Empty;
                PromotionDescription = String.Empty;
                TotalDiscountedAmount = String.Empty;
                TotalDiscountPercentage = String.Empty;
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
                Key = String.Empty;
                Value = String.Empty;
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
                Key = String.Empty;
                Value = String.Empty;
            }
            #endregion
        }

        #endregion

        #region Methods
        public override string ToString()
        {
            return this.ToString();
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }

        public bool Equals(POSDocumentsRequest other)
        {
            return Equals((object)other);
        }

        public bool Equals(POSDocumentsCOFORequest other)
        {
            return Equals((object)other);
        }
        #endregion
    }
}