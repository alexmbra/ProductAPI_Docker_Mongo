using MongoDB.Driver;
using ProductAPI.Enities;

namespace ProductAPI.Data;

public interface IProductContext
{
    IMongoCollection<Product> Products { get; }
}
