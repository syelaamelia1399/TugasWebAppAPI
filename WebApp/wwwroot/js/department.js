$(document).ready(function () {
    $('#tableDepartment').DataTable({
        ajax: {
            url: 'https://localhost:7153/api/Department',
            dataType: 'json',
            dataSrc: ''
        },
        columns: [
            { data: 'id' },
            { data: 'name' },
            { data: 'divisionId' },
            {
                data: null,
                render: function (data, type, row, meta) {
                    return `<a asp-action="Edit" onclick="Edit()" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#editModal">Edit</a> 
                        <a asp-action="Details" onclick="GetById('${data.id}')" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#getIdModal">Details</a> 
                        <a asp-action="Delete" onclick="DeleteById('${ data.id}','${data.name}')" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#deleteModal">Delete</a>`
                }
            },
        ],
    });
});

/*
function GetById(id) {
    $.ajax({
        url: `https://localhost:7153/api/Department/${id}`,
        method: 'GET',
        }
    }).done((res) => {
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
*/

function AddNew() {
    let buttonSaveAdd = "";
    buttonSaveAdd = `<button class="btn btn-danger" type="submit" onclick="confirmAdd()">Add</button>`
    $("#btn-addnew-department").html(buttonSaveAdd)
}
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
        url: `https://localhost:7153/api/Department/${id}`,
        method: 'DELETE',
        dataType: 'json',
        success: function (message) {
            alert("Delete Data Successfull" + message);
            location.reload();
        }
    })
}