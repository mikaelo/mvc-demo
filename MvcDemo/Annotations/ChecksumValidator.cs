using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo.Annotations
{
    public class ChecksumValidator : DataAnnotationsModelValidator<ChecksumAttribute>
    {
        private ChecksumAttribute _attribute;

        public ChecksumValidator(ModelMetadata metadata, 
            ControllerContext context, 
            ChecksumAttribute attribute) : 
            base(metadata, context, attribute)
        {
            _attribute = attribute;
        }
    }
}