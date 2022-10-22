using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.Cinemas
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }
        public int EnderecoId { get; set; }
        public int GerenteId { get; set; }
    }
}