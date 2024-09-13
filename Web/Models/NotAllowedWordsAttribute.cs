using System.ComponentModel.DataAnnotations;

namespace Medi_Connect.Models
{
    public class NotAllowedWordsAttribute : ValidationAttribute
    {
        private readonly string[] _notAllowedWords;

        public NotAllowedWordsAttribute(string[] notAllowedWords)
        {
            _notAllowedWords = notAllowedWords;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string stringValue)
            {
                foreach (var word in _notAllowedWords)
                {
                    if (stringValue.Contains(word))
                    {
                        return new ValidationResult($"The field contains a not allowed word: {word}");
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}