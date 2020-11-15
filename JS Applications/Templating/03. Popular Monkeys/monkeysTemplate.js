$(() => {
    let rootEl = document.getElementsByClassName('monkeys')[0];

    let monkeyView = document.getElementById('monkey-template').innerHTML;
    
    let monkeysTemplate = Handlebars.compile(monkeyView);

    let monkeysHtml = monkeysTemplate({monkeys});

    rootEl.innerHTML = monkeysHtml;

    rootEl.addEventListener('click', e => {
        if (e.target.tagName === 'BUTTON') {
            let infoEl = e.target.nextElementSibling;
            if (infoEl.style.display !== 'none') {
                infoEl.style.display = 'none';
                e.target.innerText = 'Info';
            }else{
                infoEl.style.display = 'block';
                e.target.innerText = 'Hide';
            }
        }
    })
})