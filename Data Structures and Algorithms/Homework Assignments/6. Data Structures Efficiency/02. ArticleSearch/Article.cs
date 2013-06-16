using System;

public class Article : IComparable<Article>
{
    public Article(double price, string barcode, string vendor, string title)
    {
        this.Price = price;
        this.Barcode = barcode;
        this.Vendor = vendor;
        this.Title = title;
    }

    public double Price { get; private set; }

    public string Barcode { get; private set; }

    public string Vendor { get; private set; }

    public string Title { get; private set; }

    public int CompareTo(Article other)
    {
        return this.Price.CompareTo(other.Price);
    }

    public override string ToString()
    {
        return string.Format(
            "Price: {0,10:F2}, Barcode: {1}, Vendor: {2}, Title: {3}",
            this.Price,
            this.Barcode,
            this.Vendor,
            this.Title);
    }
}
