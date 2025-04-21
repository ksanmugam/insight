namespace BigPurpleBank.Helpers
{
    public class BankingHelper
    {
        public static string MaskAccountNumber(string accountNumber)
        {
            if (string.IsNullOrWhiteSpace(accountNumber))
                throw new ArgumentException("Account number cannot be null or empty.");

            // Only mask digits, leave formatting (e.g., dashes/spaces)
            var digits = new string(accountNumber.Where(char.IsDigit).ToArray());

            if (digits.Length < 4)
                throw new ArgumentException("Account number must have at least 4 digits.");

            int digitIndex = 0;
            var masked = new System.Text.StringBuilder();

            foreach (char ch in accountNumber)
            {
                if (char.IsDigit(ch))
                {
                    if (digitIndex < digits.Length - 4)
                        masked.Append('x');
                    else
                        masked.Append(ch);

                    digitIndex++;
                }
                else
                {
                    masked.Append(ch); // keep dash/space etc
                }
            }

            return masked.ToString();
        }
    }
}
