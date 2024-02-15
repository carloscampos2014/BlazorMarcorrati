using Livraria.Domain.Abstractions;
using Livraria.Domain.Entities;
using Livraria.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Infrastructure.Repositories;
public class LivroRepository : ILivroRepository
{
    private readonly ApplicationDbContext _context;

    public LivroRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Livro> AdicionarLivro(Livro livro)
    {
        if (livro == null || _context == null || _context.Livros == null)
        {
            throw new InvalidOperationException("Os dados são inválidos!");
        }

        _context.Livros.Add(livro);
        await _context.SaveChangesAsync();
        return livro;
    }

    public async Task<Livro> AtualizarLivro(Livro livro)
    {
        if (livro == null || _context == null || _context.Livros == null)
        {
            throw new InvalidOperationException("Os dados são inválidos!");
        }

        _context.Entry(livro).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return livro;
    }

    public async Task DeletarLivro(int id)
    {
        var livro = await ObterLivro(id);
        if (livro == null || _context == null || _context.Livros == null)
        {
            throw new InvalidOperationException("Os dados são inválidos!");
        }

        _context.Livros.Remove(livro);
        await _context.SaveChangesAsync();
    }

    public async Task<Livro?> ObterLivro(int id)
    {
        if (_context == null || _context.Livros == null)
        {
            return null;
        }

        return await _context.Livros.FirstOrDefaultAsync(f => f.LivroId == id);
    }

    public async Task<IEnumerable<Livro>> ObterLivros()
    {
        if (_context == null || _context.Livros == null)
        {
            return new List<Livro>();
        }

        return await _context.Livros.ToListAsync();
    }
}
