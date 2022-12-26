using System.Text;

namespace ShoppingHelper;

public static class CampaignCodeHelper
{
    private const int OutputSize = 8;
    private const int ValidatorSize = 2;
    //It's the same set of letters, but I shuffled order of letters to make the algorithm a little harder to solve.
    private const string AllowedOutputChars = "M9NPA7CDH2KL3XYZEF5GR4T";//"ACDEFGHKLMNPRTXYZ234579";

    private static string GetRandomString(int size)
    {
        var stringBuilder = new StringBuilder(size);
        var random = new Random();

        for (var i = 0; i < size; i++)
        {
            var index = random.Next() % AllowedOutputChars.Length;
            stringBuilder.Append(AllowedOutputChars[index]);
        }

        return stringBuilder.ToString();
    }

    private static string GetValidatorString(string code, int size)
    {
        var sumOfAsciiValues = code.Sum(ch => ch);
        var stringBuilder = new StringBuilder(size);

        for (var i = 0; i < size; i++)
        {
            var index = (sumOfAsciiValues * i) % AllowedOutputChars.Length;
            stringBuilder.Append(AllowedOutputChars[index]);
        }

        return stringBuilder.ToString();
    }

    public static string GenerateCampaignCode()
    {
        var uniqueCode = GetRandomString(OutputSize - ValidatorSize);
        var validatorCode = GetValidatorString(uniqueCode, ValidatorSize);

        return string.Concat(uniqueCode, validatorCode);
    }

    public static bool ValidateCampaignCode(string campaignCode)
    {
        if (campaignCode.Length != OutputSize)
            return false;

        var targetUniqueCode = campaignCode[..(OutputSize - ValidatorSize)];
        var targetValidatorCode = campaignCode.Substring(OutputSize - ValidatorSize, ValidatorSize);

        var expectedValidatorCode = GetValidatorString(targetUniqueCode, ValidatorSize);

        return string.Equals(targetValidatorCode, expectedValidatorCode);
    }
}