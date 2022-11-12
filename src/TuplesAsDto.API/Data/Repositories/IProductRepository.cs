using TuplesAsDto.API.Data.Entities;

namespace TuplesAsDto.API.Data.Repositories;

public interface IProductRepository
{
    Task<Tuple<int, List<ProductModel>>> GetAllTupleAsync();
    Task<(int, List<ProductModel>)> GetAllTupleImplicitAsync();
    Task<List<(int, string)>> GetInactivesAsync();
    Task<List<(int, string)>> GetInactiveEfValueTupleAsync();
    Task<List<(int, string)>> GetInactiveEfAnonymousAsync();
}