import {home} from './controlers/home.js';
import {login, register, logout, registerPost, loginPost} from './controlers/users.js'
import {create, editPost, edit, del} from './controlers/actions.js'
import {detailsPost} from './controlers/details.js'

const app = Sammy('#root', function () {

    this.use('Handlebars', 'hbs');

    //GET
    this.get('#/', home)
    this.get('#/home', home);
    this.get('#/login', login);
    this.get('#/register', register);
    this.get('#/logout', logout);
    this.get('#/edit/:id', edit);
    this.get('#/delete/:id', del);
    this.get('#/details/:id', detailsPost);

    //POST
    this.post('#/register', registerPost);
    this.post('#/login', loginPost);
    this.post('#/create-post', create);
    this.post('#/edit/:id', editPost);
});

app.run('#/home');

