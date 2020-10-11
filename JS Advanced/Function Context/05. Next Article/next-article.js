function getArticleGenerator(articles) {
    let divElement = document.getElementById('content')
    let curentText = 0;

    function showElement() {
        if (articles[curentText]) {
            let currentEl = document.createElement('article');
            currentEl.textContent = articles[curentText];
            divElement.appendChild(currentEl);
            curentText++;
        }
    }
    return showElement
}
