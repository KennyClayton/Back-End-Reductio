// See https://aka.ms/new-console-template for more information

using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

List<Product> products = new List<Product>() //here is where we declare a new List of these product instances inside the products list (of the Product type)
{
    new Product()
    {
        Name = "Invisibility Cloak",
        Price = 27.00M,
        Available = true,
        ProductTypeId = 1,
        DateStocked = new (2023, 6, 15)
    },
    new Product()
    {
        Name = "Dress Robes",
        Price = 39.00M,
        Available = true,
        ProductTypeId = 1,
        DateStocked = new (2023, 7, 15)
    },
    new Product()
    {
        Name = "Polyjuice Potion",
        Price = 27.00M,
        Available = true,
        ProductTypeId = 2,
        DateStocked = new (2023, 8, 15)
    },
    new Product()
    {
        Name = "Wideye Potion",
        Price = 36.00M,
        Available = true,
        ProductTypeId = 2,
        DateStocked = new (2023, 1, 15)
    },
    new Product()
    {
        Name = "Deluminator",
        Price = 600.00M,
        Available = true,
        ProductTypeId = 3,
        DateStocked = new (2023, 2, 15)
    },
    new Product()
    {
        Name = "Talking Mirror",
        Price = 527.00M,
        Available = true,
        ProductTypeId = 3,
        DateStocked = new (2023, 3, 15)
    },
    new Product()
    {
        Name = "Holly and Phoenix Feather Wand",
        Price = 72.00M,
        Available = true,
        ProductTypeId = 4,
        DateStocked = new (2023, 4, 15)
    },
    new Product()
    {
        Name = "Yew and Phoenix Feather Wand",
        Price = 13.00M,
        Available = true,
        ProductTypeId = 4,
        DateStocked = new (2023, 5, 15)
    },
};

//^ Do we need to declare another List of associated ProductType options?
List<ProductType> productTypes = new List<ProductType> //productTypes is like an array here? Yes, but it is actually a list of product types
{
    new ProductType { Id = 1, Name = "Apparel" },
    new ProductType { Id = 2, Name = "Potions" },
    new ProductType { Id = 3, Name = "Enchanted Objects" },
    new ProductType { Id = 4, Name = "Wands" }
};

//^ DEFINE the greeting and store in variable
string greeting = "Welcome! Reductio & Absurdum have been providing high-quality magicianal supplies to the wizarding community for nearly 10 centures at their shop, right here on Calendula Road. Delve into our trove of magical marvels!";
//^ DISPLAY the greeting for the user
Console.WriteLine(greeting);

