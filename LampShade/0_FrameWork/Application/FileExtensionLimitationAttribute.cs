using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace _0_FrameWork.Application
{
    public class FileExtensionLimitationAttribute:ValidationAttribute,IClientModelValidator
    {
        private readonly string[] _extension;

        public FileExtensionLimitationAttribute(string[] extension)
        {
            _extension = extension;
        }
        public override bool IsValid(object value)
        {
            if (value == null) return true;
            var file = value as IFormFile;
            var fileExtension = Path.GetExtension(file.FileName);
            return _extension.Contains(fileExtension);
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            
            context.Attributes.Add("data-val-fileExtensionLimitation", ErrorMessage);
        }
    }
}
