class Article{
    #comments;
    #likes;
    constructor(title, creator){
        this.title = title;
        this.creator = creator;
        this.#comments = [];
        this.#likes = [];        
    }
    get likes(){
        if (this.#likes.length === 0) {
            return `${this.title} has 0 likes`;
        }
        let firstToLike = this.#likes[0];
        if (this.#likes.length === 1) {
            return `${firstToLike} likes this article!`;
        }
        return `${firstToLike} and ${this.#likes.length - 1} others like this article!`
    }

    like(username){
        let curUser = this.#likes.find(user => user === username)
        if (curUser) {
            throw new Error("You can't like the same article twice!");
        }
        if (!curUser && username === this.creator) {
            throw new Error("You can't like your own articles!");
        }
        this.#likes.push(username);
        return `${username} liked ${this.title}!`;
    }
    dislike(username){
        let curUser = this.#likes.find(user => user === username)
        if (!curUser) {
            throw new Error("You can't dislike this article!");
        }
        let index = this.#likes.indexOf(username);
        this.#likes.splice(index,1);
        return `${username} disliked ${this.title}`;
    }
    comment(username, content, id){
        let curComent = this.#comments.find(com => com.id === id);
        if (id === undefined || !curComent) {
            curComent = {
                id: this.#comments.length + 1,
                username,
                content,
                reply: []
            }
            this.#comments.push(curComent);
            return `${username} commented on ${this.title}`
        }
        if (curComent) {
            curComent.reply.push({
                id: curComent.id +'.'+ (curComent.reply.length + 1),
                username,
                content
            });
            return "You replied successfully"
        }
    }
    toString(sortingType){
        switch (sortingType) {
            case 'asc':
                this.#comments.sort(this.sortByIdAsc).forEach(com => com.reply.sort(this.sortByIdAsc));
                break;
            case 'desc':
                this.#comments.sort(this.sortByIdDesc).forEach(com => com.reply.sort(this.sortByIdDesc));
                break;
            case 'username':
                this.#comments.sort(this.sortByNameAsc).forEach(com => com.reply.sort(this.sortByNameAsc));
                break;
        
            default:
                break;
        }
        let result = [`Title: ${this.title}`, `Creator: ${this.creator}`, `Likes: ${this.#likes.length}`, 'Comments:'];
        this.#comments.forEach(com => {
            result.push(`-- ${com.id}. ${com.username}: ${com.content}`);
            com.reply.forEach(repl => {
                result.push(`--- ${repl.id}. ${repl.username}: ${repl.content}`);
            })
        })
        return result.join('\n');
    }

    sortByIdAsc(a,b){
        return Number(a.id) - Number(b.id);
    }
    sortByIdDesc(a,b){
        return Number(b.id) - Number(a.id);
    }
    sortByNameAsc(a,b){
        return a.username.localeCompare(b.username);
    }
}

let art = new Article("My Article", "Anny");
art.like("John");
console.log(art.likes);
art.dislike("John");
console.log(art.likes);
art.comment("Sammy", "Some Content");
console.log(art.comment("Ammy", "New Content"));
art.comment("Zane", "Reply", 1);
art.comment("Jessy", "Nice :)");
console.log(art.comment("SAmmy", "Reply@", 1));
console.log()
console.log(art.toString('username'));
console.log()
art.like("Zane");
console.log(art.toString('desc'));