//^ DEFINE a main menu with working options to view all products, add, delete, update...
string menuOptions = (@"Make a Selection:
                        1. View All Products
                        2. Add a Product
                        3. Delete a Product
                        4. Update Product Details
                        5. Search Products
                        6. View All Available Products
                        7. Exit
                        ");



//^ FUNCTIONALITY to make the menu interactive
string choice = null; //this initalizes the choice variable as null
while (choice != "7") // The choice is currently null. When the user selects an option we want to keep running the below until a valid option is chosen. So WHILE the user entered something other than "5" on his keyboard...
{
    //^ DISPLAY the menu options to the user with WriteLine...
    Console.WriteLine(menuOptions);
    //^ RECEIVE input from the user with ReadLine...
    choice = Console.ReadLine(); //this stores the user's input into choice
    //^ FUNCTIONALITY to do this or that based on user's input above
    if (choice == "1") // if user enters 1, run the ListProducts method/function
    {
        Console.Clear();
        // throw new NotImplementedException();
        ListProducts();
    }
    else if (choice == "2")
    {
        // throw new NotImplementedException();
        AddProduct();
    }
    else if (choice == "3")
    {
        // throw new NotImplementedException();
        DeleteProduct();
    }
    else if (choice == "4")
    {
        // throw new NotImplementedException();
        UpdateProduct();
    }
    else if (choice == "5")
    {
        // throw new NotImplementedException();
        SearchProduct();
    }
    else if (choice == "6")
    {
        // throw new NotImplementedException();
        ViewAvailableProducts();
    }
    else if (choice == "7")
    {
        Console.WriteLine("Thanks for visiting. Mischief managed, and lumos on your adventures!");
    }

}

//^ FUNCTIONALITY to view all products - Create a method
void ListProducts()
{
    //^ DISPLAY a list of products to the user, starting with text
    Console.WriteLine("All Products: ");
    //^ DISPLAY all products by iterating over each product and using WriteLine
    for (int i = 0; i < products.Count; i++)
    {
        string availability = products[i].Available ? "Yes" : "No"; //this is optional because I wanted to display "Yes" instead of true to the user, or "No" instead of false
                                                                    //! I don't understand exactly how this works....FirstOrDefault???
                                                                    // I know this is a new instance of a ProductType
        ProductType productType = productTypes.FirstOrDefault(type => type.Id == products[i].ProductTypeId);
        string productTypeName = productType != null ? productType.Name : "Unknown";
        //^DISPLAY product details with WriteLine
        Console.WriteLine(
            $"Name: {products[i].Name}\n" +
            $"Price: ${products[i].Price}\n" +
            $"Available: {availability}\n" +
            $"Type: {productTypeName}\n" +
            $"Days on the Shelf: {products[i].DaysOnShelf}\n" +
            $"Seconds on the Shelf: {products[i].SecondsOnShelf}\n" +
            "");
    }
}

//^ FUNCTIONALITY to add a product to the inventory 
void AddProduct()
{
    //^ DISPLAY message to the user...
    Console.WriteLine($"Enter a name for your product: ");
    //^ READ and store the user's response
    string nameResponse = Console.ReadLine().Trim();

    //^ DISPLAY message to the user...
    Console.WriteLine($"Enter a price for your product: ");
    //^ READ and store the user's response - remember to parse
    int priceResponse = int.Parse(Console.ReadLine().Trim());

    //^ DISPLAY message to the user...
    Console.WriteLine($@"Choose a product type below (choose a number 1 - 4):" + "\n" +
    "1. Apparel" + "\n" +
    "2. Potions" + "\n" +
    "3. Enchanted Objects" + "\n" +
    "4. Wands"
    );
    //^ RETRIEVE and store the user's response
    string productTypeResponse = Console.ReadLine().Trim();

    //^ CLEANUP to make the console look not so busy
    Console.Clear();

    //^ CAPTURE and CREATE a new product variable to feed all of the user's answers into
    Product newProduct = new Product
    {
        Name = nameResponse,
        Price = priceResponse,
        Available = true,
        ProductTypeId = int.Parse(productTypeResponse)
    };

    //^ Store the shiny new product in the products List
    products.Add(newProduct);

};

//^ FUNCTIONALITY to delete a product from the inventory
void DeleteProduct()
{
    //^ DISPLAY a message to the user
    Console.WriteLine("Enter a product number to delete it:");
    //^ DISPLAY all product names by iterating over each product and using WriteLine
    for (int i = 0; i < products.Count; i++)
    {
        //^DISPLAY product name with WriteLine
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }

    //^ READ and STORE the user's input
    int userDeleteSelection = int.Parse(Console.ReadLine()) - 1; //minus one because if the user selects option 5, that is actually index 4....so subtract 1 from the 5 give by the user and we get index 4 to delete

    if (userDeleteSelection >= 0 && userDeleteSelection < products.Count)
    {
        Console.WriteLine($"You chose to delete {products[userDeleteSelection].Name}");
        products.RemoveAt(userDeleteSelection);
    }
    else
    {
        Console.WriteLine("Invalid choice.");
    }
};

//^ FUNCTIONALITY to update a product's details
void UpdateProduct()
{
    Console.Clear();
    // User selects the option 4 and this method/function will run
    //^ DISPLAY the list of products for the user to choose from
    Console.WriteLine("Enter a product number to update it:");
    //^ DISPLAY all product names by iterating over each product and using WriteLine
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
    //^ READ and STORE the user's input
    int userUpdateSelection = int.Parse(Console.ReadLine()) - 1;
    // int userSelectedIndex = userUpdateSelection - 1; //minus one because if the user selects option 5, that is actually index 4....so subtract 1 from the 5 give by the user and we get index 4 to update
    // Console.WriteLine($"user's actual number {userUpdateSelection}"); //testing
    // Console.WriteLine($"minus one to show index {userSelectedIndex}"); //testing


    //^ CREATE a new Product-type variable to hold the chosen product
    //! this is what gives us access to the particular product chosen by the user, when we store the FirstOrDefault's method results in the chosenProduct as a whole product
    //? How? We use FirstOrDefault method to LOCATE the product by productId

    Product chosenProduct = products.FirstOrDefault(p => p.ProductTypeId == userUpdateSelection);
    Console.WriteLine($"Your product name is currently {products[userUpdateSelection].Name}. Update the name below: ");
    string userUpdatedName = Console.ReadLine().Trim();

    //^ DISPLAY message to the user...
    Console.WriteLine($"Your product price is currently {products[userUpdateSelection].Price}. Update the price below: ");
    //^ READ and store the user's response - remember to parse
    decimal userUpdatedPrice = decimal.Parse(Console.ReadLine().Trim());

    //^ DISPLAY message to the user...
    Console.WriteLine($@"Choose a number 1 - 4 to update the type of product):" + "\n" +
    "1. Apparel" + "\n" +
    "2. Potions" + "\n" +
    "3. Enchanted Objects" + "\n" +
    "4. Wands"
    );
    //^ READ and store the user's response
    int userUpdatedType = int.Parse(Console.ReadLine().Trim());

    chosenProduct.Name = userUpdatedName;
    chosenProduct.Price = userUpdatedPrice;
    chosenProduct.ProductTypeId = userUpdatedType;
}


// These are good use cases for Where (to filter the products by ProductTypeId) and Select (to turn the List of ProductTypes into strings to display them).
void SearchProduct()
{
    {
        //^ DISPLAY message to the user...
        Console.Clear();
        // Console.WriteLine($"Look up a product by Type. Choose a number below:");
        // List<ProductType> listofTypes = productTypes.Select(t => t.Name).ToList();
        // foreach (var productType in listofTypes)
        // {
        //     Console.WriteLine(productType);
        // }


        Console.WriteLine($"Look up a product by Type. Choose a number below:"
        + "\n" +
        "1. Apparel" + "\n" +
        "2. Potions" + "\n" +
        "3. Enchanted Objects" + "\n" +
        "4. Wands"
        );


        int userInputNumber = int.Parse(Console.ReadLine());
        //Iterate over the list of products and display each product type
        // define a new List to hold the product types
        var userMatchedProducts = products.Where(product => product.ProductTypeId == userInputNumber).ToList();

        Console.WriteLine($@"Here are the matching products:");
        foreach (Product product in userMatchedProducts)
        {
            Console.WriteLine(product.Name);
        }
    };
}

//^BELOW IS THE ORIGINAL SearchProduct code
// void SearchProduct() 
// {
//     //^ DISPLAY message to the user...
//     Console.Clear();
//     Console.WriteLine($"Look up a product by Type. Choose a number below:"
//     + "\n" +
//     "1. Apparel" + "\n" +
//     "2. Potions" + "\n" +
//     "3. Enchanted Objects" + "\n" +
//     "4. Wands"
//     );
//     int userInputNumber = int.Parse(Console.ReadLine());

//     //^ Search the products List by productTypeId (Compare user input to existing list)
//     List<Product> userMatchedProduct = new List<Product>();
//     foreach (Product product in products)
//     {
//         if(product.ProductTypeId == (userInputNumber))
//         {
//             userMatchedProduct.Add(product); //add the matched product to the new List
//         }
//     }
//     Console.WriteLine($@"Here are the matching products:");
//     foreach (Product product in userMatchedProduct)
//     {
//      Console.WriteLine(product.Name);
//     }
// };

void ViewAvailableProducts()
{
    Console.Clear();
    List<Product> unsoldProducts = products.Where(p => p.Available).ToList();
    
    foreach (Product product in unsoldProducts)
    {
        Console.WriteLine(product);
    }
};





//* LEARNING FirstOrDefault Method
//so use FirstOrDefault method on the products list and run an anonymous function on that method that takes (in this case) the property Id and FINDS a product Id among all products that matches the Id we gave it. Then it updates a Product-type variable that references the user's chosen product.

// So the FirstOrDefault method is looking for whatever product property we tell it and UPDATES that property with the user's chosen product(index). That 