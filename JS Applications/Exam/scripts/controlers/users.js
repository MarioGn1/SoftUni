import { checkForLoggedUser, loadPartials, successfullOperation, auth, regLoginFail } from '../utils.js';

export async function login(context) {
    checkForLoggedUser(context);
    await loadPartials(context);
    this.partial('../templates/login.hbs');
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
            context.redirect('#/login');
            successfullOperation('You successfully signed out!');
        })
        .catch(e => console.log(e.message))
}

export function registerPost(context) {

    const { email, password, rePassword } = context.params;
    if (password !== rePassword) {
        regLoginFail();
    } else {
        auth.createUserWithEmailAndPassword(email, password)
            .then((res) => {
                console.log(res);
                successfullOperation('You succesfully create account!');
                
                // context.redirect('#/home');
            })
            .then(function (){loginPost(context)})
            .catch(error => {
                regLoginFail(error);
            });
    }
}

export function loginPost(context) {

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
}