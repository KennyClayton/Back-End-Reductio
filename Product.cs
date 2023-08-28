using System.Diagnostics;

public class Product 
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool Available { get; set; }
    public int ProductTypeId { get; set; }
    public ProductType Type { get; set; } //here, Type is not an integer or boolean or string....it's a ProductType
}

public class ProductType
{
    public int Id { get; set; }
    public string Name { get; set; }
}

//^ We created a class called Plant. What does a class do?
    // A class looks like an object, but it's just a BLUEPRINT for creating objetcs.
    // When I create this Plant class, I can then create Plant class objects (plant instances) that MUST adhere to the above blueprint. That is, every new INSTANCE of a plant that I create MUST have only these three properties above: name, price, available and product type Id. And each of those properties will only be string data type for the Name, decimal data type for the Price, boolean data type for Available and integer data type for the ProductTypeId...
    // This Plant class is the guide, the template, the blueprint for any plant "object" or "instance" I may want to create in the future. 
    // So, where do we create the plant objects/instances then? We create them in our Program file at the top of that file. The file gets read from top to bottom when being executed so it needs that code (those objects) first
    // So, again, as ChatGPT puts it: "Classes in C# define the structure (fields/properties and methods) that objects will have."