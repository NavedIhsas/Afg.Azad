namespace ShopManagement.Domain.Visitors;

public class Device
{
    public long Id { get; set; }
    public string Brand { get; set; }
    public string Family { get; set; }
    public string Model { get; set; }
    public bool IsSpider { get; set; }
}