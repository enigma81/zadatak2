using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace Project.Service
{
    public partial class VehicleModel : AVehicle
    {
        private int _makeId;
        
        public int MakeId
        {
            get
            {
                return this._makeId;
            }

            set
            {
                Contract.Requires(value > 0);
                if(value != _makeId)
                {
                    this._makeId = value;
                }
            }             
        }

        public virtual VehicleMake VehicleMake { get; set; }
    }

    [MetadataType(typeof(VehicleModelMetaData))]
    public partial class VehicleModel : AVehicle
    {
    }

    public class VehicleModelMetaData : AVehicleMetaData
    {
        [Required]
        [Display(Name = "Model name")]
        [StringLength(30)]
        public new string Name { get; set; }

        [Required]
        [Display(Name = "Vehicle type")]
        public int MakeId { get; set; }
    }
}

