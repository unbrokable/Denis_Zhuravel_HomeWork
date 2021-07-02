class Shape{
    constructor(){

    }
    getArea() {
        throw new Error("Abstract class");    
    }
}
class Circle extends Shape{
    constructor(radius){
        super();
        this.radius = radius;
    }
    getArea(){
        return  this.radius**2 * Math.PI; 
    }
} 

class Square extends Shape{
    constructor(side){
        super();
        this.side = side;
    }
    getArea(){
        return this.side**2;
    }
}
let square = new Square(5);
let circle = new Circle(4);
console.log(square.getArea());
console.log(circle.getArea());