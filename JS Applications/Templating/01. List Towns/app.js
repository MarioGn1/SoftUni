let towns = document.getElementById('towns');
let btnLoadEl = document.getElementById('btnLoadTowns');
let rootEl = document.getElementsByTagName('ul')[0];
let townView = document.getElementById('towns-template').innerHTML;

btnLoadEl.addEventListener('click', e => {   
    let townsData = towns.value.split(', ').map(town => {return {town: town}});

    let townTemplate = Handlebars.compile(townView);    

    let townsHtml = townTemplate({townsData});    

    rootEl.innerHTML = townsHtml;

    towns.value = '';
})

