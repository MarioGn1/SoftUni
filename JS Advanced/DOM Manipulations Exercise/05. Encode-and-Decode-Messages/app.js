function encodeAndDecodeMessages() {
    let textSendElement = (document.getElementsByTagName('textarea'))[0];
    let textReceiveElement = (document.getElementsByTagName('textarea'))[1];
    let mainElement = document.getElementById('main');
    

    mainElement.addEventListener('click', function(e){
        if (e.target.tagName === 'BUTTON') {
            if (e.target.innerText === 'Encode and send it') {
                let text = textSendElement.value;  
                let textToTransfer = '';              
                for (let i = 0; i < text.length; i++) {                    
                    textToTransfer += String.fromCharCode(text.charCodeAt(i)+1);                   
                }
                textReceiveElement.value = textToTransfer;
                textSendElement.value = '';                
                
            }
            if (e.target.innerText === 'Decode and read it') {
                let text = textReceiveElement.value;
                let textToTransfer = ''; 
                for (let i = 0; i < text.length; i++) {
                    textToTransfer += String.fromCharCode(text.charCodeAt(i)-1);                    
                } 
                textReceiveElement.value = textToTransfer;               
                
            }
        }
    })
}