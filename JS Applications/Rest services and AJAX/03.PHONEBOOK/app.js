function attachEvents() {
    let btnLoad = document.getElementById('btnLoad');
    let btnCreate = document.getElementById('btnCreate');
    let resultsElement = document.getElementById('phonebook');

    let inputPersonEl = document.getElementById('person');
    let inputPhoneEl = document.getElementById('phone');

    btnLoad.addEventListener('click', loadData);
    btnCreate.addEventListener('click', createNewData);
    resultsElement.addEventListener('click', deleteData);

    function loadData(e) {
        resultsElement.innerHTML = '';
        fetch('https://phonebook-nakov.firebaseio.com/phonebook.json')
            .then(res => res.json())
            .then(data => {
                Object.entries(data).forEach(obj => {
                    let liElement = document.createElement('li');
                    liElement.innerHTML = `${obj[1].person}: ${obj[1].phone} <button>Delete</button>`;
                    liElement.id = obj[0];                    
                    resultsElement.appendChild(liElement);
                })                
            })
    }

    function createNewData(e) {
        let obj = {
            person: inputPersonEl.value,
            phone: inputPhoneEl.value
        }

        fetch('https://phonebook-nakov.firebaseio.com/phonebook.json', {
            method: 'POST',
            body: JSON.stringify(obj)
        })
            .then(res => console.log(res.statusText));

        let liElement = document.createElement('li');
        liElement.innerHTML = `${inputPersonEl.value}: ${inputPhoneEl.value} <button>Delete</button>`;
        resultsElement.appendChild(liElement);
        inputPersonEl.value = '';
        inputPhoneEl.value = '';
    }

    function deleteData(e) {
        if (e.target.tagName === 'BUTTON') {
            let key = e.target.parentElement.id;
            fetch(`https://phonebook-nakov.firebaseio.com/phonebook/${key}.json `, {
                method: 'DELETE'
            })
            .then(res => console.log(res.statusText));
            resultsElement.removeChild(e.target.parentElement);
        }
    }
}

attachEvents();