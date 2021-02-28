import { checkForLoggedUser, loadContentData, loadPartials, db, sortByLikes} from '../utils.js';

export function detailsPost(context) {
    let contentId = this.params.id;
    checkForLoggedUser(context);
    context.isAuthor = false;

    loadContentData(context, contentId);
}
export async function catalog(context) {

    checkForLoggedUser(context);

    let ideas = [];
    let data = await db.collection('ideas').get()
    data.forEach(idea => {
        ideas.push({
            title: idea.data().title,
            imageURL: idea.data().imageURL,
            likes: idea.data().likes,
            id: idea.id,
        })
    });    
    ideas = ideas.sort(sortByLikes);

    await loadPartials(context)
    const partialPost = await context.load('../templates/partials/idea.hbs')
    context.partials.idea = partialPost;

    this.partial('../templates/catalog.hbs', { ideas });
}

export async function user(context) {
    checkForLoggedUser(context);

    let ideas = [];
    const response = await db.collection('ideas').get()
    response.forEach(idea => {
        if (context.username === idea.data().author) {
            ideas.push({title: idea.data().title})
        }
    });

    context.ownIdeas = ideas.length;


    await loadPartials(context)
    const partialPost = await context.load('../templates/partials/ownIdea.hbs')
    context.partials.ownIdea = partialPost;

    this.partial('../templates/user.hbs', {ideas});
}