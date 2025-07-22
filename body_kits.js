document.addEventListener('DOMContentLoaded', () => {
    const urlParams = new URLSearchParams(window.location.search);
    const modeloId = parseInt(urlParams.get('modelo'));

    fetch('data.json')
        .then(response => response.json())
        .then(data => {
            for (const marca of data.marcas) {
                const modelo = marca.modelos.find(m => m.id === modeloId);
                if (modelo) {
                    document.getElementById('modelo-nombre').textContent = `Body Kits para ${modelo.nombre}`;
                    const listaBodyKits = document.getElementById('lista-body-kits');
                    modelo.body_kits.forEach(kit => {
                        const li = document.createElement('li');
                        const a = document.createElement('a');
                        a.textContent = kit.nombre;
                        a.href = `detalles_body_kit.html?kit=${kit.id}`;
                        li.appendChild(a);
                        listaBodyKits.appendChild(li);
                    });
                    break;
                }
            }
        });
});
