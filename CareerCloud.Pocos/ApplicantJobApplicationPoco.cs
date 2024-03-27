using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Job_Applications")]
    public class ApplicantJobApplicationPoco : IPoco
    {
        [Column("Application_Date")]
        public DateTime ApplicationDate { get; set; }

        [Column("Time_Stamp")]
        [NotMapped]
        public byte[] TimeStamp { get; set; }

        [Key]
        public Guid Id { get ; set ; }

        [Key]
        public Guid Applicant { get; set; }

        [Key]
        public Guid Job { get; set; }


        //child
        public virtual ApplicantProfilePoco ApplicantProfile { get; set; }

        public virtual CompanyJobPoco CompanyJob { get; set; }
    }
}
