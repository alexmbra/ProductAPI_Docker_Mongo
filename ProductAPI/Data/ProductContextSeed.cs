using Bogus;
using MongoDB.Driver;
using ProductAPI.Enities;

namespace ProductAPI.Data;

public class ProductContextSeed
{
    public static void SeedData(IMongoCollection<Product> productCollection)
    {
        bool existProduct = productCollection.Find(p => true).Any();

        //productCollection.DeleteManyAsync(p => true);

        if (!existProduct)
        {
            productCollection.InsertManyAsync(GetMyProducts());
        }
    }

    private static IEnumerable<Product> GetMyProducts()
    {
        var categories = new[] { "Electronics", "Clothing", "Books", "Toys", "Home Decor" };

        var faker = new Faker<Product>()
           .RuleFor(p => p.Id, f => f.Random.Guid().ToString("N").Substring(0, 24))
           .RuleFor(p => p.Name, f => f.Commerce.ProductName())
           .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
           .RuleFor(p => p.Image, f => f.Commerce.ProductName() + ".jpg")
           .RuleFor(p => p.Price, f => Math.Round(f.Finance.Amount(1, 100), 2))
           .RuleFor(p => p.Category, f => f.PickRandom(categories))
           .Generate(10);

        return faker;
    }
}
