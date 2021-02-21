function solve() {
    const btnCreate = Array.from(document.getElementsByClassName('btn create'))[0];
    const inpCreator = document.getElementById('creator');
    const inpTitle = document.getElementById('title');
    const inpCat = document.getElementById('category');
    const inpCont = document.getElementById('content');
    const archive = document.querySelector('section.archive-section>ol');
    const posts = document.querySelector('div.site-content>main>section')

    btnCreate.addEventListener('click', (ev) => {
        ev.preventDefault();

        const article = newElement('article');
        article.appendChild(newElement('h1', inpTitle.value));
        const catP = newElement('p', 'Category:');
        catP.appendChild(newElement('strong', inpCat.value));
        article.appendChild(catP);
        const creatorP = newElement('p', 'Creator:');
        creatorP.appendChild(newElement('strong', inpCreator.value));
        article.appendChild(creatorP);
        article.appendChild(newElement('p', inpCont.value));
        const div = newElement('div', '', 'buttons');
        div.appendChild(newElement('button', 'Delete', 'btn delete'));
        div.appendChild(newElement('button', 'Archive', 'btn archive'));
        article.appendChild(div);

        posts.appendChild(article)
        // console.log(posts);
    })

    posts.addEventListener('click', (ev) => {
        if (ev.target.tagName === 'BUTTON') {
            if (ev.target.classList.contains('delete')) {
                ev.target.parentNode.parentNode.remove();
            } else {
                const li = newElement('li', ev.target.parentNode.parentNode.firstChild.textContent);
                let inserted = false;
                for (let child of Array.from(archive.children)) {
                    if (child.textContent.localeCompare(li.textContent) === 1) {
                        archive.insertBefore(li, child);
                        inserted = true;
                        break;
                    }
                }

                if (!inserted)
                    archive.appendChild(li);

                ev.target.parentNode.parentNode.remove();
            }
        }
    })

    function newElement(type, txt, cls) {
        const el = document.createElement(type);
        if (txt || txt !== '') {
            el.textContent = txt;
        }
        if (cls) {
            cls = cls.split(' ');
            el.classList.add(...cls);
        }
        return el;
    }
}
