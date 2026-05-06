// Usando caminho relativo
const apiUrl = '/api/Livros';

async function carregarLivros() {
    try {
        const resposta = await fetch(apiUrl);
        const livros = await resposta.json();

        const tbody = document.getElementById('tabelaCorpo');
        tbody.innerHTML = ''; 

        livros.forEach(livro => {
            tbody.innerHTML += `
                <tr>
                    <td>${livro.id}</td>
                    <td>${livro.titulo}</td>
                    <td>${livro.autor}</td>
                </tr>
            `;
        });
    } catch (erro) {
        alert("Erro ao buscar os dados.");
        console.error(erro);
    }
}

async function cadastrarLivro() {
    const token = document.getElementById('inputToken').value;

    if (!token) {
        alert("Acesso Negado: Cole o Token JWT primeiro!");
        return;
    }

    const novoLivro = {
        titulo: "Senhor dos Anéis",
        autor: "Tolkien",
        anoPublicacao: 1954
    };

    try {
        const resposta = await fetch(apiUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${token}` 
            },
            body: JSON.stringify(novoLivro)
        });

        if (resposta.ok) {
            alert("Livro cadastrado com sucesso!");
            carregarLivros(); 
        } else {
            alert("Erro 401: Token inválido ou expirado.");
        }
    } catch (erro) {
        console.error(erro);
    }
}
