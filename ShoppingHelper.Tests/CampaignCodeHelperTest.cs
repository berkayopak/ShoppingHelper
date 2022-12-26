using Xunit.Abstractions;

namespace ShoppingHelper.Tests;

public class CampaignCodeHelperTest
{
    private readonly ITestOutputHelper _output;
    private readonly string[] _invalidCodes = { "RFGAS1F3", "RFGDS1F6", "EXAG2CA4", "2P44ZGAF", "XT35X3AC", "ASBFQ3T5", "ASBD 3T5", "1234567", "00000000", "2XCRYRM" };
    private readonly string[] _validCodes = { "XRCXDZMM", "2XCRYRM4", "T4LAF3MD" };
    //If you want to fail tests, you can use this array.
    private readonly string[] _mixedCodes = { "EXAG2CA4", "RFGDS1F6", "XT35X3AC" };

    public CampaignCodeHelperTest(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void GenerateCampaignCodeTest()
    {
        var campaignCode = CampaignCodeHelper.GenerateCampaignCode();
        _output.WriteLine($"Generated campaign code => {campaignCode}");
        Assert.True(CampaignCodeHelper.ValidateCampaignCode(campaignCode));
    }

    [Fact]
    public void ValidCampaignCodeTest()
    {
        var anyInvalid = false;
        foreach (var validCode in _validCodes)
        {
            _output.WriteLine($"Campaign code => {validCode}");
            if (CampaignCodeHelper.ValidateCampaignCode(validCode))
                continue;

            anyInvalid = true;
            break;
        }
        Assert.False(anyInvalid);
    }

    [Fact]
    public void InvalidCampaignCodeTest()
    {
        var anyValid = false;
        foreach (var invalidCode in _invalidCodes)
        {
            _output.WriteLine($"Campaign code => {invalidCode}");
            if (!CampaignCodeHelper.ValidateCampaignCode(invalidCode)) 
                continue;

            anyValid = true;
            break;
        }
        Assert.False(anyValid);
    }
}