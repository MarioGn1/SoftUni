function solve() {
    let inputs = Array.from(document.getElementsByTagName('input'));
    let [nameElement, ageElement, kindElement, curOwnerElement] = [...inputs];
    let addBtnElement = document.getElementsByTagName('button')[0];
    let adoptionList = document.getElementsByTagName('ul')[0];
    let adoptedList = document.getElementsByTagName('ul')[1];

    addBtnElement.addEventListener('click', addPet);
    adoptionList.addEventListener('click', contactOwner);
    adoptedList.addEventListener('click', removeFromList)

    function addPet(e) {
        if (nameElement.value && ageElement.value && !isNaN(ageElement.value) && kindElement.value && curOwnerElement.value) {
            let liElement = document.createElement('li');
            let pElement = document.createElement('p');
            liElement.appendChild(pElement);

            let nameStrong = document.createElement('strong');
            nameStrong.innerText = nameElement.value;
            pElement.appendChild(nameStrong);
            let textnode = document.createTextNode(' is a ');
            pElement.appendChild(textnode);

            let ageStrong = document.createElement('strong');
            ageStrong.innerText = ageElement.value;
            pElement.appendChild(ageStrong);
            let textnode2 = document.createTextNode(' year old ');
            pElement.appendChild(textnode2);

            let kindStrong = document.createElement('strong');
            kindStrong.innerText = kindElement.value;
            pElement.appendChild(kindStrong);
            // pElement.innerText = `${nameStrong}` + ' is a ' + nameStrong.innerText + ' year old ' + kindStrong.innerText;

            let spanElement = document.createElement('span');
            spanElement.innerText = 'Owner: ' + curOwnerElement.value;
            liElement.appendChild(spanElement);

            let btnElement = document.createElement('button');
            btnElement.innerText = 'Contact with owner';
            liElement.appendChild(btnElement);
            adoptionList.appendChild(liElement);

            inputs.forEach(el => el.value = '');
        }

        e.preventDefault()
    }

    function contactOwner(e) {
        if (e.target.tagName === 'BUTTON' && e.target.innerText === 'Contact with owner') {
            let divElement = document.createElement('div');
            let inputElement = document.createElement('input');
            inputElement.placeholder = 'Enter your names';
            divElement.appendChild(inputElement);
            let btnElement = document.createElement('button');
            btnElement.innerText = 'Yes! I take it!'
            divElement.appendChild(btnElement)
            let liElement = e.target.parentElement;
            liElement.removeChild(e.target)
            liElement.appendChild(divElement);
        } else if (e.target.tagName === 'BUTTON' && e.target.innerText === 'Yes! I take it!') {
            let petToMoveElement = e.target.parentElement.parentElement;
            let newOwner = petToMoveElement.getElementsByTagName('input')[0].value;
            if (newOwner) {
                let spanEl = petToMoveElement.getElementsByTagName('span')[0];
                spanEl.innerText = `New Owner: ${newOwner}`;

                petToMoveElement.removeChild(e.target.parentElement);
                adoptionList.removeChild(petToMoveElement)

                let btnElement = document.createElement('button');
                btnElement.innerText = 'Checked';
                petToMoveElement.appendChild(btnElement);
                adoptedList.appendChild(petToMoveElement);
            }
        }
    }

    function removeFromList(e) {
        if (e.target.tagName === 'BUTTON') {
            adoptedList.removeChild(e.target.parentElement)
        }

    }
}

