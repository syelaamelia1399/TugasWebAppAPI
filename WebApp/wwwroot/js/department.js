$(document).ready(function () {
    $('#tableDepartment').DataTable({
        ajax: {
            url: 'https://localhost:7265/api/Department',
            dataType: 'json',
            dataSrc: 'data'
        },
        columns: [
            { data: 'id' },
            { data: 'name' },
            { data: 'divisionId' },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return `<a asp-action="Edit" onclick="EditData('${data.id}')" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#editModal">Edit</a>
                        <a asp-action="Details" onclick="GetDept('${data.id}')" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#getIdModal">Details</a> 
                        <a asp-action="Delete" onclick="DeleteById('${ data.id}','${data.name}')" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#deleteModal">Delete</a>`
                }
            },
        ],
        dom: 'Bfrtip',
        buttons: ['colvis', 'pdf', 'excel']
    });
});


function GetDept(id) {
    $.ajax({
        url: `https://localhost:7265/api/Department/${id}`,
        method: 'GET',
        dataType: 'json',
    }).done((res) => {
        let temp = "";
        temp += `
                <div>
                    <label class="form-group-float-table is-visible">Id</label>
                    <input type="text" class="form-control" placeholder="${res.id}" value="${res.id}" data-toggle="tooltip" data-placement="bottom" readonly/>
                </div>
                <div>
                    <label class="form-group-float-table is-visible">Department Name</label>
                    <input type="text" class="form-control" placeholder="${res.name}" value="${res.name}" data-toggle="tooltip" data-placement="bottom" readonly/>
                </div>
                <div>
                    <label class="form-group-float-table is-visible">Division ID</label>
                    <input type="number" class="form-control" placeholder="${res.divisionId}" value="${res.divisionId}" data-toggle="tooltip" data-placement="bottom" readonly/>
                </div>
        `;
        $("#getdetail").html(temp);
    });
}
    /*
     *                 <button type="button" class="btn btn-primary" onclick="editDept()">Edit</button>
        $(#getdetail).html(
            `<tr>
                <td>Type </td>
                <td> : ${res.id}</td>
            </tr>
            <tr>
                <td>Weight </td>
                <td> : ${res.name} kg</td>
            </tr>
            <tr>
                <td>Height </td>
                <td> : 0.${res.divisionId} m</td>
            </tr>`
        );
    });
}


function detailDept(id) {
    $.ajax({
        url: `https://localhost:44393/api/Department/${id}`,
        type: "GET",
        dataType: 'json'
    }).done((res) => {
        let tempDetail =
            `<form>
                <div>
                    <label for="id">ID:</label><br>
                    <input type="text" class="form-control" id="deptId" value="${res.data.id}" readonly></input><br>
                </div>
                <div>
                    <label for="name">Department Name:</label><br>
                    <input type="text" class="form-control" id="deptName" value="${res.data.name} placeholder="Enter Department Name" required"></input><br>
                </div>
                <div>
                    <label for="name">Division ID:</label><br>
                    <input type="text" class="form-control" id="divId" value="${res.data.divisionId} placeholder="Enter Division ID" required"></input><br><br>
                </div>
                <button type="button" class="btn btn-primary" onclick="editDept()">Edit</button>
            </form>`;
        $("#detailBody").html(tempDetail);
    });
}

function AddNew() {
    let buttonSaveAdd = "";
    buttonSaveAdd = `<button class="btn btn-danger" type="submit" onclick="SaveNew()">Add</button>`
    $("#btn-addnew-department").html(buttonSaveAdd)
}
*/

function SaveNew() {
    var url = 'https://localhost:7265/api/Department/';
    var objectItem = {};
    objectItem.Name = $('#input-name-department').val();
    objectItem.DivisionId = $('#input-divisionid-department').val();
    if (objectItem) {
        $.ajax({
            url: url,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            data: JSON.stringify(objectItem),
            type: 'POST',
            success: function () {
                Swal.fire(
                    'Success!',
                    'Data Has Been Added!',
                    'success'
                ).then(function () {
                    location.reload();
                });
            },
            error: function () {
                Swal.fire({
                    icon: 'error',
                    title: 'Failed!',
                    text: 'Something went wrong!'
                });
            }
        });
    }
}

