function OpenModalForm(id, name, email, birthday, cell, phone, address, status_register) {

    document.getElementById('modal').style.cssText = 'display: block;';

    $('#emailInativar').val(email);
    $('#id').val(id);
    $('#customerName').val(name);
    $('#Email').val(email);
    $('#Birthday').val(birthday);
    $('#CellPhone').val(cell);
    $('#Phone').val(phone);
    $('#addressCustomer').val(address);
    $('#status_register').val(status_register);

};

function CloseModalForm() {

    $('#emailInativar').val('');
    $('#id').val('');
    $('#customerName').val('');
    $('#Email').val('');
    $('#Birthday').val('');
    $('#CellPhone').val('');
    $('#Phone').val('');
    $('#addressCustomer').val('');
    $('#status_register').val('');

    document.getElementById('modal').style.cssText = 'display: none;';

};


function ConfirmarInativar() {

    Swal.fire({
        title: 'Deseja inativar o cliente?',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sim, Inativar!'
    }).then((result) => {
        if (result.isConfirmed) {

            const idInativar = document.getElementById('id').value;
            document.getElementById('formInativo').submit();

        }
    });
};
