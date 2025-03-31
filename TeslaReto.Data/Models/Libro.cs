using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TeslaReto.Data.Models;
public class Libro : BaseEntity<int>
    {
        [Required]
        [MaxLength(100)]
        public string Titulo { get; set; } = "";// Título impreso del libro
        [RegularExpression(@"^\d{3}-\d{10}$", ErrorMessage = "El formato del ISBN-13 debe ser 978-0593081655")]
        public string ISBN13 { get; set; } = "";// Formato 978-0593081655
        [Required]
        [MaxLength(100)]
        public string Editorial { get; set; } = "";// Editorial del libro
        [Required]
        [Range(1450, 2026)]
        public int AnioPublicacion { get; set; } // Año de publicación
        public string Formato { get; set; } = ""; // Tipo de archivo (PDF, EPUB, etc.)
        public string Genero { get; set; } = ""; // Lista separada por comas de los géneros
        public string Idioma { get; set; } = ""; // Lista separada por comas de los idiomas
        public string Portada { get; set; } = ""; // Ruta de la imagen de la portada
        public string Edicion { get; set; } = ""; // Edición del libro
        public string ContraPortada { get; set; } = ""; // Resumen o sinopsis del libro
        [Required]
        [ForeignKey("autor")]
        public int AuthorID { get; set; } // ID del autor

        // public virtual Autor? Autor { get; set; }
}