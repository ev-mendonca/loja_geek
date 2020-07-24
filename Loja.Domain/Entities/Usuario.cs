using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loja.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        [Required(ErrorMessage = "Nome é obrigatório"),
            MaxLength(255, ErrorMessage = "Tamanho máximo permitido é de 255 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email é obrigatório"),
            MaxLength(100, ErrorMessage = "Tamanho máximo permitido é de 100 caracteres"),
            EmailAddress(ErrorMessage = "Formato de email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Login é obrigatório"),
            MinLength(5, ErrorMessage = "Tamanho mínimo permitido é de 5 caracteres"), 
            MaxLength(20, ErrorMessage = "Tamanho máximo permitido é de 20 caracteres"),
            RegularExpression(@"[\w]{1,20}", ErrorMessage = "Só são permitidos letras, números e _")]
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
