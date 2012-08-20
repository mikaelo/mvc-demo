/// <reference path="jquery.validate-vsdoc.js" />
/// <reference path="jquery.validate.unobtrusive.js" />
/// <reference path="jquery-1.7.1.intellisense.js" />

jQuery.validator.addMethod("checksumcheck", function(value, element, param) {
    var checksumValue = param;
    if (value !== "222")
        return false;
    return true;
});

jQuery.validator.unobtrusive.adapters.add("checksumcheck", ["checksumvalue"], function(options) {
    options.rules["checksumcheck"] = options.params.checksumvalue;
    options.messages["checksumcheck"] = options.message;
});

