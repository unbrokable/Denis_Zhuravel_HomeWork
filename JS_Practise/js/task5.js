function AddString(str, addElement){
    if(str.substr(0,addElement.length) === addElement || !str || str.length === 0 ){
        return str;
    }
    return addElement + str;
}

console.log(AddString("", "wrwerw"));
console.log(AddString("руююю", "ру"));
console.log(AddString("салка", "ру"));