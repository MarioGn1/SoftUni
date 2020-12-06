import {home} from './controlers/home.js';
import {login, register, logout, registerPost, loginPost} from './controlers/users.js'
import {create, createPost, comment, like, del} from './controlers/actions.js'
import {detailsPost, catalog, user} from './controlers/details.js'

const app = Sammy('#main', function () {

    this.use('Handlebars', 'hbs');

    //GET
    this.get('#/', home)
    this.get('#/home', home);
    this.get('#/login', login);
    this.get('#/register', register);
    this.get('#/logout', logout);
    this.get('#/catalog', catalog);
    this.get('#/user', user);
    this.get('#/create', create);
    this.get('#/like/:id', like);
    this.get('#/delete/:id', del);
    this.get('#/details/:id', detailsPost);

    //POST
    this.post('#/register', registerPost);
    this.post('#/login', loginPost);
    this.post('#/create', createPost);
    this.get('#/comment/:id', comment);
});

app.run('#/');

