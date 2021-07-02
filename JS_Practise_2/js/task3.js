function  getKeyValue(object) {
    let arr = [];
    for (const key in object) {
        arr.push([key,object[key]]);
    }
    return arr;
}
let obj = {
    name: "12345",
    age:18,
    getSomething: () => "Coool"
}
console.log(getKeyValue(obj));