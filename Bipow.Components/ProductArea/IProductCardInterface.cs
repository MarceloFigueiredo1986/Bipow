using System.ComponentModel.DataAnnotations;

namespace Bipow.Components.ProductArea;

public interface IProductCardInterface
{
    string Nome { get; init; }
    string UrlImagem64 { get; init; }
    [MaxLength(255)]
    string Descricao { get; init; }
    decimal Pontuacao { get; init; }
    string Colecao { get; init; }
    string[] Tamanhos { get; init; }
    decimal Preco { get; init; }
}