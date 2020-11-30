const auth = firebase.auth();
const db = firebase.firestore();
let infoEl = document.getElementById('infoBox');
let errorEl = document.getElementById('errorBox');

const app = Sammy('#main', function () {

    this.use('Handlebars', 'hbs');

    //GET
    this.get('#/home', function (context) {

        checkForLoggedUser(context);
        if (context.loggedUser) {
            context.redirect('#/shoes')
        }

        loadPartials(context)
            .then(function () {
                this.partial('../templates/home/home.hbs')
            });
    });
    this.get('#/login', function (context) {

        checkForLoggedUser(context);

        loadPartials(context)
            .then(function () {
                this.partial('../templates/login/login.hbs')
            });
    });
    this.get('#/register', function (context) {

        checkForLoggedUser(context);

        loadPartials(context)
            .then(function () {
                this.partial('../templates/register/register.hbs')
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
    })
    this.get('#/create', function (context) {
        checkForLoggedUser(context);

        loadPartials(context)
            .then(function () {
                this.partial('../templates/offerControls/create.hbs')
            });
    })
    this.get('#/shoes', function (context) {

        checkForLoggedUser(context);

        let shoes = [];

        db.collection('shoes').get().then(shoesData => {
            shoesData.forEach(shoe => {
                shoes.push({
                    brand: shoe.data().brand,
                    model: shoe.data().model,
                    imageUrl: shoe.data().imageUrl,
                    price: shoe.data().price,
                    id: shoe.id,
                    author: context.username
                })
            })
            this.loadPartials({
                'header': '../templates/common/header.hbs',
                'footer': '../templates/common/footer.hbs',
                'shoe': '../templates/shoes/shoe.hbs'
            }).then(function () {
                this.partial('../templates/shoes/shoes.hbs', { shoes })
            })
        });
    });
    this.get('#/details/:id', function (context) {
        let shoeId = this.params.id.split(':')[1];

        checkForLoggedUser(context);
        context.isAuthor = false;

        loadShoesData(context, shoeId);
    });
    this.get('#/details/bought/:id', function (context) {
        let shoeId = this.params.id.split(':')[1];
        context.bought = true
        checkForLoggedUser(context);
        context.isAuthor = false;

        loadShoesData(context, shoeId);
    })
    this.get('#/edit/:id', function (context){
        let shoeId = this.params.id.split(':')[1];
        checkForLoggedUser(context);
        getData(shoeId)
        .then(shoeData =>{
            setContextData(context, shoeData)
            loadPartials(context)
            .then(function () {
                this.partial('../templates/offerControls/edit.hbs')
            });
        })

    })
    this.get('#/delete/:id', function(context){
        let id = this.params.id.split(':')[1];

        db.collection('shoes')
        .doc(id)
        .delete()
        .then()
        .catch(error => regLoginFail(error));

        context.redirect('#/shoes');
    });

    //POST
    this.post('#/register', function (context) {

        const { username, password, repeatPassword } = context.params;
        console.log(username);
        if (password !== repeatPassword) {
            regLoginFail();
        } else {
            auth.createUserWithEmailAndPassword(username, password)
                .then(() => {
                    successfullOperation('You succesfully create account!');
                    context.redirect('#/login');
                })
                .catch(error => {
                    regLoginFail(error);
                });
        }
    })
    this.post('#/login', function (context) {

        let { username, password } = context.params;
        auth.signInWithEmailAndPassword(username, password)
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
    })
    this.post('#/create', function (context) {

        checkForLoggedUser(context);
        let { model, brand, description, price, imageUrl } = context.params;

        db.collection("shoes").add({
            model,
            brand,
            description,
            price,
            imageUrl,
            author: context.username            
        })
        context.redirect('#/home')
    })
    this.post('#/edit/:id', function (context) {

        let id = this.params.id.split(':')[1];
        checkForLoggedUser(context);
        let { model, brand, description, price, imageUrl,} = context.params;             
        
        db.collection("shoes").doc(id).update({
            model,
            brand,
            description,
            price,
            imageUrl,
            author: context.username 
        })
        context.redirect(`#/details/:${id}`)
    })
});

(() => {
    app.run('#/home');
})()

function loadPartials(context) {
    return context.loadPartials({
        'header': '../templates/common/header.hbs',
        'footer': '../templates/common/footer.hbs'
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

function regLoginFail(error) {
    if (error) {
        errorEl.innerText = error.message;
    } else {
        errorEl.innerText = 'Your passwords do not match same values!';
    }
    errorEl.style.display = 'block';
    let usernameEl = document.getElementById('username');
    let passwordEl = document.getElementById('password');
    let repeatpassEl = document.getElementById('repeatPassword');
    usernameEl.value = '';
    passwordEl.value = '';
    if (repeatpassEl) {
        repeatpassEl.value = '';
    }
    setTimeout(() => {
        errorEl.style.display = 'none';
    }, 3000);
}

function loadShoesData(context, shoeId) {
    getData(shoeId)
    .then((shoeData) => {   

        setContextData(context, shoeData);

        if (shoeData.data().author === context.username) {
            context.isAuthor = true;
        }                
        loadPartials(context)
            .then(function () {
                this.partial('../templates/offerDetails/details.hbs')
            });
    })
}

function getData(id){
    return db.collection("shoes").doc(id)
    .get()
}

function setContextData(context, sorce){
    context.brand = sorce.data().brand;
    context.model = sorce.data().model;
    context.imageUrl = sorce.data().imageUrl;
    context.description = sorce.data().description;
    context.price = sorce.data().price;
    context.id = sorce.id;
}