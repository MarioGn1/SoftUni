function authentication(){
    let auth = firebase.auth();

    let loginButton = document.getElementById('loginBtn');
    let registerButton = document.getElementById('registerBtn');
    let usernameEl = document.getElementById('username');
    let passwordEl = document.getElementById('password');
    let divLoginEl = document.getElementsByClassName('login-details')[0];
    let divDataEl = document.getElementById('login-data');
    let contentEl = document.getElementsByClassName('content')[0];
    
    loginButton.addEventListener('click', login);
    registerButton.addEventListener('click', register);

    function login(e) {
        checkForMsgs();  
        let name = usernameEl.value.split('@')[0].toUpperCase();   
        
        auth.signInWithEmailAndPassword(usernameEl.value, passwordEl.value)        
        .then(res => goToContent(name))
        .catch(() => {      
            createMSG('You enter a wrong username or password! Please try again or register new account!', 'failed-login');                 
        }) 
        usernameEl.value = '';
        passwordEl.value = '';       
    }

    function register(e) {
        checkForMsgs();

        auth.createUserWithEmailAndPassword(usernameEl.value, passwordEl.value)
        .then(() => {
            createMSG("Successfuly created account! You can login now.", 'success-register');                        
        })
        .catch(res =>{
            createMSG(res.message, 'failed-login');         
        })
        usernameEl.value = '';
        passwordEl.value = ''; 
    }

    function checkForMsgs(){
        let errorEl = document.getElementsByClassName('failed-login')[0];
        let successMsg = document.getElementsByClassName('success-register')[0];
        if (errorEl) {
            divDataEl.removeChild(errorEl);
        }
        if (successMsg) {
            divDataEl.removeChild(successMsg);
        }
    };

    function createMSG(text, elClass) {
        let messageEl = document.createElement('p');
            messageEl.innerText = text;
            messageEl.classList.add(elClass)
            divDataEl.appendChild(messageEl);
    }

    function goToContent(name) {        
        let content = document.getElementsByClassName('content')[0]
        let greetingsEl = document.createElement('span');
        greetingsEl.classList.add('greetings');
        greetingsEl.innerText = `${name} welcome to remote databases exercise! Please check the contents bellow!`
        content.prepend(greetingsEl);
        divLoginEl.style.display = 'none';
        contentEl.style.display = 'block';        
    }
}

authentication();