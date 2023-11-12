using System.Text.Json.Serialization;

namespace Jmepromeneavecmesvalises_API.Models;

public class Voyage
{
    public int Id { get; set; }

    public string Destination { get; set; }
    
    public string Img { get; set; }
    
    [JsonIgnore]
    public virtual List<User> Proprietaires { get; set; }
}