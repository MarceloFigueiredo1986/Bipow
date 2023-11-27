namespace Bipow.Domain.Entities.Products;

public class ProductEntity
{
    public int ProductId { get; set; }
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset DeleteDate { get; set; }

}
