function solve() {
    const baseUrl = 'https://exercise-remote-database.firebaseio.com';
    let isBookChoosen = false;
    let loadBtnEl = document.getElementById('loadBooks');
    let tableBodyEl = document.getElementsByTagName('tbody')[0];
    let inputFormEl = document.getElementsByTagName('form')[0];
    let titleEl = document.getElementById('title');
    let authorEl = document.getElementById('author');
    let isbnEl = document.getElementById('isbn');
    let submitBtnEl = inputFormEl.getElementsByTagName('button')[0];

    loadBtnEl.addEventListener('click', loadBooks);
    submitBtnEl.addEventListener('click', submitNewBook);
    tableBodyEl.addEventListener('click', bookManipulation)

    function bookManipulation(e) {

        if (e.target.tagName === 'BUTTON') {
            let rawID = e.target.parentElement.parentElement.id;
            let rawEl = e.target.parentElement.parentElement;
            let isSelected = rawEl.getAttribute('select-id');
            if (e.target.innerText === 'Delete') {
                deleteBook(rawID);
                tableBodyEl.removeChild(rawEl);
            } else if (e.target.innerText === 'Edit' && !isBookChoosen) {
                isBookChoosen = true;
                fillBookForm(e.target.parentElement.parentElement);
                rawEl.setAttribute('select-id', 'selected');
                rawEl.classList.add('mark');
            } else if (e.target.innerText === 'Edit' && isBookChoosen && isSelected) {
                updateBookInDatabase(rawID);
                updateRaw(rawEl);
                rawEl.removeAttribute('select-id');
                rawEl.classList.remove('mark');
                isBookChoosen = false;
            }

        } else if (e.target.tagName === 'TD') {
            let rawEl = e.target.parentElement;
            let isSelected = rawEl.getAttribute('select-id');
            if (!isSelected && !isBookChoosen) {
                isBookChoosen = true;
                fillBookForm(e.target.parentElement);
                rawEl.setAttribute('select-id', 'selected');
                rawEl.classList.add('mark');
            }
        }
    }

    async function updateBookInDatabase(id) {
        try {
            await fetch(`${baseUrl}/books/${id}.json`, {
                method: 'PUT',
                body: JSON.stringify(createObj())
            })
        } catch (error) {
            console.log(error.message);
        }

    }

    function updateRaw(raw) {
        let bookInfo = Array.from(raw.getElementsByTagName('td'));
        bookInfo[0].innerText = titleEl.value;
        bookInfo[1].innerText = authorEl.value;
        bookInfo[2].innerText = isbnEl.value;
        submitBtnEl.style.display = 'block';
        inintInput()
    }

    function fillBookForm(raw) {
        let bookInfo = Array.from(raw.getElementsByTagName('td'));
        titleEl.value = bookInfo[0].innerText;
        authorEl.value = bookInfo[1].innerText;
        isbnEl.value = bookInfo[2].innerText;
        submitBtnEl.style.display = 'none';
    }


    async function deleteBook(id) {
        try {
            let curElement = document.getElementById(id);
            let isSelected = curElement.getAttribute('select-id');
            if (isSelected) {
                submitBtnEl.style.display = 'block';
                isBookChoosen = false;
                inintInput()
            }
            await fetch(`${baseUrl}/books/${id}.json`, {
                method: 'DELETE'
            })
        } catch (error) {
            console.log(error.message);
        }

    }

    function createObj() {
        let obj = {
            title: titleEl.value,
            author: authorEl.value,
            isbn: isbnEl.value
        }
        return obj
    }
    function inintInput() {
        titleEl.value = '';
        authorEl.value = '';
        isbnEl.value = '';
    }

    async function submitNewBook(e) {
        let obj = createObj()
        fetch(baseUrl + '/books.json', {
            method: 'POST',
            body: JSON.stringify(obj)
        })
            .then(res => res.json())
            .then(data => {
                let createdBookId = data.name;
                tableBodyEl.innerHTML += createBookRaw(obj, createdBookId);
            })

        inintInput();
        e.preventDefault();
    }

    async function loadBooks(e) {
        tableBodyEl.innerHTML = '';
        try {
            let resData = await fetch(baseUrl + '/books.json')
            let data = await resData.json();
            createListOfBooks(data);
        } catch (error) {
            console.log(error.message);
        }

    }

    function createListOfBooks(books) {
        let tableList = Object.entries(books)
            .map(book => createBookRaw(book[1], book[0]))
            .join('');
        tableBodyEl.innerHTML = tableList;
    }

    function createBookRaw(obj, id) {
        let rawEl = document.createElement('tr');
        let titleRawEl = document.createElement('td');
        let authorRawEl = document.createElement('td');
        let isbnRawEl = document.createElement('td');
        let btnsEl = document.createElement('td');
        let btnEditEl = document.createElement('button');
        let btnDelEl = document.createElement('button');

        titleRawEl.innerText = obj.title;
        authorRawEl.innerText = obj.author;
        isbnRawEl.innerText = obj.isbn;
        btnEditEl.innerText = 'Edit';
        btnDelEl.innerText = 'Delete';

        btnsEl.appendChild(btnEditEl);
        btnsEl.appendChild(btnDelEl);
        rawEl.appendChild(titleRawEl);
        rawEl.appendChild(authorRawEl);
        rawEl.appendChild(isbnRawEl);
        rawEl.appendChild(btnsEl);

        rawEl.id = id;
        return rawEl.outerHTML;
    }
}

solve();