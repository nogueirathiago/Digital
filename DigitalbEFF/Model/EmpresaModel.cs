using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DigitalbEFF.Model
{
    [Table("Empresas")]
    public class EmpresaModel
    {
        [Key]
        public int Id { get; set; }

        [EmailAddress(ErrorMessage = "Email Inválido")]
        [MaxLength(30)]
        public string email { get; set; }
        [MaxLength(30)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }
        [MaxLength(30)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Cnpj { get; set; }
        [MaxLength(30)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Contato { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Endereço { get; set; } 
        [MaxLength(10)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Cep { get; set; }
        [MaxLength(2)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Uf { get; set; }
        [MaxLength(30)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Municipio { get; set; }
        [MaxLength(13)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Telefone { get; set; }

        public ICollection<PedidosModel> Pedidos { get; set; }
    }
}