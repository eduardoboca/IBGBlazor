﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IBGBlazor.Models
{
    public class Municipio
    {
        [Key]
        [Required(ErrorMessage = "Codigo_Municipio é obrigatório")]
        [Column(TypeName = "char(7)")]
        public string? Codigo_Municipio { get; set; }

        [Required(ErrorMessage = "Nome_Municipio é obrigatório")]
        [Column(TypeName = "nvarchar(80)")]
        public string? Nome_Municipio { get; set; }

        public Estado? Estado { get; set; } = new();

        public override string ToString()
        {
            return $"Codigo_Municipio: {Codigo_Municipio} Nome_Municipio: {Nome_Municipio}";
        }
    }
}
