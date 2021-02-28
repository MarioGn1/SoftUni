function solve(obj) {
    let method = obj.method;
    if (method !== 'GET' && method !== 'POST' && method !== 'DELETE' && method !== 'CONNECT') {
        throw new Error(`Invalid request header: Invalid Method`);
    }

    let uri = obj.uri;
    let paternUri = new RegExp(/^([A-Za-z0-9.]+)$|\*/);    
    if (!paternUri.test(uri)) {
        throw new Error(`Invalid request header: Invalid URI`);
    }

    let version = obj.version;
    if (version !== 'HTTP/0.9' &&  version !== 'HTTP/1.0' && version !== 'HTTP/1.1' && version !== 'HTTP/2.0' ) {
        throw new Error(`Invalid request header: Invalid Version`);
    }

    let message = obj.message;
    paternMessage = new RegExp (/^([^<>\\&'"]+)$/);
    if (!paternMessage.test(message) && message !== '') {
        throw new Error(`Invalid request header: Invalid Message`);
    }   

    return obj;
}

solve({
    method: 'POST',
    uri: '*',
    version: 'HTTP/1.1',
    message: ''
})