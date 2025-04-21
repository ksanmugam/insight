﻿using System.Text.Json.Serialization;

namespace BigPurpleBank.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum BankingProductCategory
    {
        BUSINESS_LOANS,
        CRED_AND_CHRG_CARDS,
        LEASES,MARGIN_LOANS,
        OVERDRAFTS,
        PERS_LOANS,
        REGULATED_TRUST_ACCOUNTS,
        RESIDENTIAL_MORTGAGES,
        TERM_DEPOSITS,
        TRADE_FINANCE,
        TRANS_AND_SAVINGS_ACCOUNTS,
        TRAVEL_CARDS,
    }
}
