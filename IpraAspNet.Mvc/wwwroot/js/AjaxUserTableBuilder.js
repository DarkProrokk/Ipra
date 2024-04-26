//$(document).ready(function () {
//    var userTable = $('#userTable').DataTable({
//        "ajax": {
//            "url": "/Admin/GetUserList",
//            "type": "POST",
//            "contentType": "application/json",
//            "data": function (d) {
//                d.FilterByStatus = 1;
//                d.FilterByEndless = 1;
//                return JSON.stringify(d);
//            }
//        },
//        "initComplete": function (settings,data) {
//            var columns2 = [];
//            var list = [];
//            var columnsMapping = data.columnsMapping;

//            for (var key in columnsMapping) {
//                columns2.push({
//                    title: columnsMapping[key],
//                    data: key
//                });
//            }
//            settings.aoColumns = columns2;

//            userTable.clear().rows.add(data.data.usersList).draw();

//            if (userTable.data().any()) {
//                this.api().columns.adjust();
//            }
//        }
//    });
//});

$(document).ready(function () {

    var userTable = $('#userTable').DataTable({
        processing: true,
        serverSide: true,
        ajax: {
            url: '/Admin/GetUserList',
            type: 'POST',
            async: false,
            data: function (d) {
                d.FilterByStatus = 1;
                d.FilterByEndless = 1;
                return JSON.stringify(d);
            }
        },
        columns: Object.keys(columnsMapping).map(function (key) {
            return { data: key, title: columnsMapping[key] };
        })
    });

});