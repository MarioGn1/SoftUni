function attachEvents() {
    let textarea = document.getElementById('messages')
    let authorEl = document.getElementById('author')
    let contentEl = document.getElementById('content')
    let btnSend = document.getElementById('submit')
    let btnRefresh = document.getElementById('refresh')

    const url = 'https://rest-messanger.firebaseio.com/messanger.json';

    btnSend.addEventListener('click', sendMsg);
    btnRefresh.addEventListener('click', refreshText);

    function sendMsg(e) {
        let obj = {
            author: authorEl.value,
            content: contentEl.value
        }
        fetch(url, {
            method: 'POST',
            body: JSON.stringify(obj)
        })
        .then(res => console.log(res.statusText))
        authorEl.value = '';
        contentEl.value = '';
    }

    function refreshText(e) {
        textarea.innerText = '';        
        fetch(url)
        .then(res => res.json())
        .then(data => {            
            Object.values(data).forEach(post => {
                textarea.append(`${post.author}: ${post.content}\n`);
            })
            textarea.scrollTop = textarea.scrollHeight;            
        })
                 
    }
}

attachEvents();