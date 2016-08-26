using System.ComponentModel.DataAnnotations;

namespace Project.Service
{
    public abstract partial class AVehicle
    {
        public int Id { get; set; }        
        public string Name { get; set; }
        public string Abrv { get; set; }     
    }

    [MetadataType(typeof(AVehicleMetaData))]
    public abstract partial class AVehicle
    {
    }

    public class AVehicleMetaData
    {
        [Display(Name = "Vehicle")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
