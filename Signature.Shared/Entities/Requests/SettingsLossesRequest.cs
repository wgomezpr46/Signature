namespace Signature.Shared.Entities.Requests
{
    public class SettingsLossesRequest
    {
        public string Station { get; set; }
        public string DateFrom { get; set; }
        public string DateUp { get; set; }
        public List<string> Reason { get; set; }
    }
}