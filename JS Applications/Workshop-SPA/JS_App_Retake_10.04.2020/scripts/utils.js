const auth = firebase.auth();
const db = firebase.firestore();
let infoEl = document.getElementById('infoBox');
let errorEl = document.getElementById('errorBox');

function checkForLoggedUser(context) {
    let userInfo = JSON.parse(localStorage.getItem('userInfo'));
    if (userInfo) {
        context.username = userInfo.username;
        context.loggedUser = true;
        return userInfo.username;
    }
};

async function loadPartials(context) {
    const partials = await Promise.all([
        context.load('../templates/partials/header.hbs'),
        context.load('../templates/partials/footer.hbs')
    ])
    context.partials = {
        'header': partials[0],
        'footer': partials[1]
    }
};

function successfullOperation(message) {
    infoEl.innerText = message;
    infoEl.style.display = 'block';
    setTimeout(() => {
        infoEl.style.display = 'none';
    }, 1000);
}

function errorCatch(error) {
    if (error) {
        errorEl.innerText = error.message;
    } else {
        errorEl.innerText = 'Your passwords do not match same values!';
    }
    errorEl.style.display = 'block';
    setTimeout(() => {
        errorEl.style.display = 'none';
    }, 1000);
}

function regLoginFail(error) {
    errorCatch(error)
    let usernameEl = document.getElementById('username');
    let passwordEl = document.getElementById('password');
    let repeatpassEl = document.getElementById('repeatPassword');
    usernameEl.value = '';
    passwordEl.value = '';
    if (repeatpassEl) {
        repeatpassEl.value = '';
    }
}

async function loadContentData(context, id) {
    const response = await getData(id);

    setContextData(context, response);

    if (response.data().author === context.username) {
        context.isAuthor = true;
    }
    // if (response.data().likers.find(name => name === context.username)) {
    //     context.isLiked = true;
    // }

    await loadPartials(context);
    context.partial('../templates/details.hbs');
}

function getData(id) {
    return db.collection("blogPosts").doc(id)
        .get()
}

function setContextData(context, sorce) {
    context.title = sorce.data().title;
    context.category = sorce.data().category;
    context.content = sorce.data().content;
    context.author = sorce.data().author;
    context.id = sorce.id;
}

export {
    checkForLoggedUser,
    loadPartials,
    successfullOperation,
    errorCatch,
    regLoginFail,
    loadContentData,
    getData,
    setContextData,
    auth,
    db
}