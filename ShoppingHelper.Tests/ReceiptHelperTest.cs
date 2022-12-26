namespace ShoppingHelper.Tests;

public class ReceiptHelperTest
{
    private const string ReceiptJsonFileName = "response.json";
    private readonly string _currentDirectory = Environment.CurrentDirectory;

    [Fact]
    public async void ReadJsonAndWriteReceiptTxtToFileTest()
    {
        var receiptJson = await File.ReadAllTextAsync($"{_currentDirectory}/{ReceiptJsonFileName}");
        ReceiptHelper.ReadJsonAndWriteReceiptTextToTxtFile(receiptJson, $"{_currentDirectory}/testReceiptFile.txt");
        Assert.True(true);
    }

}