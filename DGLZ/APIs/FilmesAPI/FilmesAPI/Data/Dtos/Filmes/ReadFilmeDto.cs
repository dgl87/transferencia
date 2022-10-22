using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos.Filmes
{
    public class ReadFilmeDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Titulo é obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo Diretor é obrigatório")]
        public string Diretor { get; set; }
        [StringLength(30, ErrorMessage = "O Genero não pode ultrapassar 30 caracteres")]
        public string Genero { get; set; }
        [Range(1, 600, ErrorMessage = "A Duração deve estar entre 1 e 600")]
        public int Duracao { get; set; }
        public int ClassificacaoEtaria { get; set; }
        public DateTime HoraDaConsulta { get; set; } 
    }
}
