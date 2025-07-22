document.addEventListener('DOMContentLoaded', () => {
    fetch('data.json')
        .then(response => response.json())
        .then(data => {
            const listaMarcas = document.getElementById('lista-marcas');
            data.marcas.forEach(marca => {
                const li = document.createElement('li');
                const a = document.createElement('a');
                a.textContent = marca.nombre;
                a.href = `modelos.html?marca=${marca.id}`;
                li.appendChild(a);
                listaMarcas.appendChild(li);
            });
        });
});
