using Newtonsoft.Json;
using Signature.Shared.Entities.Requests;
using Signature.Shared.Helpers;
using Signature.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Signature.WebAPI2.Controllers
{
    public class SignatureController : ApiController
    {
        // POST: api/Signature/GeneratedSignature
        [HttpPost]
        public IHttpActionResult GeneratedSignature([FromBody] Object request, [FromUri] string TimeStamp, [FromUri] string Endpoint)
        {
            Request.Headers.TryGetValues("TimeStamp", out var strTimeStamp);
            Request.Headers.TryGetValues("Endpoint", out var strEndpoint);

            if ((!string.IsNullOrEmpty(strTimeStamp.FirstOrDefault()) || !string.IsNullOrEmpty(strEndpoint.FirstOrDefault())) && (string.IsNullOrEmpty(TimeStamp) && string.IsNullOrEmpty(Endpoint)))
            {
                TimeStamp = strTimeStamp.FirstOrDefault();
                Endpoint = strEndpoint.FirstOrDefault();
            }

            if ((!string.IsNullOrEmpty(TimeStamp) || !string.IsNullOrEmpty(Endpoint)) && (string.IsNullOrEmpty(strTimeStamp.FirstOrDefault()) && string.IsNullOrEmpty(strEndpoint.FirstOrDefault())))
            {
                List<string> timestamps = new List<string> { TimeStamp }; // Agrega TimeStamp a la lista
                List<string> endpoints = new List<string> { Endpoint }; // Agrega Endpoint a la lista

                strTimeStamp = timestamps;
                strEndpoint = endpoints;
            }

            if (string.IsNullOrEmpty(strTimeStamp.FirstOrDefault()) && string.IsNullOrEmpty(strEndpoint.FirstOrDefault()))
            {
                return BadRequest("TimeStamp y Endpoint son obligatorios");
            }

            string jsonString = JsonConvert.SerializeObject(request, Formatting.Indented);
            string sGenerateSignatureInput;

            switch (strEndpoint.ToString())
            {
                case "/GetArticle":
                case "/GetArticleType":
                case "/ilionservices4/COFOWSAPITPV/GetArticle":
                case "/ilionservices4/COFOWSInterface/api/Article/GetArticle/request":
                case "/IlionServices4/COFOWSInterface/api/Article/GetArticle/request":
                    var objArticleRequest = JsonConvert.DeserializeObject<ArticleRequest>(jsonString);
                    if (strEndpoint.ToString().Contains("COFOWSAPITPV")) { sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSAPITPV(objArticleRequest, strTimeStamp.FirstOrDefault()); }
                    if (strEndpoint.ToString().Contains("COFOWSInterface")) { sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSREST(objArticleRequest, strTimeStamp.FirstOrDefault()); }
                    else { sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSAPITPV(objArticleRequest, strTimeStamp.FirstOrDefault()); }
                    break;
                case "/GetPromotions":
                    var objTicketPromotionsRequest = JsonConvert.DeserializeObject<TicketPromotionsRequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSAPITPV(objTicketPromotionsRequest, strTimeStamp.FirstOrDefault());
                    break;
                case "/GetPromotionsNew":
                case "/ilionservices4/COFOWSAPITPV/GetPromotionsNew":
                case "/ilionServices4/COFOWSAPITPV/GetPromotionsNew":
                    var objTicketPromotionsRequestNew = JsonConvert.DeserializeObject<TicketPromotionsRequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSAPITPV(objTicketPromotionsRequestNew, strTimeStamp.FirstOrDefault());
                    break;
                case "/api/Promotion/GetListarPromocionNew/Request":
                case "/ilionservices4/COFOWSInterface/api/Promotion/GetListarPromocionNew/Request":
                    var objPromocionRequest = JsonConvert.DeserializeObject<CalculoPromocion>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSREST(objPromocionRequest, strTimeStamp.FirstOrDefault());
                    break;
                case "/SetTicket":
                case "/SetRefundTicket":
                    var objPOSDocumentsCOFORequest = JsonConvert.DeserializeObject<POSDocumentsCOFORequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSAPITPV(objPOSDocumentsCOFORequest, strTimeStamp.FirstOrDefault());
                    break;
                case "/GetDeliveryNotes":
                    var objDeliveryNotesRequest = JsonConvert.DeserializeObject<DeliveryNotesRequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSAPITPV(objDeliveryNotesRequest, strTimeStamp.FirstOrDefault());
                    break;
                case "/GetDeliveryNotesV2":
                    var objDeliveryNotesRequestV2 = JsonConvert.DeserializeObject<DeliveryNotesRequestV2>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSAPITPV(objDeliveryNotesRequestV2, strTimeStamp.FirstOrDefault());
                    break;
                case "/ListArticlesPaged":
                case "/IlionServices4/COFOWSInterface/api/ArticlesPaged/ListArticlesPagedFamilies/request":
                case "/api/ArticlesPaged/ListArticlesPagedFamilies/request":
                case "/ilionservices4/COFOWSInterface/api/ArticlesPaged/ListArticlesPagedFamilies/request":
                    var objArticlesRequest = JsonConvert.DeserializeObject<ArticlesRequest>(jsonString);
                    if (strEndpoint.ToString().Contains("COFOWSAPITPV")) { sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSAPITPV(objArticlesRequest, strTimeStamp.FirstOrDefault()); }
                    if (strEndpoint.ToString().Contains("COFOWSInterface")) { sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSREST(objArticlesRequest, strTimeStamp.FirstOrDefault()); }
                    else { sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSREST(objArticlesRequest, strTimeStamp.FirstOrDefault()); }
                    break;
                case "/ListArticlesPagedFamilies":
                    var objArticlesRequest_ = JsonConvert.DeserializeObject<ArticlesRequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSAPITPV(objArticlesRequest_, strTimeStamp.FirstOrDefault());
                    break;
                case "/GetSettingsLosses":
                    var objSettingsLossesRequest = JsonConvert.DeserializeObject<SettingsLossesRequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSAPITPV(objSettingsLossesRequest, strTimeStamp.FirstOrDefault());
                    break;
                case "/SetAdjustmentsLosses":
                    var objSetAdjustmentsLossesRequest = JsonConvert.DeserializeObject<SetAdjustmentsLossesRequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSAPITPV(objSetAdjustmentsLossesRequest, strTimeStamp.FirstOrDefault());
                    break;
                case "/SetClosingCash":
                case "/SetClosingCashTransaction": //No se encuentra el Endpoint en COFOWSAPITPV
                    var objCashRequest = JsonConvert.DeserializeObject<CashRequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSAPITPV(objCashRequest, strTimeStamp.FirstOrDefault());
                    break;
                case "/GetFailedTickets":
                    var objFailedTicketRequest = JsonConvert.DeserializeObject<FailedTicketRequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSAPITPV(objFailedTicketRequest, strTimeStamp.FirstOrDefault());
                    break;
                case "/GetFamilies":
                    var objFamiliesRequest = JsonConvert.DeserializeObject<FamiliesRequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSAPITPV(objFamiliesRequest, strTimeStamp.FirstOrDefault());
                    break;
                case "/TransactionStatus": //No se encuentra el Endpoint en COFOWSAPITPV
                case "/ilionservices4/COFOWSInterface/api/ClosingCash/TransactionStatus/request":
                case "/api/ClosingCash/TransactionStatus/request":
                    var objTransactionStatusRequest = JsonConvert.DeserializeObject<TransactionStatusRequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSREST(objTransactionStatusRequest, strTimeStamp.FirstOrDefault());
                    break;
                case "/api/DeliveryNotes/COFOSetDeliveryNotesHandHeld/request":
                    var objErpDeliveryNotesHHLegacy = JsonConvert.DeserializeObject<ErpDeliveryNotesHHLegacy>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSREST(objErpDeliveryNotesHHLegacy, strTimeStamp.FirstOrDefault());
                    break;
                case "/SupplierOrders/COFOSetSupplierOrdersConts/request":
                    var objSupplierOrders = JsonConvert.DeserializeObject<SupplierOrders>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignatureWSREST(objSupplierOrders, strTimeStamp.FirstOrDefault());
                    break;
                default:
                    return BadRequest($"Endpoint '{strEndpoint}' no es válido");
            }

            return Ok(sGenerateSignatureInput);
        }
    }
}