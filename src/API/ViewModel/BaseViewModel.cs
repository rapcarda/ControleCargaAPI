using System.ComponentModel.DataAnnotations;

namespace API.ViewModel
{
    public class BaseViewModel
    {
        [Key]
        public long Id { get; set; }
    }
}
