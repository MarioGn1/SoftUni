import { checkForLoggedUser, successfullOperation, errorCatch, db, getData, setContextData, loadPartials } from '../utils.js';

export async function create(context) {    
    checkForLoggedUser(context);
    await loadPartials(context)
    this.partial('../templates/create.hbs')
};

export function createPost(context) {
    checkForLoggedUser(context);
    let { title, description, imageURL } = context.params;

    try {
        if (!title || !description || !imageURL) {
            throw new Error('Fields can not be empty strings!')
        }        
        db.collection("ideas").add({
            title,
            description,
            imageURL,
            author: context.username,
            likes: 0,
            likers: [],
            comments: []
        })
        successfullOperation(`You successfully create movie card ${title}`)
        context.redirect('#/catalog')
    } catch (error) {
        errorCatch(error);
    }
};

export async function comment(context) {
    let id = this.params.id;
    checkForLoggedUser(context);
    let { newComment } = context.params;
    let response = await getData(id);
    let comments = response.data().comments;
    comments.push({name: context.username, coment: newComment});

    db.collection("ideas").doc(id).update({
        comments
    })
    .then(() => context.redirect(`#/details/${id}`) )
    
};
export async function like(context) {
    let id = this.params.id;
    checkForLoggedUser(context);
    let response = await getData(id);
    let likers = response.data().likers;
    let likes = likers.length;
    likers.push(context.username);
    likes += 1;

    await db.collection("ideas").doc(id).update({
        likes,
        likers
    })
    context.redirect(`#/details/${id}`) 
    
};

export function del(context) {
    let id = this.params.id;
    try {
        db.collection('ideas').doc(id).delete()
        .then(() => context.redirect('#/catalog'))
    } catch (error) {
        regLoginFail(error);
    }
    
}