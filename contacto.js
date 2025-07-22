document.getElementById('formulario-contacto').addEventListener('submit', function(event) {
    event.preventDefault();
    alert('Formulario enviado. Nos pondremos en contacto contigo pronto.');
    this.reset();
});
