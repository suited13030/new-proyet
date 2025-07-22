document.addEventListener('DOMContentLoaded', () => {
    const urlParams = new URLSearchParams(window.location.search);
    const marcaId = parseInt(urlParams.get('marca'));

    fetch('data.json')
        .then(response => response.json())
        .then(data => {
            const marca = data.marcas.find(m => m.id === marcaId);
            if (marca) {
                document.getElementById('marca-nombre').textContent = `Modelos de ${marca.nombre}`;
                const listaModelos = document.getElementById('lista-modelos');
                marca.modelos.forEach(modelo => {
                    const li = document.createElement('li');
                    const a = document.createElement('a');
                    a.textContent = modelo.nombre;
                    a.href = `detalles_modelo.html?modelo=${modelo.id}`;
                    li.appendChild(a);
                    listaModelos.appendChild(li);
                });
            }
        });
});
