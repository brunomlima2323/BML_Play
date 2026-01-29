namespace BML_Play.Models
{
    public class Filme
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = null!;

        public string Descricao { get; set; } = null!;

        public int Ano { get; set; }

        public string Duracao { get; set; } = null!;

        public string Genero { get; set; } = null!;

        public string UrlVideo { get; set; } = null!;

        public string? UrlCapa { get; set; }
    }
}