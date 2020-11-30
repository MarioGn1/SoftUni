import { checkForLoggedUser, loadContentData } from '../utils.js';

export function detailsPost(context) {
    let contentId = this.params.id;
    checkForLoggedUser(context);
    context.isAuthor = false;

    loadContentData(context, contentId);
}