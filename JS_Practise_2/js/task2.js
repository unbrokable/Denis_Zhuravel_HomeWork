function  showAllProperties(obj) {
    let keys = Object.keys(obj);
    for (const key of keys) {
        console.log(key);
    }
}

let obj = {
    name: "12345",
    age:18,
    getSomething: () => "Coool"
}
showAllProperties(obj);