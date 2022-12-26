using ShoppingHelper.Domain;

namespace ShoppingHelper.Dto;

public class ReceiptDto
{
    public IEnumerable<ReceiptInfoDto?>? ReceiptInfoDtos { get; set; }

    public Receipt ToReceipt() => new(ReceiptInfoDtos?.Select(r => r?.ToReceiptInfo()));
}

public class ReceiptInfoDto
{
    public string? Locale { get; set; }
    public string? Description { get; set; }
    public BoundingPolyDto? BoundingPoly { get; set; }

    public ReceiptInfo ToReceiptInfo() => new(Locale, Description, BoundingPoly?.ToBoundingPoly());
}

public class BoundingPolyDto
{
    public IEnumerable<VerticesDto?>? Vertices { get; set; }

    public BoundingPoly ToBoundingPoly() => new(Vertices?.Select(v => v?.ToVertices()));
}

public class VerticesDto
{
    public int? X { get; set; }
    public int? Y { get; set; }

    public Vertices ToVertices() => new(X, Y);
}