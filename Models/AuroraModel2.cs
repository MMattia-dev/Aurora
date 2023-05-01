using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace Aurora.Models
{
    public class AuroraModel2
    {
        public int Id { get; set; }
        public string? UserID { get; set; }

        [Required(ErrorMessage = "Pole nie może być puste!")]
        [Display(Name = "Tytuł zlecenia")]
        public string? Title { get; set; }

        [Display(Name = "Opis zadania")]
        public string? Description { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Data rozpoczęcia zlecenia")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Pole nie może być puste!")]
        [Display(Name = "Miejscowość (Opcjonalne)")]
        public string? Place { get; set; }

        [Required(ErrorMessage = "Należy wybrać jedną z opcji!")]
        [Display(Name = "Przybliżony czas wykonywania zlecenia")]
        public string? JobLength { get; set; }

        [Required(ErrorMessage = "Należy wybrać jedną z opcji!")]
        [Display(Name = "Poziom skomplikowania zadania")]
        public string? Difficulty { get; set; }

        [Required(ErrorMessage = "Należy wybrać jedną z opcji!")]
        [Display(Name = "Ile osób potrzebujesz do zadania?")]
        public int JobWorkers { get; set; }

        [Required(ErrorMessage = "Pole nie może być puste!")]
        [MaxLength(9)]
        [RegularExpression(@"^(\d{9})$", ErrorMessage = "Format numeru jest nieprawidłowy!")]
        [Display(Name = "Numer telefonu komórkowego")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Należy wybrać jedną z opcji!")]
        [Display(Name = "Czas trwania ogłoszenia")]
        public string? TimeLength { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime JobEnd { get; set; }

        public bool JobHidden { get; set; }

        public bool JobDone { get; set; }

    }
}
