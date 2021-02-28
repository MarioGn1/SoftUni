import { checkForLoggedUser, db, loadPartials } from '../utils.js';

export async function home(context) {
    checkForLoggedUser(context);

    let blogPosts = [];
    let data = await db.collection('blogPosts').get()
    data.forEach(post => {
        blogPosts.push({
            title: post.data().title,
            category: post.data().category,
            content: post.data().content,
            isAuthor: post.data().author === context.username ? true : false,
            id: post.id,
        })
    })

    await loadPartials(context)
    const partialPost = await context.load('../templates/partials/post.hbs');
    context.partials.post = partialPost;
    this.partial('../templates/home.hbs', { blogPosts });
}