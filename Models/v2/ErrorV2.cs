namespace BigPurpleBank.Models.v2
{
    public class ErrorV2
    {
        /// <summary>
        /// The error code. If application-specific, meta.urn must be included.
        /// </summary>
        public string Code { get; set; } = default!;

        /// <summary>
        /// A short, human-readable summary of the problem.
        /// </summary>
        public string Title { get; set; } = default!;

        /// <summary>
        /// A human-readable explanation specific to this occurrence.
        /// </summary>
        public string Detail { get; set; } = default!;

        /// <summary>
        /// Additional data for customised error codes.
        /// </summary>
        public Meta? Meta { get; set; }

        public ErrorV2() { }
    }
}
