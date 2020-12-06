import { checkForLoggedUser, db, loadPartials } from '../utils.js';

export async function home(context) {
    checkForLoggedUser(context);

    await loadPartials(context)
    
    this.partial('../templates/home.hbs');
}