function EditData(id) {
    $.ajax({
        url: `https://localhost:7265/api/Department/${id}`,
        method: 'GET',
        dataType: 'json',
    }).done((res) => {
        let temp = "";
        temp += `
                <div>
                    <label class="form-group-float-table is-visible">Id</label>
                    <input type="text" id="id-department" class="form-control" value="${res.id}" data-toggle="tooltip" data-placement="bottom" readonly/>
                </div>
                <div>
                    <label class="form-group-float-table is-visible">Department Name</label>
                    <input type="text" id="edit-name-department" class="form-control" placeholder="${res.name}" value="${res.name}" data-toggle="tooltip" data-placement="bottom" required/>
                </div>
                <div>
                    <label class="form-group-float-table is-visible">Division ID</label>
                    <input type="number" id="edit-divisionid-department" class="form-control" placeholder="${res.divisionId}" value="${res.divisionId}" data-toggle="tooltip" data-placement="bottom" required/>
                </div>
        `;
        $("#editBody").html(temp);
    });
}

function Edit() {
    var url = 'https://localhost:7265/api/Department/';
    var editItem = {};
    editItem.Id = $('#id-department').val();
    editItem.Name = $('#edit-name-department').val();
    editItem.DivisionId = $('#edit-divisionid-department').val();
    if (editItem) {
        $.ajax({
            url: url,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            method: 'PUT',
            data: JSON.stringify(editItem),
            success: function () {
                Swal.fire(
                    'Success!',
                    'Data Has Been Changed!',
                    'success'
                ).then(function () {
                    location.reload();
                });
            },
            error: function () {
                Swal.fire({
                    icon: 'error',
                    title: 'Failed!',
                    text: 'Something went wrong!'
                });
            }
        });
    }
}
/*
function confirmAdd() {
    let dataName = $('#input-name-department').val();
    let dataDivisionId = $('#input-divisionid-department').val();
    $.ajax({
        url: 'https://localhost:7153/api/Department/',
        method: 'POST',
        dataType: 'json',
        data: {
            name: "data",
            divisionId: 1
        },
        cache: false,
        success: function (data) {
            console.log(data);
            alert("Add Data Successfull");
        },
        error: function (data) {
            console.log(data);
            alert("Gagal");
        }
    })
}

function Edit() {
    let buttonSaveEdit = "";
    buttonSaveEdit = `<button class="btn btn-danger" onclick="confirmEdit('${id}')">Save</button>`
    $("#btn-edit-department").html(buttonSaveEdit)
}
function confirmEdit(id) {
    $.ajax({
        url: `https://localhost:7153/api/Department/${id}`,
        method: 'PUT',
        dataType: 'json',
        success: function (message) {
            alert("Edit Data Successfull" + message);
            location.reload();
        }
    })
}
*/

function DeleteById(id, name) {
    let buttonDelete = "";
    buttonDelete = `<button class="btn btn-danger" onclick="confirmDelete('${id}')">Delete</button>`
    let nameDelete = "";
    nameDelete = `<p>Are you sure want to delete ${name} ? </p>`
    $("#btn-delete-department").html(buttonDelete)
    console.log(buttonDelete);
    $("#nm-delete-department").html(nameDelete)
}

function confirmDelete(id) {
    $.ajax({
        url: `https://localhost:7265/api/Department/${id}`,
        method: 'DELETE',
        dataType: 'json',
        success: function () {
            Swal.fire(
                'Success!',
                'Data Has Been Deleted!',
                'success'
            ).then (function() {
                location.reload();
            });
        },
        error: function () {
            Swal.fire({
                icon: 'error',
                title: 'Failed!',
                text: 'Something went wrong!'
            });
        }
    })
}
