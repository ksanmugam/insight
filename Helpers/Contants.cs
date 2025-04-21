namespace BigPurpleBank.Helpers
{
    public class Contants
    {
        public const int MaxPageSize = 100;
        public static class ErrorCodes
        {

            #region Error  40x
            public const string InvalidVersion = "urn:au-cds:error:cds-all:Header/InvalidVersion";
            public const string InvalidField = "urn:au-cds:error:cds-all:Field/Invalid";
            public const string MissingRequiredField = "urn:au-cds:error:cds-all:Field/Missing";
            public const string MissingRequiredHeader = "urn:au-cds:error:cds-all:Header/Missing";
            public const string InvalidPageSize = "urn:au-cds:error:cds-all:Field/InvalidPageSize";
            public const string UnsupportedVersion = "urn:au-cds:error:cds-all:Header/UnsupportedVersion";
            public const string InvalidPage = "urn:au-cds:error:cds-all:Field/InvalidPage";
            #endregion


            #region Error 50x
            public const string InternalServerError = "urn:au-cds:error:cds-all:Application/InternalServerError";
            #endregion
        }
    }
}
