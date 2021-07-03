function countVowels(str){
    return Array.from(str.toLowerCase()).filter(letter => "аеёиоуыэюя".includes(letter)).length;
}

console.log(countVowels("Английский алфавит"));