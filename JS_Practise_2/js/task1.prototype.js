function Shape (){
}
Shape.prototype.getArea = function() {
    throw new Error("Abstract class");  
}

function  Circle(radius) {
    this.radius = radius;
}

function Square(side) {
    this.side = side;
}

Circle.prototype = Object.create(Shape.prototype);
Square.prototype = Object.create(Shape.prototype);

let shape = new Shape();

let circle = new Circle(10);
let square = new Square(5);
//circle.getArea()

Square.prototype.getArea = function() {
    return this.side**2;
}

Circle.prototype.getArea = function() {
  return this.radius**2 * Math.PI;  
}
    
console.log(circle.getArea());
console.log(square.getArea());