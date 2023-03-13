$(document).ready(function () {
    $('.input-date').mask('00/00/0000');
    $('.date').mask('00/00/0000');
    $('.phone').mask('(00) 00000-0000');
});


function CloseModal() {
    document.getElementById('modal').style.cssText = 'display: none;';
}
document.querySelector('.input-botao-modal').onclick = CloseModal;

