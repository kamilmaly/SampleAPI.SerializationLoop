using System.Text.Json.Serialization;

namespace SampleAPI.Entities;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CountryId { get; set; }
    [JsonIgnore]
    public virtual Country Country { get; set; }
}