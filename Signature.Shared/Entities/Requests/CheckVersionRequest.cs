namespace Signature.Shared.Entities.Requests
{
    /// <summary>
    /// The CheckVersionRequest
    /// </summary>
    public class CheckVersionRequest
    {
        /// <summary>
        /// The ncompany
        /// </summary>
        public string NCompany { get; set; }
        /// <summary>
        /// The store
        /// </summary>
        public string Store { get; set; }
        /// <summary>
        /// The User
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// The PDA number
        /// </summary>
        public string NPDA { get; set; }
        /// <summary>
        /// The InstalledVersion
        /// </summary>
        public string InstalledVersion { get; set; }
        /// <summary>
        /// The LocalDateTime
        /// </summary>
        public string LocalDateTime { get; set; }
        /// <summary>
        /// The UTCDateTime
        /// </summary>
        public string UTCDateTime { get; set; }
    }
}