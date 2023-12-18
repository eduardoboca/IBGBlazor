using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IBGBlazor.Models
{
    public class Estado
    {
        [Key]
        [Required(ErrorMessage = "Codigo_UF é obrigatório")]
        [Column(TypeName = "char(2)")]
        public string? Codigo_UF { get; set; }

        [Required(ErrorMessage = "Sigla_UF é obrigatório")]
        [Column(TypeName = "char(2)")]
        public string? Sigla_UF { get; set; }

        [Required(ErrorMessage = "Nome_UF é obrigatório")]
        [Column(TypeName = "nvarchar(80)")]
        public string? Nome_UF { get; set; }

        public ICollection<Municipio> Municipios { get; set; }

    }
}
