//pone la foto de un file en un img
function plasmaFoto(input, objFoto) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#'+objFoto).attr('src', e.target.result);
            FileToSave = e.target.files;
        }
        reader.readAsDataURL(input.files[0]);
    }
}