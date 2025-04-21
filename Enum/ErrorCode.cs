namespace BigPurpleBank.Enum
{
    public enum ErrorCode
    {
        // 400 Bad Request
        InvalidField,
        MissingRequiredField,
        InvalidVersion,
        InvalidPageSize,

        // 406 Not Acceptable
        UnsupportedVersion,

        // 422 Unprocessable Entity
        InvalidPage
    }
}
