using TuplesAsDto.API.Data.Enums;

namespace TuplesAsDto.API.Data.Entities;

public class ProductModel
{

    // EF Construtor
    public ProductModel()
    {
        DateCreateAt = DateTime.Now;
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public EntityStatusEnum Status { get; set; }
    public DateTime DateCreateAt { get; private set; }

}
