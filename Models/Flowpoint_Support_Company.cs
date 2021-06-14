using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_FP.Models
{
    public class Flowpoint_Support_Company
    {
        [Key]
        public int ICompanyID { get; set; }

        [Required(ErrorMessage = "Company Name is Required")]
        [StringLength(64, ErrorMessage = " The {0} cannot exceed {1} characters.")]
        public string VCompanyName { get; set; }

        [Required(ErrorMessage = "Street1 is Required")]
        [StringLength(128, ErrorMessage = " The {0} cannot exceed {1} characters.")]
        public string VStreet1 { get; set; }

        [StringLength(128, ErrorMessage = " The {0} cannot exceed {1} characters.")]
        public string VStreet2 { get; set; }

        [StringLength(128, ErrorMessage = " The {0} cannot exceed {1} characters.")]
        public string VCity { get; set; }

        [StringLength(50, ErrorMessage = " The {0} cannot exceed {1} characters.")]
        public string VProvince { get; set; }

        [StringLength(32, ErrorMessage = " The {0} cannot exceed {1} characters.")]
        public string VPostalCode { get; set; }

        [StringLength(50, ErrorMessage = " The {0} cannot exceed {1} characters.")]
        public string VCountry { get; set; }

        [StringLength(64, ErrorMessage = " The {0} cannot exceed {1} characters.")]
        public string VContact { get; set; }

        [StringLength(50, ErrorMessage = " The {0} cannot exceed {1} characters.")]
        public string VPhone { get; set; }

        [StringLength(50, ErrorMessage = " The {0} cannot exceed {1} characters.")]
        public string VFax { get; set; }

        [StringLength(50, ErrorMessage = " The {0} cannot exceed {1} characters.")]
        public string VEmail { get; set; }

        public DateTime? DtCreated { get; set; }

        [Required(ErrorMessage = "blsActive is Required")]
        public bool BlsActive { get; set; }

        public ICollection<Flowpoint_Support_Vendor> Flowpoint_Support_Vendors { get; set; }
    }
}
