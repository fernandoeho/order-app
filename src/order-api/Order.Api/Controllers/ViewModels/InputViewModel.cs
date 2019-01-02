using System.ComponentModel.DataAnnotations;

namespace Order.Api.Controllers.ViewModels
{
    public class InputViewModel
    {
        [Required]
        public string Input { get; set; }
    }
}