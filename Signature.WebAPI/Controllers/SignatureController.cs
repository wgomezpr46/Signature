using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Signature.WebAPI.Entities.Requests;
using Signature.WebAPI.Helpers;

namespace Signature.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SignatureController : ControllerBase
    {
        // GET: api/Signature/Welcome
        [HttpGet]
        public string Welcome()
        {
            return "Weilcome Generated Signature!!";
        }

        // POST: api/Signature/GeneratedSignature
        [HttpPost]
        public string GeneratedSignature(Object request)
        {
            Request.Headers.TryGetValue("TimeStamp", out var strTimeStamp);
            Request.Headers.TryGetValue("Endpoint", out var strEndpoint);

            var options = new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase
            };

            var jsonString = System.Text.Json.JsonSerializer.Serialize(request, options);
            string sGenerateSignatureInput = string.Empty;

            switch (strEndpoint.ToString())
            {
                case "/GetArticle":
                case "/GetArticleType":
                    var objArticleRequest = JsonConvert.DeserializeObject<ArticleRequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignature(objArticleRequest, strTimeStamp);
                    break;
                case "/GetPromotions":
                    var objTicketPromotionsRequest = JsonConvert.DeserializeObject<TicketPromotionsRequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignature(objTicketPromotionsRequest, strTimeStamp);
                    break;
                case "/GetPromotionsNew":
                    var objTicketPromotionsRequestNew = JsonConvert.DeserializeObject<TicketPromotionsRequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignature(objTicketPromotionsRequestNew, strTimeStamp);
                    break;
                case "/SetTicket":
                case "/SetRefundTicket":
                    var objPOSDocumentsCOFORequest = JsonConvert.DeserializeObject<POSDocumentsCOFORequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignature(objPOSDocumentsCOFORequest, strTimeStamp);
                    break;
                case "/GetDeliveryNotes":
                    var objDeliveryNotesRequest = JsonConvert.DeserializeObject<DeliveryNotesRequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignature(objDeliveryNotesRequest, strTimeStamp);
                    break;
                case "/GetDeliveryNotesV2":
                    var objDeliveryNotesRequestV2 = JsonConvert.DeserializeObject<DeliveryNotesRequestV2>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignature(objDeliveryNotesRequestV2, strTimeStamp);
                    break;
                case "/ListArticlesPaged":
                    var objArticlesRequest = JsonConvert.DeserializeObject<ArticlesRequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignature(objArticlesRequest, strTimeStamp);
                    break;
                case "/ListArticlesPagedFamilies":
                    var objArticlesRequest_ = JsonConvert.DeserializeObject<ArticlesRequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignature(objArticlesRequest_, strTimeStamp);
                    break;
                case "/GetSettingsLosses":
                    var objSettingsLossesRequest = JsonConvert.DeserializeObject<SettingsLossesRequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignature(objSettingsLossesRequest, strTimeStamp);
                    break;
                case "/SetAdjustmentsLosses":
                    var objSetAdjustmentsLossesRequest = JsonConvert.DeserializeObject<SetAdjustmentsLossesRequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignature(objSetAdjustmentsLossesRequest, strTimeStamp);
                    break;
                case "/SetClosingCash":
                case "/SetClosingCashTransaction": //No se encuentra el Endpoint en COFOWSAPITPV
                    var objCashRequest = JsonConvert.DeserializeObject<CashRequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignature(objCashRequest, strTimeStamp);
                    break;
                case "/GetFailedTickets":
                    var objFailedTicketRequest = JsonConvert.DeserializeObject<FailedTicketRequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignature(objFailedTicketRequest, strTimeStamp);
                    break;
                case "/GetFamilies":
                    var objFamiliesRequest = JsonConvert.DeserializeObject<FamiliesRequest>(jsonString);
                    sGenerateSignatureInput = GenericHelper.GeneratedSignature(objFamiliesRequest, strTimeStamp);
                    break;
                case "/TransactionStatus": //No se encuentra el Endpoint en COFOWSAPITPV
                    break;
                default:
                    break;
            }

            return sGenerateSignatureInput;
        }
    }
}