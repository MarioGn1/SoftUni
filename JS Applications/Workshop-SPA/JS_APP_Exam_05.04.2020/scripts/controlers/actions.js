import { checkForLoggedUser, successfullOperation, errorCatch, db, getData, setContextData, loadPartials } from '../utils.js';

export async function create(context) {    
    checkForLoggedUser(context);
    await loadPartials(context)
    this.partial('../templates/create.hbs')
};

export function createPost(context) {
    checkForLoggedUser(context);
    let { title, category, content } = context.params;

    try {
        if (!title || !category || !content) {
            throw new Error('Fields can not be empty strings!')
        }
        category = category.toLowerCase();
        if(category !== 'javascript' && category !== 'csharp' && category !== 'java' && category !== 'pyton'){
            throw new Error('Incorect category!')
        }
        db.collection("SoftWiki_Articles").add({
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
    let { title, category, content } = context.params;

    db.collection("SoftWiki_Articles").doc(id).update({
        title,
        category,
        content,
    })
    .then(() => context.redirect(`#/home`) )
    
};

export function del(context) {
    let id = this.params.id;
    try {
        db.collection('SoftWiki_Articles').doc(id).delete()
    } catch (error) {
        regLoginFail(error);
    }
    context.redirect('#/home');
}