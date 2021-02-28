const auth = firebase.auth();
const db = firebase.firestore();
let infoEl = document.getElementById('infoBox');
let errorEl = document.getElementById('errorBox');

const app = Sammy('#main', function () {

    this.use('Handlebars', 'hbs')

    //GET
    this.get('#/home', function (context) {

        checkForLoggedUser(context)

        context.hasTeam = false;
        db.collection("teams").get().then(teamsData => {
            teamsData.forEach(team => {
                if (team.data().members.find(member => member.username === context.username)) {
                    context.hasTeam = true;
                    context.teamId = team.id;
                }
            });
            this.loadPartials({
                'header': '../templates/common/header.hbs',
                'footer': '../templates/common/footer.hbs'
            }).then(function () {
                this.partial('../templates/home/home.hbs');
            });
        });


    })
    this.get('#/about', function (context) {

        checkForLoggedUser(context)

        this.loadPartials({
            'header': '../templates/common/header.hbs',
            'footer': '../templates/common/footer.hbs'
        }).then(function () {
            this.partial('../templates/about/about.hbs');
        })
    })
    this.get('#/login', function () {
        this.loadPartials({
            'header': '../templates/common/header.hbs',
            'footer': '../templates/common/footer.hbs',
            'loginForm': '../templates/login/loginForm.hbs',
        }).then(function () {
            this.partial('../templates/login/loginPage.hbs');
        })
    })
    this.get('#/register', function () {
        this.loadPartials({
            'header': '../templates/common/header.hbs',
            'footer': '../templates/common/footer.hbs',
            'registerForm': '../templates/register/registerForm.hbs',
        }).then(function () {
            this.partial('../templates/register/registerPage.hbs');
        })
    })
    this.get('#/catalog', function (context) {

        let username = checkForLoggedUser(context)
        let teams = []
        context.hasNoTeam = true;
        db.collection("teams").get().then((teamsData) => {
            teamsData.forEach(team => {
                teams.push(Object.assign(team.data(), { _id: team.id }));
                if (team.data().members.find(member => member.username === username)) {
                    context.hasNoTeam = false;
                }
            })
            this.loadPartials({
                'header': '../templates/common/header.hbs',
                'footer': '../templates/common/footer.hbs',
                'team': '../templates/catalog/team.hbs'
            }).then(function () {
                this.partial('../templates/catalog/teamCatalog.hbs', { teams })
            });
        })
    })
    this.get('#/create', function (context) {
        checkForLoggedUser(context);
        this.loadPartials({
            'header': '../templates/common/header.hbs',
            'footer': '../templates/common/footer.hbs',
            'createForm': '../templates/create/createForm.hbs'
        }).then(function () {
            this.partial('../templates/create/createPage.hbs')
        });

    })
    this.get('#/edit/:teamId', function (context) {
        checkForLoggedUser(context);
        let teamId = this.params.teamId.split(':')[1];

        db.collection("teams").doc(teamId)
            .get()
            .then((teamData) => {
                context.name = teamData.data().name;
                context.comment = teamData.data().comment;
                context.teamId = teamData.id;
                this.loadPartials({
                    'header': '../templates/common/header.hbs',
                    'footer': '../templates/common/footer.hbs',
                    'editForm': '../templates/edit/editForm.hbs'
                }).then(function () {
                    this.partial('../templates/edit/editPage.hbs')
                });
            });
    })
    this.get('#/catalog/:id', function (context) {
        let teamId = this.params.id.split(':')[1];
        checkForLoggedUser(context);
        context.isAuthor = false;
        context.isOnTeam = false;

        db.collection("teams").doc(teamId)
            .get()
            .then((teamData) => {
                let members = teamData.data().members;
                context.comment = teamData.data().comment;
                context.teamId = teamData.id;
                if (teamData.data().author === context.username) {
                    context.isAuthor = true;
                    context.isOnTeam = true;
                }
                if (members.find(member => member.username === context.username)) {
                    context.isOnTeam = true;
                }else{
                    
                }
                this.loadPartials({
                    'header': '../templates/common/header.hbs',
                    'footer': '../templates/common/footer.hbs',
                    'teamMember': '../templates/catalog/teamMember.hbs',
                    'teamControls': '../templates/catalog/teamControls.hbs',
                }).then(function () {
                    this.partial('../templates/catalog/details.hbs', { members })
                });
            })
    })
    this.get('#/logout', function (context) {

        auth.signOut()
            .then(() => {
                localStorage.removeItem('userInfo');
                context.redirect('#/home');
                successfullOperation('You successfully signed out!');
            })
            .catch(e => console.log(e.message))
    })
    this.get('#/leave', function (context) {
        checkForLoggedUser(context);

        db.collection("teams").get().then(teamsData => {
            teamsData.forEach(team => {
                let member = team.data().members.find(member => member.username === context.username)
                if (member) {
                    let teamMembers = [];
                    teamMembers = team.data().members
                    let index = teamMembers.indexOf(member);
                    teamMembers.splice(index, 1);
                    db.collection('teams').doc(team.id).update({
                        members: teamMembers
                    })
                    successfullOperation(`You successfully leave team ${team.data().name}`)                    
                    return
                }
            });
        }).catch(error => joinTeamRestrictMessage(error));

        context.redirect('#/catalog');
    })
    this.get('#/join/:teamId', function (context) {

        let teamId = this.params.teamId.split(':')[1];
        let hasTeam = false;
        checkForLoggedUser(context);

        db.collection("teams")
        .get()
        .then(teamsData => {
            teamsData.forEach(team => {
                if (team.data().members.find(member => member.username === context.username)) {
                    context.teamId = team.id;
                    hasTeam = true
                    throw new Error('You are already member of a team!')
                } 
            });
            teamsData.forEach( team => {
                if (!hasTeam) {
                    let teamMembers = [];
                    teamMembers = team.data().members
                    teamMembers.push({ username: context.username })
                    db.collection('teams').doc(teamId).update({
                        members: teamMembers
                    })
                    successfullOperation(`You successfully join the team ${team.data().name}!`)
                    context.redirect(`#/catalog/:${teamId}`)
                    return
                }
            });
        })        
        .catch(error => joinTeamRestrictMessage(error));
       
    })

    //POST
    this.post('#/register', function (context) {

        const { username, password, repeatPassword } = context.params;

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
        let curUser = checkForLoggedUser(context);
        let nameEl = document.getElementById('name');
        let comentEl = document.getElementById('comment');
        db.collection("teams").add({
            name: nameEl.value,
            comment: comentEl.value,
            members: [{ username: curUser }],
            author: curUser
        })
        context.redirect('#/catalog')
    })
    this.post('#/edit/:teamId', function (context) {
        let teamId = this.params.teamId.split(':')[1];
        checkForLoggedUser(context);
        let nameEl = document.getElementById('name');
        let comentEl = document.getElementById('comment');
        db.collection("teams").doc(teamId).update({
            name: nameEl.value,
            comment: comentEl.value
        })
        context.redirect('#/catalog')
    })


});

(() => {
    app.run('#/home');
})();

function successfullOperation(message) {
    infoEl.innerText = message;
    infoEl.style.display = 'block';
    setTimeout(() => {
        infoEl.style.display = 'none';
    }, 2000);
}

function checkForLoggedUser(context) {
    let userInfo = JSON.parse(localStorage.getItem('userInfo'));
    if (userInfo) {
        context.username = userInfo.username;
        context.loggedIn = true;
        return userInfo.username;
    }

}

function joinTeamRestrictMessage(error) {
    errorEl.innerText = error.message;
    errorEl.style.display = 'block';
    setTimeout(() => {
        errorEl.style.display = 'none';
    }, 3000);
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
