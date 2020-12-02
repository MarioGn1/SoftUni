const auth = firebase.auth();
const db = firebase.firestore();
let infoEl = document.getElementById('infoBox');
let errorEl = document.getElementById('errorBox');

const app = Sammy('.root', function () {
    this.use('Handlebars', 'hbs');

    //GET
    this.get('#/home', function (context) {
        checkForLoggedUser(context);

        let movies = [];
        db.collection('movies').get().then(moviesData => {
            moviesData.forEach(movie => {
                movies.push({
                    title: movie.data().title,
                    imageUrl: movie.data().imageUrl,
                    id: movie.id,
                })
            })

            this.loadPartials({
                'movieCard': '../templates/partials/movieCard.hbs',
                'header': '../templates/partials/header.hbs',
                'footer': '../templates/partials/footer.hbs'
            })
                .then(function () {
                    this.partial('../templates/home.hbs', { movies });
                })
        });
    });
    this.get('#/login', function (context) {
        checkForLoggedUser(context);
        loadPartials(context)
            .then(function () {
                this.partial('../templates/login.hbs')
            });
    });
    this.get('#/register', function (context) {
        checkForLoggedUser(context);
        loadPartials(context)
            .then(function () {
                this.partial('../templates/register.hbs')
            });
    });
    this.get('#/logout', function (context) {

        auth.signOut()
            .then(() => {
                localStorage.removeItem('userInfo');
                context.redirect('#/home');
                successfullOperation('You successfully signed out!');
            })
            .catch(e => console.log(e.message))
    });
    this.get('#/add', function (context) {
        checkForLoggedUser(context);

        loadPartials(context)
            .then(function () {
                this.partial('../templates/add.hbs')
            });
    })
    this.get('#/details/:id', function (context) {
        let contentId = this.params.id.split(':')[1];
        
        checkForLoggedUser(context);
        context.isAuthor = false;

        loadContentData(context, contentId);
    });
    this.get('#/like/:id', function (context) {
        let contentId = this.params.id;
        
        checkForLoggedUser(context);
        getData(contentId)
        .then((response) => {
            setContextData(context, response);
            context.likers.push(context.username)
            let likes = context.likers.length;
            
            let objUpdate = {
                title: context.title,
                description: context.description,
                imageUrl: context.imageUrl,
                author: context.author,
                likers: context.likers,
                likes
            }
            
            db.collection('movies').doc(contentId).update(objUpdate)
            successfullOperation('Successfully liked!')
            context.redirect(`#/details/:${contentId}`)
        })        
    });
    this.get('#/edit/:id', function (context){
        let contentId = this.params.id;
        checkForLoggedUser(context);
        getData(contentId)
        .then(data =>{
            console.log(data);
            setContextData(context, data)
            loadPartials(context)
            .then(function () {
                this.partial('../templates/edit.hbs')
            });
        })

    })
    this.get('#/delete/:id', function(context){
        let id = this.params.id;

        db.collection('movies')
        .doc(id)
        .delete()
        .then(() => context.redirect('#/home'))
        .catch(error => regLoginFail(error));        
    });

    //POST
    this.post('#/register', function (context) {

        const { email, password, repeatPassword } = context.params;
        if (password !== repeatPassword) {
            regLoginFail();
        } else {
            auth.createUserWithEmailAndPassword(email, password)
                .then(() => {
                    successfullOperation('You succesfully create account!');
                    context.redirect('#/home');
                })
                .catch(error => {
                    regLoginFail(error);
                });
        }
    })
    this.post('#/login', function (context) {

        let { email, password } = context.params;
        auth.signInWithEmailAndPassword(email, password)
            .then(resp => {
                successfullOperation('You succesfully signed in!');
                let userCredentils = {
                    username: resp.user.email,
                    uId: resp.user.uid
                }
                localStorage.setItem('userInfo', JSON.stringify(userCredentils));
                context.redirect('#/home');
            })
            .catch(error => regLoginFail(error))
    });
    this.post('#/add', function (context) {
        checkForLoggedUser(context);
        let { title, description, imageUrl } = context.params;

        try {
            if (!title || !description || !imageUrl) {
                throw new Error('Fields can not be empty strings!')
            }
            db.collection("movies").add({
                title,
                description,
                imageUrl,
                author: context.username,
                likers: []
            })
            successfullOperation(`You successfully create movie card ${title}`)
            context.redirect('#/home')
        } catch (error) {
            errorCatch(error);

        }
    });
    this.post('#/edit/:id', function (context) {
        let id = this.params.id;
        checkForLoggedUser(context);
        let { title, description, imageUrl } = context.params;

        db.collection("movies").doc(id).update({
            title,
            description,
            imageUrl,
        })
        context.redirect(`#/details/:${id}`)
    });

});

app.run('#/home');

function loadPartials(context) {
    return context.loadPartials({
        'header': '../templates/partials/header.hbs',
        'footer': '../templates/partials/footer.hbs'
    })
}

function checkForLoggedUser(context) {
    let userInfo = JSON.parse(localStorage.getItem('userInfo'));
    if (userInfo) {
        context.username = userInfo.username;
        context.loggedUser = true;
        return userInfo.username;
    }

}

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
            if (response.data().likers.find(name => name === context.username)) {
                context.isLiked = true;
            }
            
            loadPartials(context)
                .then(function () {
                    this.partial('../templates/details.hbs')
                });
        })
}

function getData(id) {
    
    return db.collection("movies").doc(id)
        .get()
}

function setContextData(context, sorce) {    
    context.title = sorce.data().title;
    context.description = sorce.data().description;
    context.imageUrl = sorce.data().imageUrl;
    context.author = sorce.data().author;
    context.likers = sorce.data().likers;
    context.likes = sorce.data().likes
    context.id = sorce.id;
}