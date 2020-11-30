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

 function loadPartials(context) {
    return context.loadPartials({
        'header': '../templates/partials/header.hbs',
        'footer': '../templates/partials/footer.hbs'
    })
};

function successfullOperation(message) {
    infoEl.innerText = message;
    infoEl.style.display = 'block';
    setTimeout(() => {
        infoEl.style.display = 'none';
    }, 2000);
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
    }, 3000);
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

function loadContentData(context, id) {
    getData(id)
        .then((response) => {

            setContextData(context, response);

            if (response.data().author === context.username) {
                context.isAuthor = true;
            }
            // if (response.data().likers.find(name => name === context.username)) {
            //     context.isLiked = true;
            // }
            
            loadPartials(context)
                .then(function () {
                    this.partial('../templates/details.hbs')
                });
        })
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