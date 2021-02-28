(() => {
    renderCatTemplate();

    function renderCatTemplate() {
        let rootEl = document.getElementsByTagName('ul')[0];
        let catView = document.getElementById('cat-template').innerHTML;

        let catsTemplate = Handlebars.compile(catView);

        let catsHtml = catsTemplate({ cats });

        rootEl.innerHTML = catsHtml;

        rootEl.addEventListener('click', e => {
            if (e.target.tagName === 'BUTTON') {
                let infoEl = e.target.parentElement.lastElementChild;
                if (infoEl.style.display !== 'none') {
                    e.target.innerText = 'Show status code'
                    infoEl.style.display = 'none';
                } else {
                    infoEl.style.display = 'block';
                    e.target.innerText = 'Hide status code'
                }
            }
        })
    }
})()
