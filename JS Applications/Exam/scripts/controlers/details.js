import { checkForLoggedUser, loadContentData, loadPartials, db } from '../utils.js';

export function detailsPost(context) {
    let contentId = this.params.id;
    checkForLoggedUser(context);
    context.isAuthor = false;

    loadContentData(context, contentId);
}

export async function myDestinations(context) {
    checkForLoggedUser(context);

    let ownDestinations = [];
    let data = await db.collection('destinations').get()
    data.forEach(post => {
        if (post.data().author === context.username) {
            ownDestinations.push({
                destination: post.data().destination,
                city: post.data().city,
                departureDate: post.data().departureDate,
                imgUrl: post.data().imgUrl,            
                id: post.id,
            })
        }
    })

    await loadPartials(context)
    const partialPost = await context.load('../templates/partials/ownDestination.hbs');
    context.partials.ownDestination = partialPost;
    this.partial('../templates/catalog.hbs', {ownDestinations});
}