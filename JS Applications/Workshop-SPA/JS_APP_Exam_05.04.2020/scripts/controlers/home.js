import { checkForLoggedUser, db, loadPartials } from '../utils.js';

export async function home(context) {
    checkForLoggedUser(context);

    let jsArticles = [];
    let cSharpArticles = [];
    let javaArticles = [];
    let pytonArticles = [];
    let data = await db.collection('SoftWiki_Articles').get()
    data.forEach(article => {
        let category = article.data().category.toLowerCase();
        switch (category) {
            case 'javascript':
                jsArticles.push({
                    title: article.data().title,                    
                    content: article.data().content,
                    id: article.id,
                })
                break;
            case 'csharp':
                cSharpArticles.push({
                    title: article.data().title,                    
                    content: article.data().content,
                    id: article.id,
                })
                break;
            case 'java':
                javaArticles.push({
                    title: article.data().title,                    
                    content: article.data().content,
                    id: article.id,
                })
                break;
            case 'pyton':
                pytonArticles.push({
                    title: article.data().title,                    
                    content: article.data().content,
                    id: article.id,
                })
                break;
        
            default:
                break;
        }

    })

    await loadPartials(context)
    const partialPost = await Promise.all([
        context.load('../templates/partials/article.hbs'),
        context.load('../templates/partials/noArticles.hbs')
    ]);
    context.partials.article = partialPost[0];
    context.partials.noArticles = partialPost[1];
    this.partial('../templates/home.hbs', { jsArticles, cSharpArticles, javaArticles, pytonArticles }); //
}