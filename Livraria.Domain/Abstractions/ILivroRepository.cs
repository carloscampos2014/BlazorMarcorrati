using Livraria.Domain.Entities;

namespace Livraria.Domain.Abstractions;
public interface ILivroRepository
{
    Task<Livro> AdicionarLivro(Livro livro);

    Task<Livro> AtualizarLivro(Livro livro);

    Task DeletarLivro(int id);

    Task<Livro?> ObterLivro(int id);

    Task<IEnumerable<Livro>> ObterLivros();
}
