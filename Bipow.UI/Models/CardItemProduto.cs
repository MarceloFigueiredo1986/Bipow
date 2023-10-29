using Bipow.Components.ProductArea;
namespace Bipow.UI.Models;

public class CardItemProduto : IProductCardInterface
{
    public string Nome { get; init; } = "Camisola de Caxemira tricotada";
    public string UrlImagem64 { get; init; } = "https://ik.imagekit.io/da113ycvp/Bipow/Produtos/size64/Camisolas/CamisolaSeleccao.jpeg?updatedAt=1698595558051";
    public string Descricao { get; init; } = "Camisola da selecção nacional 2023, produzida com o tecido desportivo mais avançado";
    public decimal Pontuacao { get; init; } = decimal.Parse("3,5");
    public string Colecao { get; init; } = "Outono";
    public string[] Tamanhos { get; init; } = new string[] { "XS","S", "M","ML", "L", "XL", "XXL" };
    public decimal Preco { get; init; } = decimal.Parse("132,55");
}
