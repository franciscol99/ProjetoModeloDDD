

var palavras = [
    "Macarrao", "Arroz", "Feijao", "Bolo", "Banana", "Morango", "Café",
    "Miojo", "Nutella", "Carne", "Frango", "Galinha Caipira", "Arroz Tio Joao",
    "Frango Frito", "Carne Moida", "Chocolate", "Nescau", "Sabão em Pó",
    "Energetico Monster", "Energetico RedBull", "Mouse Gamer", "Teclado Gamer",
    "Monitor", "Video Game", "Bolacha", "Sal", "Televisao", "Flor", "Calça",
    "Açucar", "Ovo", "Requeijão", "Torrada", "Blusa de Frio", "Roupa", "Brinquedo"
];

function GerarDataAleatoria() {
    let start = new Date(2020, 31, 12); 
    let end = new Date(); 
    return new Date(start.getTime() + Math.random() * (end.getTime() - start.getTime())).toISOString().slice(0, 10);
}
function GerarNomeAleatorio(length) {
    return palavras[Math.floor(Math.random() * palavras.length)];
}

function GerarCodigoAleatorio(length) {
    //const chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    let result = "";
    for (let i = 0; i < length; i++) {
        result += chars.charAt(Math.floor(Math.random() * chars.length));
    }
    return result;
}

function GerarTextoAleatorio(NumParagrafo, NumFrasesPorParagrafo, NumPalavras) {
    const palavrasTexto = palavras;
    const paragrafos = [];

    for (let p = 0; p < NumParagrafo; p++) {
        const frases = [];

        for (let i = 0; i < NumFrasesPorParagrafo; i++) {
            const NumeroDePalavras = NumPalavras || Math.floor(Math.random() * 10) + 5;
            const palavrasDaFrase = [];

            for (let j = 0; j < NumeroDePalavras; j++) {
                const indexPalavra = Math.floor(Math.random() * palavrasTexto.length);
                palavrasDaFrase.push(palavrasTexto[indexPalavra]);
            }

            const frase = palavrasDaFrase.join(' ')
                + '';
            frases.push(frase.charAt(0).toUpperCase() + frase.slice(1));
        }

        paragrafos.push(frases.join(' '));
    }

    return paragrafos.join('\n\n');
}