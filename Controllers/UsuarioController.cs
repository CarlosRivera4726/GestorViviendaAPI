using GestorViviendaAPI.Models;
using GestorViviendaAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace GestorViviendaAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{

    private readonly UsuarioService _usuarioService;
    private readonly ILogger<UsuarioController> _logger;

    public UsuarioController(ILogger<UsuarioController> logger, UsuarioService usuarioService)
    {
        _logger = logger;
        _usuarioService = usuarioService;
    }

    [HttpGet(Name = "GetUsuarios")]
    public IEnumerable<Usuario> Get()
    {
        return _usuarioService.GetAll();
    }

    [HttpGet("{id}", Name = "GetUsuario")]
    public ActionResult<Usuario> Get(Guid id)
    {
        var usuario = _usuarioService.GetById(id);
        if (usuario is null) return NotFound();
        return usuario;
    }

    [HttpPost]
    public IActionResult addUsuario(Usuario usuario)
    {
        _usuarioService.Create(usuario);
        return CreatedAtRoute("GetUsuario", new { id = usuario.uuid }, usuario);
    }

    [HttpPut("{id}")]
    public IActionResult updateUsuario(Guid id, Usuario usuario)
    {
        if (id != usuario.uuid) return BadRequest();
        try
        {
            _usuarioService.Update(usuario);
        }
        catch (InvalidOperationException e)
        {
            _logger.LogError(e.Message);
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult deleteUsuario(Guid id)
    {
        try
        {
            _usuarioService.Delete(id);
            return Ok();
        }
        catch (InvalidOperationException e)
        {
            _logger.LogError(e.Message);
            return NotFound();
        }
    }
}
