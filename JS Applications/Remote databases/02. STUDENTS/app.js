async function solve() {
    const baseUrl = 'https://exercise-remote-database.firebaseio.com';
    let refreshBtnEl = document.getElementsByTagName('button')[1];
    let submitBtnEl = document.getElementsByTagName('button')[0];
    let tbodyEl = document.getElementsByTagName('tbody')[0];

    let idInputEl = document.getElementById('studentId');
    let firstNameInputEl = document.getElementById('firstName');
    let lastNameInputEl = document.getElementById('lastName');
    let facultyNumberInputEl = document.getElementById('facultyNumber');
    let gradeInputEl = document.getElementById('grade');

    loadData()

    submitBtnEl.addEventListener('click', createStudent);
    refreshBtnEl.addEventListener('click', loadData);
    tbodyEl.addEventListener('click', delStudent);

    function delStudent(e) {
        if (e.target.tagName === 'BUTTON') {
            let rawID = e.target.parentElement.parentElement.id;
            let rawEl = e.target.parentElement.parentElement;            
            if (e.target.innerText === 'Delete') {
                deleteStudent(rawID);
                tbodyEl.removeChild(rawEl);
            }
        }
    }
    async function deleteStudent(id) {        
        try {            
            await fetch(`${baseUrl}/students/${id}.json`, {
                method: 'DELETE'
            })
        } catch (error) {
            console.log(error.message);
        }
    }

    async function loadData() {
        try {
            tbodyEl.innerHTML = '';
            let resData = await fetch(baseUrl + '/students.json');
            let data = await resData.json();
            let trawData = Object.entries(data)
                .sort(sortStudents)
                .map(studentObj => createRaw(studentObj[1], studentObj[0]))
                .join('');
            tbodyEl.innerHTML = trawData;
        } catch (e) {
            console.log(e.message);
        }
    }

    function sortStudents(a, b) {
        return Number(a[1].id) - Number(b[1].id);
    }

    function createStudent(e) {
        let obj = {
            id: idInputEl.value,
            firstName: firstNameInputEl.value,
            lastName: lastNameInputEl.value,
            facultyNumber: facultyNumberInputEl.value,
            grade: gradeInputEl.value
        }
        fetch(baseUrl + '/students.json', {
            method: 'POST',
            body: JSON.stringify(obj)
        })
            .then(res => res.json())
            .then(() => loadData())
            .catch(e => console.log(e.message))

        idInputEl.value = '';
        firstNameInputEl.value = '';
        lastNameInputEl.value = '';
        facultyNumberInputEl.value = '';
        gradeInputEl.value = '';

        e.preventDefault();
    }

    function createRaw(obj, id) {
        let trEl = document.createElement('tr');

        let idEl = document.createElement('td')
        let firstNameEl = document.createElement('td')
        let lastNameEl = document.createElement('td')
        let facultyNumberEl = document.createElement('td')
        let gradeEl = document.createElement('td')
        let btnsEl = document.createElement('td');
        let btnDelEl = document.createElement('button');

        idEl.innerText = obj.id;
        firstNameEl.innerText = obj.firstName;
        lastNameEl.innerText = obj.lastName;
        facultyNumberEl.innerText = obj.facultyNumber;
        gradeEl.innerText = obj.grade;
        btnDelEl.innerText = 'Delete';

        trEl.appendChild(idEl);
        trEl.appendChild(firstNameEl);
        trEl.appendChild(lastNameEl);
        trEl.appendChild(facultyNumberEl);
        trEl.appendChild(gradeEl);
        btnsEl.appendChild(btnDelEl);
        trEl.appendChild(btnsEl);

        trEl.id = id;
        return trEl.outerHTML;
    }

}

solve();