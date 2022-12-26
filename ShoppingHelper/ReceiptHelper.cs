using ShoppingHelper.Domain;
using ShoppingHelper.Dto;
using System.Text.Json;

namespace ShoppingHelper;

public static class ReceiptHelper
{
    public static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    private static string? GetRootDescriptionFromReceipt(Receipt? receipt) =>
        receipt?.ReceiptInfos?.FirstOrDefault()?.Description;

    private static string? GetRootDescriptionFromReceiptDto(ReceiptDto? receiptDto) =>
        GetRootDescriptionFromReceipt(receiptDto?.ToReceipt());

    private static string? GetRootDescriptionFromReceiptJson(string? receiptJson) =>
        GetRootDescriptionFromReceiptDto(string.IsNullOrWhiteSpace(receiptJson)
            ? null
            : new ReceiptDto
                { ReceiptInfoDtos = JsonSerializer.Deserialize<IEnumerable<ReceiptInfoDto>?>(receiptJson, JsonSerializerOptions) });

    private static async void WriteReceiptTextToTxtFile(string filePath, string? receiptText) =>
        await File.WriteAllTextAsync(filePath, receiptText);

    public static void ReadJsonAndWriteReceiptTextToTxtFile(string? receiptJson, string filePath)
    {
        var receiptText = GetRootDescriptionFromReceiptJson(receiptJson);
        WriteReceiptTextToTxtFile(filePath, receiptText);
    }
}