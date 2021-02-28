import { checkForLoggedUser, loadPartials, successfullOperation, auth, regLoginFail } from '../utils.js';

export async function login(context) {
    checkForLoggedUser(context);
    await loadPartials(context);

    this.partial('../templates/login.hbs')

}

export async function register(context) {
    checkForLoggedUser(context);
    await loadPartials(context);
    this.partial('../templates/register.hbs')

}

export function logout(context) {

    auth.signOut()
        .then(() => {
            localStorage.removeItem('userInfo');
            context.redirect('#/home');
            successfullOperation('You successfully signed out!');
        })
        .catch(e => console.log(e.message))
}

export function registerPost(context) {

    const { username, password, repeatPassword } = context.params;    
    if (password !== repeatPassword) {
        regLoginFail();
    } else {

        auth.createUserWithEmailAndPassword(username, password)
            .then((res) => {
              
                successfullOperation('You succesfully create account!');

                context.redirect('#/login');
            })
            .catch(error => {
                regLoginFail(error);
            });
    }
}

export function loginPost(context) {

    let { username, password } = context.params;
    auth.signInWithEmailAndPassword(username, password)
        .then(resp => {
            successfullOperation('You succesfully signed in!');
            let userCredentils = {
                username: resp.user.email,
                uId: resp.user.uid
            }
            localStorage.setItem('userInfo', JSON.stringify(userCredentils));
            context.redirect('#/catalog');
        })
        .catch(error => regLoginFail(error))
}