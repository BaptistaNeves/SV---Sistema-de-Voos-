function verificarEstadoDosCamposSenha() {
    var ckAlterarSenha = document.getElementById('ckAlterarSenha');

    if (ckAlterarSenha.checked) {
        senhaInput.disabled = '';
        confirmarSenhaInput.disabled = '';
        senhaAntigaInput.disabled = '';
    } else {
        senhaInput.disabled = 'false';
        confirmarSenhaInput.disabled = 'false';
        senhaAntigaInput.disabled = 'false';
    }
}

(function () {
    var ckAlterarSenha = document.getElementById('ckAlterarSenha');
    var senhaInput = document.getElementById('senhaInput');
    var confirmarSenhaInput = document.getElementById('confirmarSenhaInput');
    var senhaAntigaInput = document.getElementById('senhaAntigaInput');

    verificarEstadoDosCamposSenha();

    ckAlterarSenha.addEventListener('click', function () {
        if (this.checked) {
            senhaInput.disabled = '';
            confirmarSenhaInput.disabled = '';
            senhaAntigaInput.disabled = '';
        } else {
            senhaInput.disabled = 'false';
            confirmarSenhaInput.disabled = 'false';
            senhaAntigaInput.disabled = 'false';
        }
    });
})();