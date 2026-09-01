
//create a "products" variable here to include at least five Product instances. Give them appropriate ProductTypeIds.
List<Product> products = new List<Product>
{
    new Product { Name = "Trumpet", Price = 150.99M, ProductTypeId = 1 },
    new Product { Name = "Trombone", Price = 246.99M, ProductTypeId = 1 },
    new Product { Name = "Saxophone", Price = 450.99M, ProductTypeId = 1},
    new Product { Name = "Haiku", Price = 00.00M, ProductTypeId = 2},
    new Product { Name = "Symbols", Price = 99.99M, ProductTypeId = 1}
    // ...at least 5
};
//create a "productTypes" variable here with a List of ProductTypes, and add "Brass" and "Poem" types to the List. 
List<ProductType> productTypes = new List<ProductType>
{
    new ProductType { Id = 1, Title = "Brass" },
    new ProductType { Id = 2, Title = "Poem" }
};
//put your greeting here
Console.WriteLine("Welcome and Hello World!");
Console.WriteLine("------------------------------------------------");
Console.WriteLine();

//implement your loop here

bool running = true;
while (running)
{
    DisplayMenu();
    string choice = Console.ReadLine();

    if (int.TryParse(choice, out int choiceNumber))
    {
        switch (choiceNumber)
        {
            case 1:
                DisplayAllProducts(products, productTypes);
                break;
            case 2:
                DeleteProduct(products, productTypes);
                break;
            case 3:
                AddProduct(products, productTypes);
                break;
            case 4:
                UpdateProduct(products, productTypes);
                break;
            case 5:
                running = false;
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }
}

void DisplayMenu()
{
    Console.WriteLine("1. Display all products");
    Console.WriteLine("2. Delete a product");
    Console.WriteLine("3. Add a new product");
    Console.WriteLine("4. Update product properties");
    Console.WriteLine("5. Exit");
}

void DisplayAllProducts(List<Product> products, List<ProductType> productTypes)
{
    for (int i = 0; i < products.Count; i++)
{
    ProductType matchedType = productTypes.FirstOrDefault(pt => pt.Id == products[i].ProductTypeId);

    Console.WriteLine($"{i + 1}. {products[i].Name} - {products[i].Price} - {matchedType.Title}");
}
}

void DeleteProduct(List<Product> products, List<ProductType> productTypes)
{   
    string userInput = Console.ReadLine();
    
    if (int.TryParse(userInput, out int i))
    {
        products.RemoveAt(i - 1);
    }
}

void AddProduct(List<Product> products, List<ProductType> productTypes)
{
    string addedName = Console.ReadLine();

    string addedPrice = Console.ReadLine();

    string addedProductType = Console.ReadLine();

    if (decimal.TryParse(addedPrice, out decimal i))
    {
        if (int.TryParse(addedProductType, out int pt))
        {
            Product addedInput = new Product { Name = addedName, Price = i, ProductTypeId = pt}; 
            products.Add(addedInput);
        }
    }
}

void UpdateProduct(List<Product> products, List<ProductType> productTypes)
{
    string input = Console.ReadLine();

    if (int.TryParse(input, out int i))
    {
        Product updatedProduct = products[i - 1];

        string newName = Console.ReadLine();
        string newPrice = Console.ReadLine();
        string newProductTypeId = Console.ReadLine();
        if (!string.IsNullOrEmpty(newName))
        {
            updatedProduct.Name = newName;
        }
        if (decimal.TryParse(newPrice, out decimal newP))
        {
            updatedProduct.Price = newP;
        }
        if (int.TryParse(newProductTypeId, out int newPt))
        {
            updatedProduct.ProductTypeId = newPt;
        }
    }
}

// don't move or change this!
public partial class Program { }