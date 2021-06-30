function countVowels(str){
    return Array.from(str.toLowerCase()).filter(letter => "аи".includes(letter)).length;
}

console.log(countVowels("Английский алфавит"));