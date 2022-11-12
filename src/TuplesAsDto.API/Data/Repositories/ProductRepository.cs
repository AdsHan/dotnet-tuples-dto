using Microsoft.EntityFrameworkCore;
using TuplesAsDto.API.Data.Entities;
using TuplesAsDto.API.Data.Enums;

namespace TuplesAsDto.API.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly CatalogDbContext _dbContext;

    public ProductRepository(CatalogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Tuple<int, List<ProductModel>>> GetAllTupleAsync()
    {
        var products = await _dbContext.Products
            .AsNoTracking()
            .ToListAsync();

        return new Tuple<int, List<ProductModel>>(products.Count, products);
    }

    public async Task<(int, List<ProductModel>)> GetAllTupleImplicitAsync()
    {
        var products = await _dbContext.Products
            .AsNoTracking()
            .ToListAsync();

        return (products.Count, products);
    }

    public async Task<List<(int, string)>> GetInactivesAsync()
    {
        var inactives = new List<(int, string)>();

        var products = await _dbContext.Products
            .AsNoTracking()
            .ToListAsync();

        foreach (var product in products)
        {
            inactives.Add((product.Id, product.Description));
        }
        return inactives;
    }

    public async Task<List<(int, string)>> GetInactiveEfValueTupleAsync()
    {
        var products = await _dbContext.Products
            .Where(a => a.Status == EntityStatusEnum.Inactive)
            .Select(p => ValueTuple.Create(p.Id, p.Description))
            .ToListAsync();

        return (products);
    }

    public async Task<List<(int, string)>> GetInactiveEfAnonymousAsync()
    {
        var products = _dbContext.Products
            .Where(a => a.Status == EntityStatusEnum.Inactive)
            .Select(p => new { p.Id, p.Description })
            .AsEnumerable()
            .Select(p => (p.Id, p.Description))
            .ToList();

        return (products);
    }

}