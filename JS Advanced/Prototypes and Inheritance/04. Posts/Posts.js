function solve() {
    class Post{
        constructor(title, content){
            this.title = title;
            this.content = content;
        }
        toString(){
            return `Post: ${this.title}\nContent: ${this.content}`
        }
    }

    class SocialMediaPost extends Post{
        constructor(title, content, likes, dislikes){
            super(title,content);
            this.likes = likes;
            this.dislikes = dislikes;
            this.comments = [];
        }
        addComment(comment){ this.comments.push(comment)}
        toString(){
            let result = super.toString() + `\nRating: ${this.likes - this.dislikes}`;
            if (this.comments.length > 0) {
                result+= '\nComments:'
                this.comments.forEach(el => result += `\n * ${el}`)
            }            
            return result
        }
    }

    class BlogPost extends Post{
        constructor(title, content, views){
            super(title,content);
            this.views = views;
        }
        view(){ 
            this.views++;
            return this;
        }
        toString(){
            return super.toString() + `\nViews: ${this.views}`;
        }
    }
    return {Post, SocialMediaPost, BlogPost}
}

let classes = solve();

let test = new classes.SocialMediaPost("TestTitle", "TestContent", 5, 10);

// let soc = new classes.SocialMediaPost('Test', 'asdasdasd', 10, 5);
// // soc.addComment('Iskam Piza')
// // soc.addComment('Iskam Mnogo Piza')
// // soc.addComment('Iskam Mnogo Mnogo Piza')
// console.log(soc.toString())

test.addComment("1");
test.addComment("2");
test.addComment("3");
 console.log(test.toString())

// expect(test.toString()).to.be.equal(
//             "Post: TestTitle\n" +
//             "Content: TestContent\n" +
//             "Rating: -5\n" +
//             "Comments:\n" +
//             " * 1\n" +
//             " * 2\n" +
//             " * 3",
//             "'SocialMediaPost toString()' function does not return correct results");
