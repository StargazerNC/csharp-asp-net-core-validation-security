using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConferenceTracker.Entities
{
    public class Speaker : IValidatableObject 
    {
        [Required]                                                          public int    Id           { get; set; }
        [StringLength(maximumLength:100, MinimumLength = 2)][DataType(DataType.Text)] [Required] [Display(Name = "First name")] public string FirstName    { get; set; }
        [StringLength(maximumLength:100, MinimumLength = 2)][DataType(DataType.Text)] [Required] [Display(Name = "Last name")]  public string LastName     { get; set; }
        [StringLength(maximumLength:500, MinimumLength = 10)][DataType(DataType.MultilineText)] [Required]                       public string Description  { get; set; }
        [DataType(DataType.EmailAddress)] [Display(Name = "Email Address")] public string EmailAddress { get; set; }
        [DataType(DataType.PhoneNumber)] [Display(Name = "Phone Number")]   public string PhoneNumber  { get; set; }
        public                                                                     bool   IsStaff      { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var valList = new List<ValidationResult>();

            if (!string.IsNullOrWhiteSpace(EmailAddress) &&
                EmailAddress.EndsWith("TechnologyLiveConference.com", StringComparison.InvariantCultureIgnoreCase))
            {
                valList.Add(new ValidationResult("Technology Live Conference staff should not use their conference email addresses."));
            }
            return valList;
        }
    }
}
