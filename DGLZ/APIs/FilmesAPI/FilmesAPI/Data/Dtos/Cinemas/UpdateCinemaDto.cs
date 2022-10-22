using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.Cinemas
{
    public class UpdateCinemaDto
    {
        [Required(ErrorMessage = "O campo Nome é obrigatírio")]
        public string Nome { get; set; }
    }
}