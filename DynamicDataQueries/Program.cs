using DynamicDataQueries.Service;

public class Program
{
    public static void Main()
    {
        var products = new List<Product>
        {
            new Product { Name = "Product A", Price = 100, ReleaseDate = new DateTime(2020, 1, 1), StockCount = 10 },
            new Product { Name = "Product B", Price = 50, ReleaseDate = new DateTime(2022, 5, 1), StockCount = 50 },
            new Product { Name = "Product C", Price = 150, ReleaseDate = new DateTime(2021, 10, 10), StockCount = 30 },
            new Product { Name = "Product D", Price = 200, ReleaseDate = new DateTime(2023, 3, 3), StockCount = 20 }
        };

        var queryService = new QueryService<Product>();

        // Apply combined filter + sort pipeline
        var filteredAndSortedProducts = queryService.ApplyQueryPipeline(
            products,
            p => p.Price > 50, 
            p => p.ReleaseDate,
            ascending: false);  

        Console.WriteLine("Filtered and Sorted Products:");
        foreach (var product in filteredAndSortedProducts)
        {
            Console.WriteLine($"{product.Name} - {product.Price:C}");
        }

        // Apply transformation after filter + sort
        var transformedProducts = queryService.Transform(filteredAndSortedProducts, p => new { p.Name, p.Price });

        Console.WriteLine("\nTransformed Products (Name + Price):");
        foreach (var product in transformedProducts)
        {
            Console.WriteLine($"Name: {product.Name}, Price: {product.Price:C}");
        }
    }
}
