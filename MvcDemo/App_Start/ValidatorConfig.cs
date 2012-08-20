using System.Web.Mvc;
using MvcDemo.Annotations;

namespace MvcDemo
{
    public static class ValidatorConfig
    {
        public static void RegisterValidators()
        {
            /*
            DataAnnotationsModelValidatorProvider.RegisterAdapter(
                typeof(ChecksumAttribute), typeof(ChecksumValidator));
            */
        }
    }
}