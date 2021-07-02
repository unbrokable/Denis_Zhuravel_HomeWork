class Validator{
    constructor(){
        this.isValid = function(){
            return "Not implemented";
        }
    }
}
class EmailValidator extends Validator{
    constructor(pattern){
        super();
        this.pattern = pattern ;
        this.isValid = function (data) {
            return data.match(this.pattern) !== null ? true:false; 
        }
    }
}
class PhoneValidator extends Validator{
    constructor(pattern){
        super();
        this.pattern = pattern ;
        this.isValid = function (data) {
            return data.match(this.pattern) !== null ? true:false; 
        }
    }
}

let validatorPhone = new PhoneValidator(/^\+?([0-9]{2})\)?[-. ]?([0-9]{4})[-. ]?([0-9]{4})$/);
let validatorEmail = new EmailValidator(/^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$/);
console.log(validatorPhone.isValid("2323dfgd23"));
console.log(validatorPhone.isValid("+12-1111-1111"));
console.log(validatorEmail.isValid("deonisij340@gmail.com"));
console.log(validatorEmail.isValid("deonisij340gmail.com"));