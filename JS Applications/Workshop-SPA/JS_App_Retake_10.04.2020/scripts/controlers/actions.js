import { checkForLoggedUser, successfullOperation, errorCatch, db, getData, setContextData, loadPartials } from '../utils.js';

export function create(context) {
    checkForLoggedUser(context);
    let { title, category, content } = context.params;

    try {
        if (!title || !category || !content) {
            throw new Error('Fields can not be empty strings!')
        }
        db.collection("blogPosts").add({
            title,
            category,
            content,
            author: context.username
        })
        successfullOperation(`You successfully create movie card ${title}`)
        context.redirect('#/home')
    } catch (error) {
        errorCatch(error);
    }
};

export function edit(context) {
    let contentId = this.params.id;
    checkForLoggedUser(context);
    getData(contentId)
        .then(data => {
            setContextData(context, data)
            loadPartials(context)
                .then(function () {
                    this.partial('../templates/edit.hbs')
                });
        })
};

export function editPost(context) {
    let id = this.params.id;
    checkForLoggedUser(context);
    let { title, category, content } = context.params;

    db.collection("blogPosts").doc(id).update({
        title,
        category,
        content,
    })
    context.redirect(`#/home`)
};

export function del(context){
    let id = this.params.id;

    db.collection('blogPosts')
    .doc(id)
    .delete()
    .then(() => context.redirect('#/home'))
    .catch(error => regLoginFail(error));        
}