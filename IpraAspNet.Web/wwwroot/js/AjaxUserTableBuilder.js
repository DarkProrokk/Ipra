var AjaxTableBuilder = (function ($) {
    'use strict';

    function inputBuilder(name) {
        var input = document.createElement('input');
        input.setAttribute("class", "form-control");
        input.setAttribute("id", name);
        input.setAttribute("name", "FilterBy_" + name);
        input.setAttribute("onchange", "AjaxTableBuilder.sendForm(this)")
        var hiddenInput = document.createElement('input');
        return input;
    }

    function BuildTable(response) {
        document.getElementById('dataTable').innerHTML = ''
        let PageNum = document.getElementById('num-pages-text');
        response = response.value;
        PageNum.textContent = "из " + response.options.numPages;
        // Получаем данные из ответа
        let data = response.data;
        // Создание таблицы
        const table = document.getElementById('dataTable');
        const thead = table.createTHead();
        const tbody = table.createTBody();
        let headers = Object.keys(response.headersList);
        // Создание заголовков таблицы
        const headerRow = thead.insertRow();
        headers.forEach(headerText => {
            let attrname = response.headersList[headerText]
            const th = document.createElement('th');
            const text = document.createTextNode(headerText.charAt(0).toUpperCase() + headerText.slice(1));
            th.setAttribute("name", attrname);
            let input = inputBuilder(attrname);
            th.appendChild(text);
            th.appendChild(input);
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
    }

    function sendForm(inputElem) {
        var form = $(inputElem).parents('form');
        var formData = form.serializeArray();
        var jsonData = {}
        formData.forEach(function (item) {
            if (item.name.startsWith("FilterBy_")) {
                if (item.value !== "") {
                    jsonData["FilterBy"] = item.name.replace("FilterBy_", '');
                    jsonData["FilterValue"] = item.value;
                }
            }
            else {
                var value = parseInt(item.value)
                if (isNaN(value)) {
                    jsonData[item.name] = item.value;
                }
                else {
                    jsonData[item.name] = value;
                }
            }

        });
        $.ajax({
            url: '/api/GetDataApi/GetUsersList',
            type: 'post',
            dataType: 'json',
            contentType: "application/json",
            data: JSON.stringify(jsonData),
            success: function (response) {
                BuildTable(response);

            },
            error: function (jqXHR, exception) {
                console.log(exception);
            }
        });
    }
    $(document).ready(function () {
        sendForm();
    });
    return {
        sendForm: function (inputElem) {
            sendForm(inputElem);
        },

    };
}(window.jQuery));