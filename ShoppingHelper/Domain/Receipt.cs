namespace ShoppingHelper.Domain;

public class Receipt
{
    public IEnumerable<ReceiptInfo?>? ReceiptInfos { get; }

    public Receipt(IEnumerable<ReceiptInfo?>? receiptInfos)
    {
        ReceiptInfos = receiptInfos;
    }
}

public class ReceiptInfo
{
    public string? Locale { get; }
    public string? Description { get; }
    public BoundingPoly? BoundingPoly { get; }

    public ReceiptInfo(string? locale, string? description, BoundingPoly? boundingPoly)
    {
        Locale = locale;
        Description = description;
        BoundingPoly = boundingPoly;
    }
}

public class BoundingPoly
{
    public IEnumerable<Vertices?>? Vertices { get; }

    public BoundingPoly(IEnumerable<Vertices?>? vertices)
    {
        Vertices = vertices;
    }
}

public class Vertices
{
    public int? X { get; }
    public int? Y { get; }

    public Vertices(int? x, int? y)
    {
        X = x;
        Y = y;
    }
}