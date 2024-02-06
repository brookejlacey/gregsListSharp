namespace gregsListSharp.Models;

public class House
{
    public int Id { get; set; }
    public string Neighborhood { get; set; }
    public string Color { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
    public int Price { get; set; }
    public int? YearBuilt { get; set; }
}