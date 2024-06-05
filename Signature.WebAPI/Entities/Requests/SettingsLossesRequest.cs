namespace Signature.WebAPI.Entities.Requests
{
    public class SettingsLossesRequest
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Station { get; set; }
        public string DateFrom { get; set; }
        public string DateUp { get; set; }
        public List<string> Reason { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}