$.validator.setDefaults({
    highlight: function (element, errorClass, validClass) {
        var $element;
        if (element.type === 'radio') {
            $element = this.findByName(element.name);
        } else {
            $element = $(element);
        }
        $element.addClass(errorClass).removeClass(validClass);
        $element.parents("div.control-group").addClass("error");
    },
    unhighlight: function (element, errorClass, validClass) {
        var $element;
        if (element.type === 'radio') {
            $element = this.findByName(element.name);
        } else {
            $element = $(element);
        }
        $element.removeClass(errorClass).addClass(validClass);
        $element.parents("div.control-group").removeClass("error");
    },
    showErrors: function (errorMap, errorList) {

        $.each(this.successList, function (index, value) {
            $(value).tooltip('hide');
            $(value).siblings("div.tooltip").remove();
        });

        $.each(errorList, function (index, value) {
            showTooltipOfError(value);
        });

        this.defaultShowErrors();
    }
});
function showTooltipOfError(event) {
    var $element = $(event.element);
    var errorElement = "[data-valmsg-for='" + $element.attr("name") + "']";
    $(errorElement).hide();
    $element.siblings("div.tooltip").remove();
    $element.tooltip({
        'title': event.message,
        'animation': 'true',
        'placement': 'bottom',
        'html': true,
        'trigger': 'manual'
    });
    $element.tooltip('show');

    $(".tooltip").addClass("error");

};
$(function () {

    $('form').each(function () {
        $(this).find('div.control-group').each(function () {
            if ($(this).find('.field-validation-error').length > 0) {
                $(this).addClass('error');
            }
        });
    });
});