using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;

namespace Aurora.Models
{
    public class AuroraModel
    {
        public int Id { get; set; }

        //[HiddenInput(DisplayValue = false)]
        public string? UserID { get; set; }

        [Required(ErrorMessage = "Pole nie może być puste!")]
        [Display(Name = "Tytuł zlecenia")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Pole nie może być puste!")]
        [Display(Name = "Opis zadania/zadań")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Należy wybrać datę!")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Data rozpoczęcia zlecenia")]
        public DateTime Date { get; set; }

        public bool AcceptStatus { get; set; }

        [Required(ErrorMessage = "Pole nie może być puste!")]
        [Display(Name = "Miejscowość")]
        public string? Place { get; set; }

        //[NotMapped]
        [Required(ErrorMessage = "Pole nie może być puste!")]
        [Display(Name = "Przybliżony czas wykonywania zlecenia")]
        public string? JobLength { get; set; }
        //public IList<SelectListGroup>? JobLength { get; set; }

        [Required(ErrorMessage = "Pole nie może być puste!")]
        [Display(Name = "Ilu \"złotych rączek\" potrzebujesz?")]
        public int JobWorkers { get; set; }

        [Required(ErrorMessage = "Pole nie może być puste!")]
        [MaxLength(9)]
        [RegularExpression(@"^(\d{9})$", ErrorMessage = "Format numeru jest nieprawidłowy!")]
        [Display(Name = "Numer telefonu komórkowego")]
        public string? Phone { get; set; }

        //[Required(ErrorMessage = "Pole nie może być puste!")]
        [Display(Name = "Imię wystawiającego")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Pole nie może być puste!")]
        [Display(Name = "Czas trwania ogłoszenia")]
        public string? TimeLength { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime JobEnd { get; set; }

        public bool JobHidden { get; set; }

        public bool JobDone { get; set; }


    }

}
