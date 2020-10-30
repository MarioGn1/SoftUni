function solve() {
   let creatorEl = document.getElementById('creator');
   let titleEl = document.getElementById('title');
   let categoryEl = document.getElementById('category');
   let contentEl = document.getElementById('content');

   let createBtnEl = document.getElementsByClassName('btn create')[0];
   let siteContenEl = document.getElementsByClassName('site-content')[0];
   let mainArticleEl = siteContenEl.getElementsByTagName('section')[0];
   let archiveArticleEl = siteContenEl.getElementsByTagName('section')[2];
   let liElements = [];

   createBtnEl.addEventListener('click', addNewArticle)
   mainArticleEl.addEventListener('click', articleOperations)

   function addNewArticle(e) {
      let articleEl = document.createElement('article');
      let h1El = document.createElement('h1');
      h1El.innerText = titleEl.value;
      articleEl.appendChild(h1El);

      let pCategoryEl = document.createElement('p');
      let textCatNodeEl = document.createTextNode('Category: ');
      pCategoryEl.appendChild(textCatNodeEl);
      let textStrongEl = document.createElement('strong');
      textStrongEl.innerText = categoryEl.value;
      pCategoryEl.appendChild(textStrongEl);
      articleEl.appendChild(pCategoryEl);

      let pCreatorEl = document.createElement('p');
      let textCreatorNodeEl = document.createTextNode('Creator: ');
      pCreatorEl.appendChild(textCreatorNodeEl);
      let textStrongEl2 = document.createElement('strong');
      textStrongEl2.innerText = creatorEl.value;
      pCreatorEl.appendChild(textStrongEl2);
      articleEl.appendChild(pCreatorEl);

      let pContentEl = document.createElement('p');
      pContentEl.innerText = contentEl.innerText;
      articleEl.appendChild(pContentEl)

      let divBtnsEl = document.createElement('div');
      divBtnsEl.classList.add('buttons');
      let btnDelete = document.createElement('button');
      btnDelete.classList.add("btn");
      btnDelete.classList.add("delete");
      btnDelete.innerText = 'Delete';
      divBtnsEl.appendChild(btnDelete);
      let btnArchive = document.createElement('button');
      btnArchive.classList.add("btn");
      btnArchive.classList.add("archive");
      btnArchive.innerText = 'Archive';
      divBtnsEl.appendChild(btnArchive);
      articleEl.appendChild(divBtnsEl);

      mainArticleEl.appendChild(articleEl);

      e.preventDefault();
   }

   function articleOperations(e) {
      if (e.target.tagName = 'BUTTON') {
         if (e.target.innerText === 'Archive') {            
            let articleEl = e.target.parentElement.parentElement
            let titleEl = articleEl.firstChild;
            let ulArchiveEl = archiveArticleEl.getElementsByTagName('ul')[0];
            let liArchiveEl = document.createElement('li');
            liArchiveEl.innerText = titleEl.innerText;
            liElements.push(liArchiveEl);            
            liElements.sort((a,b) => {return a.textContent.localeCompare(b.textContent)});
            ulArchiveEl.innerHTML = '';
            for (let i = 0; i < liElements.length; i++) {
               ulArchiveEl.appendChild(liElements[i]);               
            }            
         }
         mainArticleEl.removeChild(e.target.parentElement.parentElement);
      }
   }
}
