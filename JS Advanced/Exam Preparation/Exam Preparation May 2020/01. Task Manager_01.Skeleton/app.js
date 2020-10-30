function solve() {
    let inputTaskElement = document.getElementById('task');
    let inputDescriptionElement = document.getElementById('description');
    let inputDateElement = document.getElementById('date');

    let sectionElements = document.getElementsByTagName('section')
    let openSectionElement = sectionElements[1];
    let completeSectionElement = sectionElements[3];
    let divElement = openSectionElement.getElementsByTagName('div')[1];
    let inProgresElement = document.getElementById('in-progress')
    let divCompleteElement = completeSectionElement.getElementsByTagName('div')[1];

    let addBtnElement = document.getElementById('add');

    addBtnElement.addEventListener('click', addInOpenSection);
    openSectionElement.addEventListener('click', inProgress);
    inProgresElement.addEventListener('click', complete)

    function addInOpenSection(е) {
        if (inputTaskElement.value && inputDescriptionElement.value && inputDateElement.value) {
            let articleElement = document.createElement('article');

            let h3Element = document.createElement('h3');
            h3Element.innerText = inputTaskElement.value;
            articleElement.appendChild(h3Element);
            let descriptionElement = document.createElement('p');
            descriptionElement.innerText = 'Description: ' + inputDescriptionElement.value;
            articleElement.appendChild(descriptionElement);
            let dateElement = document.createElement('p');
            dateElement.innerText = 'Due Date: ' + inputDateElement.value;
            articleElement.appendChild(dateElement);

            let divBtnsElement = document.createElement('div');
            divBtnsElement.classList.add('flex');
            articleElement.appendChild(divBtnsElement);
            let btnStartElement = document.createElement('button');
            btnStartElement.classList.add('green');
            btnStartElement.innerText = 'Start';
            let btnDeleteElement = document.createElement('button');
            btnDeleteElement.classList.add('red');
            btnDeleteElement.innerText = 'Delete';
            divBtnsElement.appendChild(btnStartElement);
            divBtnsElement.appendChild(btnDeleteElement);

            divElement.appendChild(articleElement);
        }
        е.preventDefault();
    }
    function inProgress(e) {
        if (e.target.tagName === 'BUTTON') {
            let curTaskElement = e.target.parentElement.parentElement;
            if (e.target.innerText === 'Start') {
                inProgresElement.appendChild(curTaskElement);
                let btnsElements = curTaskElement.getElementsByTagName('button');
                btnsElements[0].classList.remove('green');
                btnsElements[0].classList.add('red');
                btnsElements[0].innerText = 'Delete';
                btnsElements[1].classList.remove('red');
                btnsElements[1].classList.add('orange');
                btnsElements[1].innerText = 'Finish';

            } else if (e.target.innerText === 'Delete') {
                divElement.removeChild(curTaskElement);
            }


        }
        e.preventDefault();
    }
    function complete(e) {
        if (e.target.tagName === 'BUTTON') {
            let curTaskElement = e.target.parentElement.parentElement;
            let btsParentElement = e.target.parentElement;
            if (e.target.innerText === 'Finish') {
                curTaskElement.removeChild(btsParentElement);
                divCompleteElement.appendChild(curTaskElement);
            } else if (e.target.innerText === 'Delete') {
                inProgresElement.removeChild(curTaskElement);
            }

        }
        e.preventDefault();
    }
}