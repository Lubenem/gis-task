using Geometry;

Figure circle = new Circle(10, "blue");
Console.WriteLine(circle.GetAreaInfo() == "Area of blue Circle is 314" ? "OK" : "Fail");

Figure rect = new Rectangle(5, 4, "red");
Console.WriteLine(rect.GetAreaInfo() == "Area of red Rectangle is 20" ? "OK" : "Fail");

var square = new Square(5, "green");
Console.WriteLine(square.GetAreaInfo() == "Area of green Square is 25" ? "OK" : "Fail");