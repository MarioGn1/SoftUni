import { checkForLoggedUser, db, loadPartials } from '../utils.js';

export async function home(context) {
    checkForLoggedUser(context);

    let destinations = [];
    let data = await db.collection('destinations').get()
    data.forEach(post => {
        destinations.push({
            destination: post.data().destination,
            city: post.data().city,
            departureDate: post.data().departureDate,
            imgUrl: post.data().imgUrl,
            isAuthor: post.data().author === context.username ? true : false,
            id: post.id,
        })
    })

    await loadPartials(context)
    const partialPost = await context.load('../templates/partials/destination.hbs');
    context.partials.destination = partialPost;
    this.partial('../templates/home.hbs', { destinations }); //
}