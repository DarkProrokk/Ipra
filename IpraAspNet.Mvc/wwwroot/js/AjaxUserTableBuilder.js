$(document).ready(function () {
    $.ajax({
        url: '/Admin/GetUserList',
        type: 'POST',
        success: function (data) {
            var columns = [];
            var columnsMapping = data.columnsMapping;

            // Создание заголовков таблицы на основе переданного словаря
            for (var key in columnsMapping) {
                columns.push({
                    title: columnsMapping[key],
                    data: key
                });
            }

            // Инициализация DataTable с заданными столбцами
            $('#userTable').DataTable({
                data: data.data.usersList,
                columns: columns
            });
        }
    });
});