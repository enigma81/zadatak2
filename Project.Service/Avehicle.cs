using System.ComponentModel.DataAnnotations;

namespace Project.Service
{
    public abstract class AVehicle
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Abrv { get; set; }     
    }
}
