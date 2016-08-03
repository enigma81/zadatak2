using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace Project.Service
{
    public class VehicleModel : AVehicle
    {
        private int _makeId;

        [Required]
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
}

