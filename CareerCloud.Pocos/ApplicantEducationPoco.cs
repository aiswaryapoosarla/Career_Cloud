﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.Pocos
{
    [Table("Applicant_Educations")]

    public class ApplicantEducationPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Key]
        public Guid Applicant { get; set; }

        [Column("Certificate_Diploma")]
        public string? CertificateDiploma { get; set; }

        [Column("Major")]
        public string? Major { get; set; }

        [Column("Start_Date")]
        public DateTime? StartDate { get; set; }

        [Column("Completion_Date")]
        public DateTime? CompletionDate   { get; set; }

        [Column("Completion_Percent")]
        public byte? CompletionPercent { get; set; }

        [Column("Time_Stamp")]
        [NotMapped]
        public byte[]? TimeStamp { get; set; }


        //child
        public virtual ApplicantProfilePoco ApplicantProfile { get; set; }


    }
}
