import { checkForLoggedUser, successfullOperation, errorCatch, db, getData, setContextData, loadPartials } from '../utils.js';

export async function create(context) {
    checkForLoggedUser(context);
    await loadPartials(context)
    this.partial('../templates/create.hbs');
};

export function createPost(context) {
    checkForLoggedUser(context);
    let { destination, city, duration, departureDate, imgUrl } = context.params;

    try {
        if (!destination || !city || !duration || !departureDate || !imgUrl) {
            throw new Error('Fields can not be empty!')
        }
        if (Number(duration) < 1 || Number(duration) > 100) {
            throw new Error('Duration must be between 1 and 100 days!')
        }
        db.collection("destinations").add({
            destination,
            city,
            duration,
            departureDate,
            imgUrl,
            author: context.username
        })
        successfullOperation(`You successfully create destination card ${destination}`)
        context.redirect('#/home')
    } catch (error) {
        errorCatch(error);
    }
};

export async function edit(context) {
    let contentId = this.params.id;
    checkForLoggedUser(context);
    const data = await getData(contentId)
    setContextData(context, data)
    await loadPartials(context)
    this.partial('../templates/edit.hbs')
};

export function editPost(context) {
    let id = this.params.id;
    checkForLoggedUser(context);
    let { destination, city, duration, departureDate, imgUrl } = context.params;
    
    db.collection("destinations").doc(id).update({
        destination,
        city,
        duration,
        departureDate,
        imgUrl,
    })    
    successfullOperation(`You successfully edit destination card ${destination}`)
    context.redirect(`#/details/${id}`)
};

export function del(context) {
    let id = this.params.id;
    try {
        db.collection('destinations').doc(id).delete()
        successfullOperation("Destination deleted.")
    } catch (error) {
        regLoginFail(error);
    }
    context.redirect('#/myDestinations');
}