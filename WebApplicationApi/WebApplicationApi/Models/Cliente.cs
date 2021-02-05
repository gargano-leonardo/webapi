using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationApi.Models
{
    public class Cliente
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Nome não pode ter mais de 50 carcateres")]
        public string Name { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage = "Nome não pode ter mais de 150 carcateres")]
        public string Endereco { get; set; }
    }
}
