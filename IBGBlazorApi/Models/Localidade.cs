using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IBGBlazorApi.Models
{
    public class Localidade
    {
        [Key]
        [Required(ErrorMessage = "Id é obrigatório")]
        [Column(TypeName = "char(7)")]
        public string? Id { get; set; }

        [Required(ErrorMessage = "Estado é obrigatório")]
        [Column(TypeName = "char(2)")]
        public string? State { get; set; }

        [Required(ErrorMessage = "Cidade é obrigatório")]
        [Column(TypeName = "nvarchar(80)")]
        public string? City { get; set; }
    }
}
