// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
   https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js
    
        // Simulação de máscara para o CEP
        document.getElementById('Cep').addEventListener('input', function (e) {
            var value = e.target.value.replace(/\D/g, '');
            if (value.length > 5) {
                value = value.substring(0, 5) + '-' + value.substring(5, 8);
            }
            e.target.value = value;
        });

        // Simulação de busca de CEP
        document.getElementById('btnBuscarCep').addEventListener('click', function() {
            const cep = document.getElementById('Cep').value;
            if (cep.length === 9) {
                // Simulação de uma busca de CEP
                alert('Buscando endereço para o CEP: ' + cep);
                // Em uma aplicação real, aqui viria uma chamada à API de CEP
            } else {
                alert('Por favor, insira um CEP válido no formato 00000-000');
            }
        });
   