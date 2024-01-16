using GestorViviendaAPI.Data;
using GestorViviendaAPI.Models;

namespace GestorViviendaAPI.Service;

public class UsuarioService
{
    private readonly GestorViviendaContext _context;

    public UsuarioService(GestorViviendaContext context)
    {
        _context = context;
    }

    public IEnumerable<Usuario> GetAll()
    {
        return _context.Usuarios.ToList();
    }

    public Usuario? GetById(Guid id)
    {
        return _context.Usuarios.SingleOrDefault(u => u.uuid == id);
    }

    public Usuario Create(Usuario newUsuario)
    {
        _context.Usuarios.Add(newUsuario);
        _context.SaveChanges();

        return newUsuario;
    }

    public void Update(Usuario usuario)
    {
        if (usuario is null) throw new InvalidOperationException("Usuario no encontrado");
        _context.Usuarios.Update(usuario);
        _context.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var usuario = _context.Usuarios.Find(id);
        if (usuario is null) throw new InvalidOperationException("Usuario no encontrado");
        _context.Usuarios.Remove(usuario);
        _context.SaveChanges();
    }
}