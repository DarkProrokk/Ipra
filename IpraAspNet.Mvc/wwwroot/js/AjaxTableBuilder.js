//var testAjax = (function($) {
//    'use strict';

//    function sendForm(inputElem) {
//        var form = $(inputElem).parents('form');
//        var formData = form.serialize();

//        $.ajax({
//            url: '/GetDataApi/GetDataTest',
//            type: 'post',
//            data: formData,
//            success: function(responce) {
//                console.log(responce);
//            },
//            error: function (jqXHR, exception) {
//                console.log(exception);
//            }
//        });
//    }
//    return {
//        sendForm: function (inputElem) {
//            sendForm(inputElem);
//        },

//        filterByHasChanged: function (filterElem) {
//            var filterByValue = $(filterElem).find(":selected").val();
//            if (filterByValue === "0") {
//                sendForm(filterElem);
//            }
//        },
//    };

//}(window.jQuery));

var AjaxTableBuilder = (function ($) {
    'use strict';

    function sendForm(inputElem) {
        var form = $(inputElem).parents('form');
        var formData = form.serialize();

        $.ajax({
            url: '/GetDataApi/GetDataTest',
            type: 'post',
            data: formData,
            success: function (response) {
                // Очистим таблицу перед заполнением новыми данными
                document.getElementById('dataTable').innerHTML = '';
 
                // Получаем данные из ответа
                var data = response.ipraList;

                // Создание таблицы
                const table = document.getElementById('dataTable');
                const thead = table.createTHead();
                const tbody = table.createTBody();
                var headers = response.headersList;
                // Создание заголовков таблицы
                const headerRow = thead.insertRow();
                headers.forEach(headerText => {
                    const th = document.createElement('th');
                    const text = document.createTextNode(headerText.charAt(0).toUpperCase() + headerText.slice(1));
                    th.appendChild(text);
                    headerRow.appendChild(th);
                });

                // Заполнение таблицы данными
                data.forEach(item => {
                    const row = tbody.insertRow();
                    Object.values(item).forEach(value => {
                        const cell = row.insertCell();
                        const text = document.createTextNode(value);
                        cell.appendChild(text);
                    });
                });

                // Добавление таблицы на страницу
                table.setAttribute('id', 'dataTable');
                document.body.appendChild(table);
            },
            error: function (jqXHR, exception) {
                console.log(exception);
            }
        });
    }

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