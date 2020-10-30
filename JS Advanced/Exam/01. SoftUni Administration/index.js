function solve() {
    let lectureEl = document.getElementsByTagName('input')[0];
    let dateEl = document.getElementsByTagName('input')[1];
    let selectEl = document.getElementsByTagName('select')[0];
    let trainigsDivEl = document.getElementsByClassName('modules')[0];
    let addBtnEl = document.getElementsByTagName('button')[0];

    addBtnEl.addEventListener('click', addLecture);
    trainigsDivEl.addEventListener('click', deleteLectures);

    function addLecture(e) {
        if (lectureEl.value && dateEl.value && selectEl.value !== 'Select module') {
            let h3El = document.createElement('h3');
            h3El.innerText = selectEl.value.toUpperCase() + '-MODULE';

            let existingModules = Array.from(trainigsDivEl.getElementsByTagName('h3'));
            let curModule = existingModules.find(el => el.innerText === h3El.innerText);

            if (!curModule) {
                let divEl = document.createElement('div');
                divEl.classList.add('module');
                divEl.appendChild(h3El);

                let ulEl = document.createElement('ul');
                ulEl.appendChild(createLiEl());
                
                divEl.appendChild(ulEl);
                trainigsDivEl.appendChild(divEl);
            } else {
                let curUlEl = curModule.parentElement.getElementsByTagName('ul')[0];
                curUlEl.appendChild(createLiEl());

                let allLectures = Array.from(curUlEl.getElementsByTagName('li'));
                allLectures.sort((a, b) => {
                    let first = a.firstChild.innerText.split(' - ');
                    let second = b.firstChild.innerText.split(' - ');
                    return first[1].localeCompare(second[1]);
                });

                curUlEl.innerHTML = '';
                for (let i = 0; i < allLectures.length; i++) {
                    curUlEl.appendChild(allLectures[i]);
                }
            }
        }
        e.preventDefault()
    }
    function deleteLectures(e) {
        if (e.target.tagName === 'BUTTON') {
            let curUL = e.target.parentElement.parentElement;
            curUL.removeChild(e.target.parentElement);
            if (curUL.innerHTML === '') {
                curUL.parentElement.parentElement.removeChild(curUL.parentElement);
            }
        }
    }
    function createLiEl() {
        let liEl = document.createElement('li');
        liEl.classList.add('flex');

        let h4El = document.createElement('h4');
        let date = dateEl.value.split('T');
        date[0] = date[0].split('-').join('/');
        h4El.innerText = lectureEl.value + ' - ' + date[0] + ' - ' + date[1];
        liEl.appendChild(h4El);

        let btnDelEl = document.createElement('button');
        btnDelEl.classList.add('red');
        btnDelEl.innerText = 'Del';
        liEl.appendChild(btnDelEl);

        return liEl;
    }
};