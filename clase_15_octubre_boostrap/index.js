function procesar(){
    const $email = document.getElementById('exampleFormControlInput1');
    const $name = document.getElementById('exampleFormControlInput2');

    if ($name.value.trim() === "") { // Verifica el valor del campo de nombre
        alert("Debe completar el nombre");
        return;
    }

    if ($email.value.trim() === "") { // Verifica el valor del campo de email
        alert("Debe completar el correo");
        return;
    }
}
