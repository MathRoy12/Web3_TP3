namespace Jmepromeneavecmesvalises_API.Models;

public class VoyageDTO
{
    public int Id { get; set; }

    public string Destination { get; set; }
    
    public string Img { get; set; }
    
    public List<string> UserIDs { get; set; }
    
    public VoyageDTO(){}
    public VoyageDTO(Voyage pVoyage)
    {
        Id = pVoyage.Id;
        Destination = pVoyage.Destination;
        Img = pVoyage.Img;
        UserIDs = new List<string>();

        foreach (User item in pVoyage.Proprietaires)
        {
            UserIDs.Add(item.Id);
        }
    }
}