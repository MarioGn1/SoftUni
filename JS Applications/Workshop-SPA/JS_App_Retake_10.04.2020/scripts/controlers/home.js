import { checkForLoggedUser, db } from '../utils.js';

export function home(context) {
    checkForLoggedUser(context);

    let blogPosts = [];
    db.collection('blogPosts').get().then(data => {
        data.forEach(post => {
            blogPosts.push({
                title: post.data().title,
                category: post.data().category,
                content: post.data().content,
                isAuthor: post.data().author === context.username ? true : false,
                id: post.id,
            })
        })

        this.loadPartials({
            'post': '../templates/partials/post.hbs',
            'header': '../templates/partials/header.hbs',
            'footer': '../templates/partials/footer.hbs'
        })
            .then(function () {
                this.partial('../templates/home.hbs', { blogPosts });
            })
    });
}