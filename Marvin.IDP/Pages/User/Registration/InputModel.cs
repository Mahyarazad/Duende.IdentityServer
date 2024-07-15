using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace IdentityServer.Pages.User.Registration
{
    public class InputModel
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Given Name")]
        public string? GivenName { get; set; }
        [Required]
        [MaxLength(200)]
        [Display(Name = "Family Name")]
        public string? FamilyName { get; set; }
        public string? Email { get; set; }
        [Required]
        [MaxLength(2)]
        public string Country { get; set; }

        public string? ReturnUrl { get; set; }

        public string? Button { get; set; }

        public IEnumerable<SelectListItem> CountryList = CultureInfo.GetCultures(CultureTypes.AllCultures)
                        .Where(c => !c.IsNeutralCulture && c.LCID != 0x7f).Select(x => new SelectListItem()
                        {
                            Text = new RegionInfo(x.Name).DisplayName,
                            Value = new RegionInfo(x.Name).Name
                        }).ToList();
    }
}
