
function result() {
    let myObj = {
        __proto__: {},
        extend: function (template) {
            let functions = Object.entries(template)
                .forEach(([key, value]) => typeof value === 'function' ? this.__proto__[key] = value : this[key] = value);
        }
    }
    return myObj;
}

//console.log(typeof myObj.extend === 'function')
myObj.extend({
    extensionMethod: function () { },
    extensionProperty: 'someString'
})

//   console.log(myObj.extend({
//     extensionMethod: function () {},
//     extensionProperty: 'someString'
//   }));
//console.log(Object.getPrototypeOf(myObj));
console.log(myObj);
