document.addEventListener('DOMContentLoaded', () => {
    const urlParams = new URLSearchParams(window.location.search);
    const kitId = parseInt(urlParams.get('kit'));

    fetch('data.json')
        .then(response => response.json())
        .then(data => {
            for (const marca of data.marcas) {
                for (const modelo of marca.modelos) {
                    const kit = modelo.body_kits.find(k => k.id === kitId);
                    if (kit) {
                        document.getElementById('kit-nombre').textContent = kit.nombre;
                        document.getElementById('kit-precio').textContent = kit.precio;
                        document.getElementById('kit-materiales').textContent = kit.materiales;
                        document.getElementById('ver-en-3d').href = `vista_3d.html?kit=${kit.id}`;
                        return;
                    }
                }
            }
        });
});
