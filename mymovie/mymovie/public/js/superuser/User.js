var UserObj = null;

window.onload = function () {
    UserObj = new User();
    UserObj.loadgrid();

}
class User {
    constructor() {

    }
    loadgrid() {
        $(".jsGrid").jsGrid({

            width: "100%",
            height: "400px",
            inserting: false,
            editing: true,
            sorting: true,
            paging: true,
            rowClick: function (args) {},
            rowDoubleClick: function (args) {


            },

            noDataContent: "Not found",
            pagerContainer: null,
            pageIndex: 1,
            pageSize: 30,
            pageButtonCount: 15,
            pagerFormat: "Pages: {first} {prev} {pages} {next} {last}    {pageIndex} of {pageCount}",
            pagePrevText: "Prev",
            pageNextText: "Next",
            pageFirstText: "First",
            pageLastText: "Last",
            pageNavigatorNextText: "...",
            pageNavigatorPrevText: "...",
            invalidMessage: "Invalid data entered!",
            loadIndication: true,
            loadIndicationDelay: 500,
            loadMessage: "Please, wait...",
            loadShading: true,
            autosearch: true,
            autoload: true,
            confirmDeleting: false,
            controller: {
                loadData: function (filter) {
                    return $.ajax({
                        type: "GET",
                        url: "/su/user/getusers",
                        data: filter,
                        dataType: "JSON"
                    });
                },

                updateItem: function (item) {
                    return UserObj.editUser(item);
                }
            },
            fields: [{
                    name: "id",
                    width: 10,
                    title: "ID"
                },
                {
                    name: "name",
                    type: "text",
                    width: 100,
                    validate: "required",
                    title: "Name",
                },                
                {
                    name: "email",
                    type: "text",
                    width: 100,
                    validate: "required",
                    title: "Email",
                },
                {
                    name: "activated",
                    type: "select",
                    width: 50,
                    title: "Status",
                    validate: "required",
                    items: [{
                            value: "IN ACTIVE",
                            Id: "0"
                        },
                        {
                            value: "ACTIVE",
                            Id: "1"
                        }
                    ],
                    valueField: "Id",
                    textField: "value",
                    selectedIndex: 0
                },
                {
                    name: "secret_key",
                    type: "text",
                    width: 100,
                    title: "Pasword",  
                },                
                {
                    type: "control",
                    deleteButton: false
                }
            ]
        });

    }
    editUser = function (User) {
        var d = $.Deferred();
        Swal.fire({
            title: 'Are you sure?',
            text: "This user details will edit",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, use it!'
        }).then((result) => {
            if (result.value) {
                $.ajax({
                    type: "Post",
                    url: '/su/user/edit',
                    data: {
                        user: JSON.stringify(User)
                    },
                    headers: {
                        'X-CSRF-TOKEN': $('input[name="_token"]').val()
                    },
                    success: function (response) {
                        if (response == 0) {
                            Swal.fire(
                                'Error!',
                                'Erro in editing Code',
                                'error'
                            );
                        } else {
                            Swal.fire(
                                'success!',
                                'You have edited Code',
                                'success'
                            );
                            $(".jsGrid").jsGrid("loadData");
                            d.resolve();
                        }


                    },
                    error: function (error) {
                        d.reject();
                    }
                });

            }
            d.reject();
        });
        return d.promise();
    }
}
