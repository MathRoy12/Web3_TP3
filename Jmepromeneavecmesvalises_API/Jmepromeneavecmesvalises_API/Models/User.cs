using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Jmepromeneavecmesvalises_API.Models;

public class User : IdentityUser
{
    public virtual List<Voyage>? Voyages { get; set; }
}