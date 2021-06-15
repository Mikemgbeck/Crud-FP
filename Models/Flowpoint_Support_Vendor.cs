using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_FP.Models
{
    public class Flowpoint_Support_Vendor
    {
        [Key]
        public int IVendorID { get; set; }

        [StringLength(64, ErrorMessage = " The {0} value cannot exceed {1} characters ")]
        [Required(ErrorMessage = "Vendor Name is required ")]
        public string VVendorName { get; set; }

        [Required(ErrorMessage = "Street1 is required ")]
        [StringLength(128, ErrorMessage = " The {0} value cannot exceed {1} characters ")]
        public string VStreet1 { get; set; }

        [StringLength(128, ErrorMessage = " The {0} value cannot exceed {1} characters ")]
        public string VStreet2 { get; set; }

        [StringLength(128, ErrorMessage = " The {0} value cannot exceed {1} characters ")]
        public string VCity { get; set; }

        [StringLength(50, ErrorMessage = " The {0} value cannot exceed {1} characters ")]
        public string VProvince { get; set; }

        [StringLength(32, ErrorMessage = " The {0} value cannot exceed {1} characters ")]
        public string VPostalCode { get; set; }

        [StringLength(50, ErrorMessage = " The {0} value cannot exceed {1} characters ")]
        public string VCountry { get; set; }

        [StringLength(64, ErrorMessage = " The {0} value cannot exceed {1} characters ")]
        public string VContact { get; set; }

        [StringLength(50, ErrorMessage = " The {0} value cannot exceed {1} characters ")]
        public string VPhone { get; set; }

        [StringLength(50, ErrorMessage = " The {0} value cannot exceed {1} characters ")]
        public string VFax { get; set; }

        [StringLength(50, ErrorMessage = " The {0} value cannot exceed {1} characters ")]
        public string VEmail { get; set; }

        public DateTime? DtCreated { get; set; }

        [Required(ErrorMessage = "BlsActive is required ")]
        public bool BlsActive { get; set; }
        public int ICompanyID { get; set; }
        
        [ForeignKey("ICompanyID")]
        public virtual Flowpoint_Support_Company Flowpoint_Support_Company { get; set; }
        public ICollection<Flowpoint_Support_Ticket> Flowpoint_Support_Tickets { get; set; }
    }
}
