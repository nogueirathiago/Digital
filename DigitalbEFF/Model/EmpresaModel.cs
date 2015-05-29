using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigitalbEFF.Model
{
    public class EmpresaModel
    {
        [Key]
        public int Id { get; set; }

        [EmailAddress(ErrorMessage = "Email Inválido")]
        public string email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Contato { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Endereço { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Uf { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Municipio { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Telefone { get; set; }




    }
}