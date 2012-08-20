/// <reference path="jquery-1.7.1.intellisense.js" />
/// <reference path="jquery-ui-1.8.20.js" />
/// <reference path="jQuery.tmpl.js" />

$(function() {
    $(":input[data-autocomplete]").each(function() {
        $(this).autocomplete({ source: $(this).attr("data-autocomplete") });
    });

    $(":input[data-datepicker]").datepicker();

    $("#searchTemplateForm").submit(function () {
        $.getJSON($(this).attr("action"), $(this).serialize(), function (data) {
            var result = $("#searchTemplate").tmpl(data);
            $("#searchTemplateResults").empty().append(result);
        }
        );
        return false;
    });
    
});