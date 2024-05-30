var IpraList = (function ($) {
    'use strict';

    var filterApiUrl = null;



    function sendForm(inputElem) {
        var form = $(inputElem).parents('form');
        form.submit();
    }

    //public parts
    return {
        sendForm: function (inputElem) {
            sendForm(inputElem);
        },

        filterByHasChanged: function (filterElem) {
            var filterByValue = $(filterElem).find(":selected").val();
            if (filterByValue === "0") {
                sendForm(filterElem);
            }
        },
    };
}(window.jQuery));