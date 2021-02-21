class Story {
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this._comments = [];
        this._likes = [];
    }

    get likes() {
        if (this._likes.length === 0) {
            return `${this.title} has 0 likes`
        } else if (this._likes.length === 1) {
            return `${this._likes[0]} likes this story!`
        } else {
            return `${this._likes[0]} and ${this._likes.length - 1} others like this story!`
        }
    }

    like(user) {
        if (this._likes.some(u => u === user)) {
            throw new Error("You can't like the same story twice!");
        } else if (user === this.creator) {
            throw new Error("You can't like your own story!");
        } else {
            this._likes.push(user);
            return `${user} liked ${this.title}!`;
        }
    }

    dislike(user) {
        if (this._likes.some(u => u === user) === false) {
            throw new Error("You can't dislike this story!");
        } else {
            this._likes.splice(this._likes.indexOf(user), 1);
            return `${user} disliked ${this.title}`;
        }
    }

    comment(user, content, id) {
        if (typeof id == 'undefined' || this._comments.some(comment => comment.id === id) === false) {
            this._comments.push({ id: this._comments.length + 1, user, content, replies: [] });
            return `${user} commented on ${this.title}`;
        } else {
            const [comment] = this._comments.filter(com => com.id === id);
            comment.replies.push({ id: comment.id + (comment.replies.length + 1) * .1, user, content });
            return "You replied successfully";
        }
    }

    toString(sortType) {
        const output = [`Title: ${this.title}\nCreator: ${this.creator}\nLikes: ${this._likes.length}\nComments:`]
        switch (sortType) {
            case 'asc':
                this._comments.sort((a, b) => a.id - b.id).forEach(c => {
                    output.push(`-- ${c.id}. ${c.user}: ${c.content}`);
                    c.replies.sort((a,b) => a.id - b.id).forEach(r => output.push(`--- ${r.id}. ${r.user}: ${r.content}`));
                });
                break;
            case 'desc':
                this._comments.sort((a, b) => b.id - a.id).forEach(c => {
                    output.push(`-- ${c.id}. ${c.user}: ${c.content}`);
                    c.replies.sort((a,b) => b.id - a.id).forEach(r => output.push(`--- ${r.id}. ${r.user}: ${r.content}`));
                });
                break;
            case 'username':
                this._comments.sort((a, b) => a.user.localeCompare(b.user)).forEach(c => {
                    output.push(`-- ${c.id}. ${c.user}: ${c.content}`);
                    c.replies.sort((a,b) => a.user.localeCompare(b.user)).forEach(r => output.push(`--- ${r.id}. ${r.user}: ${r.content}`));
                });
                break;
        }
        return output.join('\n')
    }
}

let art = new Story("My Story", "Anny");
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