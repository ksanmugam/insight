using System.Text.Json.Serialization;

namespace BigPurpleBank.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AccountOwnership
    {
        UNKNOWN,
        ONE_PARTY,
        TWO_PARTY,
        MANY_PARTY,
        OTHER
    }
}
