function removeDuplicates(arr){
    return arr.filter( (a,b) => arr.indexOf(a) == b);
}
console.log(removeDuplicates(([1, 1, 2, 3, 4, 3, 2])));