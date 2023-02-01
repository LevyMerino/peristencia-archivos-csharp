// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function submitEdit(id) {

    const form = document.querySelector("#editForm")

    const data = {

        Id: id,
        Nombre: form.nombre.value,
        Concentracion: form.concentracion.value,
        IdFormaFamamaceutica: form.formaFarmaceutica.value,
        Precio: form.precio.value,
        Stock: form.stock.value,
        Presentacion: form.presentacion.value,
        Habilitado: form.habilitado.value,

    }


    $.ajax({
        url: '/Home/EditItem',
        type: 'PUT',
        dataType: 'json',
        contentType: "application/json",
        data: JSON.stringify(data),
        success: function () {

        },
        error: function () {

        },
        complete: function () {

        }
    });

}

function submitCreate() {


    const form = document.querySelector("#createForm");

    const data = {

        Id: 0,
        Nombre: form.nombre.value,
        Concentracion: form.concentracion.value,
        IdFormaFamamaceutica: form.formaFarmaceutica.value,
        Precio: form.precio.value,
        Stock: form.stock.value,
        Presentacion: form.presentacion.value,
        Habilitado: form.habilitado.value,

    }

    $.ajax({
        url: '/Home/CreateItem',
        type: 'POST',
        dataType: 'json',
        contentType: "application/json",
        data: JSON.stringify(data),
        success: function (e) {
            debugger
            console.log(e);
            window.location = "/";
        },
        error: function () {
            debugger
        },
        complete: function () {

        }
    });
}

function submitLogin() {

    const form = document.querySelector("#formLogin")


    debugger

    const data = {

        User: form.user.value,
        Password: form.pass.value
    }


    $.ajax({
        url: '/Home/Login',
        type: 'POST',
        dataType: 'json',
        contentType: "application/json",
        data: JSON.stringify(data),
        success: function (e) {
            debugger
            console.log(e);
            window.location = "/";
        },
        error: function () {
            debugger
        },
        complete: function () {

        }
    });
}
