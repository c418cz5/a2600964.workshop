# Topic 3 pracB notes
Polymorphism allows different class to use the same method in different ways.
in this task, FullTimeEmployeee and Conractor are both stored in a list <Employee>.  the forech loop treats them as Employee objects, but CalculatePay ()  use the correct method from each  class 
this means I can use one list and one loop instead of writing separate code for each employee type . 

### task4 reflection 
Polymorphism allows different employee classes to use the same method name in different ways. In my program, both FullTimeEmployee and Contractor use CalculatePay(), but each class calculates the pay differently.

Inheritance helps the classes share the Name property and the CalculatePay method structure. Polymorphism allows me to store both types in a List<Employee> and use one foreach loop.

Python can also use polymorphism, but C# requires the base class, abstract method and override to be declared clearly. This gives more compile-time checking.