function attachEvents() {
    let catchId = '';
    let bodyEl = document.getElementsByTagName('body')[0];
    let catchesEl = document.getElementById('catches');
    const urlGetAndPost = 'https://fisher-game.firebaseio.com/catches.json';
    let asideEl = document.getElementsByTagName('aside')[0];
    asideEl.style.position = 'fixed';

    bodyEl.addEventListener('click', takeAction);

    function takeAction(e) {
        if (e.target.tagName === 'BUTTON') {
            switch (e.target.innerText) {
                case 'LOAD':
                    loadData();
                    break;
                case 'DELETE':
                    deleteCatch(e.target)
                    break;
                case 'ADD':
                    addCatch()
                    break;
                case 'UPDATE':
                    updateCatch(e.target)
                    break;

                default:
                    break;
            }
        }

    }
    async function loadData() {
        try {
            let resData = await fetch(urlGetAndPost);
            let data = await resData.json();
            catchesEl.innerHTML = '';

            Object.entries(data).forEach(entrie => {
                createCatch(entrie[0], entrie[1]);
            });
        } catch (error) {
            console.log(error.mess);
        }
    }
    async function deleteCatch(target) {
        catchId = target.parentElement.getAttribute('data-id');
        let urlDel = `https://fisher-game.firebaseio.com/catches/${catchId}.json`;
        catchesEl.removeChild(target.parentElement);
        try {
            await fetch(urlDel, {
                method: 'DELETE',
            });
        } catch (error) {
            console.log('Already deleted!');
        }

    }
    async function addCatch() {
        let addFormEl = document.getElementById('addForm')
        let obj = createObj(addFormEl, 'add');
        try {
            await fetch(urlGetAndPost, {
                method: 'POST',
                body: JSON.stringify(obj),
            });
        } catch (error) {
            console.log(error.message)
        }
    }
    async function updateCatch(target) {
        catchId = target.parentElement.getAttribute('data-id');
        let curCatch = target.parentElement;
        let urlUpdate = `https://fisher-game.firebaseio.com/catches/${catchId}.json`;

        let obj = createObj(curCatch);
        try {
            await fetch(urlUpdate, {
                method: 'PUT',
                body: JSON.stringify(obj)
            });
        } catch (error) {
            console.log(error.message);
        }
    }

    function createCatch(id, obj) {
        let catchDiv = document.createElement('div');
        catchDiv.setAttribute('data-id', `${id}`)
        catchDiv.classList.add('catch');

        let anglerLable = document.createElement('label');
        anglerLable.innerText = 'Angler';
        let anglerInput = document.createElement('input');
        anglerInput.classList.add('angler');
        anglerInput.type = 'text';
        anglerInput.value = obj.angler
        let hrAnglerEl = document.createElement('hr');

        let weightLable = document.createElement('label');
        weightLable.innerText = 'Weight';
        let weightInput = document.createElement('input');
        weightInput.classList.add('weight');
        weightInput.type = 'number';
        weightInput.value = obj.weight;
        let hrWeightEl = document.createElement('hr');

        let speciesLable = document.createElement('label');
        speciesLable.innerText = 'Species';
        let speciesInput = document.createElement('input');
        speciesInput.classList.add('species');
        speciesInput.type = 'text';
        speciesInput.value = obj.species;
        let hrSpeciesEl = document.createElement('hr');

        let locationLable = document.createElement('label');
        locationLable.innerText = 'Location';
        let locationInput = document.createElement('input');
        locationInput.classList.add('location');
        locationInput.type = 'text';
        locationInput.value = obj.location;
        let hrLocationEl = document.createElement('hr');

        let baitLable = document.createElement('label');
        baitLable.innerText = 'Bait';
        let baitInput = document.createElement('input');
        baitInput.classList.add('bait');
        baitInput.type = 'text';
        baitInput.value = obj.bait;
        let hrBaitEl = document.createElement('hr');

        let captureTimeLable = document.createElement('label');
        captureTimeLable.innerText = 'Capture Time';
        let captureTimeInput = document.createElement('input');
        captureTimeInput.classList.add('captureTime');
        captureTimeInput.type = 'number';
        captureTimeInput.value = obj.captureTime;
        let hrCaptureTimeEl = document.createElement('hr');

        let btnUpdateEl = document.createElement('button');
        btnUpdateEl.innerText = 'Update';
        btnUpdateEl.classList.add('update');
        let btnDeleteEl = document.createElement('button');
        btnDeleteEl.innerText = 'Delete';
        btnDeleteEl.classList.add('delete');

        catchDiv.appendChild(anglerLable);
        catchDiv.appendChild(anglerInput);
        catchDiv.appendChild(hrAnglerEl);
        catchDiv.appendChild(weightLable);
        catchDiv.appendChild(weightInput);
        catchDiv.appendChild(hrWeightEl);
        catchDiv.appendChild(speciesLable);
        catchDiv.appendChild(speciesInput);
        catchDiv.appendChild(hrSpeciesEl);
        catchDiv.appendChild(locationLable);
        catchDiv.appendChild(locationInput);
        catchDiv.appendChild(hrLocationEl);
        catchDiv.appendChild(baitLable);
        catchDiv.appendChild(baitInput);
        catchDiv.appendChild(hrBaitEl);
        catchDiv.appendChild(captureTimeLable);
        catchDiv.appendChild(captureTimeInput);
        catchDiv.appendChild(hrCaptureTimeEl);
        catchDiv.appendChild(btnUpdateEl);
        catchDiv.appendChild(btnDeleteEl);
        catchesEl.appendChild(catchDiv);
    }
    function createObj(target, type) {
        let anglerEl = target.getElementsByClassName('angler')[0];
        let weightEl = target.getElementsByClassName('weight')[0];
        let speciesEl = target.getElementsByClassName('species')[0];
        let locationEl = target.getElementsByClassName('location')[0];
        let baitEl = target.getElementsByClassName('bait')[0];
        let captureTimeEl = target.getElementsByClassName('captureTime')[0];
        let obj = {
            angler: anglerEl.value,
            weight: weightEl.value,
            species: speciesEl.value,
            location: locationEl.value,
            bait: baitEl.value,
            captureTime: captureTimeEl.value,
        }
        if (type) {
            anglerEl.value = '';
            weightEl.value = '';
            speciesEl.value = '';
            locationEl.value = '';
            baitEl.value = '';
            captureTimeEl.value = '';
        }
        return obj;
    }
}

attachEvents();

