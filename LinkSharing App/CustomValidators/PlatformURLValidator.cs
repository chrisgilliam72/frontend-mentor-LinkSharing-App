using LinkSharing_App.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
namespace LinkSharing_App.CustomValidators;

public class PlatformURLValidator : ValidationAttribute
{


    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var instance = (CustomLinkViewModel)validationContext.ObjectInstance;
        string stringValue = value?.ToString();
        if (!string.IsNullOrEmpty(stringValue) && !string.IsNullOrEmpty(instance.PlatformURL) &&
            stringValue.ToLower().Contains(instance.PlatformURL.ToLower()))
        {
            return null;
        }
        return new ValidationResult($"URL must contain{instance.PlatformURL}");
    }
}
