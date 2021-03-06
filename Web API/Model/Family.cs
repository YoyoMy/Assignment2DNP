using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model {
public class Family {
    
[JsonPropertyName("Id")]
    public int Id { get; set; }
    [Required]
    [MinLength(2)]
    [JsonPropertyName("StreetName")]
    public string StreetName { get; set; }
    [Required]
[JsonPropertyName("HouseNumber")]
    public int HouseNumber{ get; set; }
    [JsonPropertyName("Adults")]
    public List<Adult> Adults { get; set; }
    [JsonPropertyName("Children")]
    public List<Child> Children{ get; set; }
    [JsonPropertyName("Pets")]
    public List<Pet> Pets{ get; set; }

    public Family() {
        Adults = new List<Adult>();     
    }
}


}