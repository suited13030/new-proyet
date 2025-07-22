document.addEventListener('DOMContentLoaded', () => {
    const urlParams = new URLSearchParams(window.location.search);
    const modeloId = parseInt(urlParams.get('modelo'));

    fetch('data.json')
        .then(response => response.json())
        .then(data => {
            for (const marca of data.marcas) {
                const modelo = marca.modelos.find(m => m.id === modeloId);
                if (modelo) {
                    document.getElementById('modelo-nombre').textContent = modelo.nombre;
                    document.getElementById('modelo-año').textContent = modelo.año;
                    document.getElementById('modelo-motor').textContent = modelo.motor;
                    document.getElementById('ver-body-kits').href = `body_kits.html?modelo=${modelo.id}`;
                    break;
                }
            }
        });
});
