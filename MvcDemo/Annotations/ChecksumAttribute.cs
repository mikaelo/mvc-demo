using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace MvcDemo.Annotations
{
    public class ChecksumAttribute : ValidationAttribute, IClientValidatable
    {
        private readonly int _checksumValue;

        public int ChecksumValue
        {
            get { return _checksumValue; }
        }

        public ChecksumAttribute(int checksumValue) : base("{0} must have checksum {1}")
        {
            _checksumValue = checksumValue;
        }

        public override bool IsValid(object value)
        {
            var valueAsString = value as string;

            if (string.IsNullOrEmpty(valueAsString))
                return true;

            var numbers = valueAsString.Select(t => (int) t).ToList();

            var sum = numbers.Sum();
            return sum % _checksumValue == 0;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, _checksumValue);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(metadata.DisplayName);
            rule.ValidationType = "checksumcheck";
            rule.ValidationParameters.Add("checksumvalue", _checksumValue.ToString());

            yield return rule;
        }
    }
}