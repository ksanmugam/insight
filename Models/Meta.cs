namespace BigPurpleBank.Models
{
    public class Meta
    {
        /// <summary>
        /// The CDR error code URN that the app-specific error extends.
        /// Required only if Code is application-specific.
        /// </summary>
        public string? Urn { get; set; }
    }
}
