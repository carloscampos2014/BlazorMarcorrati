using System.ComponentModel.DataAnnotations;
using Livraria.Domain.Enums;

namespace Livraria.Domain.Entities;
public class Livro
{
    public Livro(
        int livroId,
        string? titulo,
        string? autor,
        DateTime lancamento,
        string? capa,
        Editora editora,
        Categoria categoria)
    {
        LivroId = livroId;
        Titulo = titulo;
        Autor = autor;
        Lancamento = lancamento;
        Capa = capa;
        Editora = editora;
        Categoria = categoria;
    }

    public int LivroId { get; set; }

    [Required(ErrorMessage = "Informe o titulo do livro.")]
    [StringLength(150, ErrorMessage = "Tamanho máximo e de 150 caracteres.")]
    public string? Titulo { get; set; }

    [Required(ErrorMessage = "Informe o autor do livro.")]
    [StringLength(200, ErrorMessage = "Tamanho máximo e de 200 caracteres.")]
    public string? Autor { get; set; }

    [Required(ErrorMessage = "Informe a data de lançamento do livro.")]
    public DateTime Lancamento { get; set; }

    [Required(ErrorMessage = "Informe a imagem da capa do livro.")]
    [StringLength(200, ErrorMessage = "Tamanho máximo e de 200 caracteres.")]
    public string? Capa { get; set; }

    [Required(ErrorMessage = "Informe a editora do livro.")]
    [EnumDataType(typeof(Editora), ErrorMessage = "Deve selecionar uma editora para o livro.")]
    public Editora Editora { get; set; }

    [Required(ErrorMessage = "Informe a categoria do livro.")]
    [EnumDataType(typeof(Categoria), ErrorMessage = "Deve selecionar uma categoria para o livro.")]
    public Categoria Categoria { get; set; }
}
