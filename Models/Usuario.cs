using System.ComponentModel.DataAnnotations;

namespace GestorViviendaAPI.Models;

public class Usuario
{
    [Key]
    public Guid uuid { get; set; }

    [Required]
    [MaxLength(50)]
    public string? nombre { get; set; }

    [Required]
    [MaxLength(50)]
    public string? apellido { get; set; }
    [Required]
    [MaxLength(255)]
    [EmailAddress]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$")]

    public string? email { get; set; }

    [MaxLength(50)]
    public string? genero { get; set; }

    [Required]
    [MaxLength(255)]
    [DataType(DataType.Password)]
    public string? clave { get; set; }


    public bool es_vendedor { get; set; }

}