using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teamber.Models
{
    public class Employee
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of hire")]
        public DateTime EmpTeamDate { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }

        [Required]
        [Column("JobTitle")]
        [Display(Name = "Job title")]
        public string JobTitle { get; set; }

        [Column("PersonalityType")]
        [Display(Name = "Personality type")]
        public string? PersonalityType { get; set; }

        [Required]
        [Column("IsManager")]
        [Display(Name = "Is a Manager")]
        public bool IsManager { get; set; }

        [Required]
        [Column("Username")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Column("Password")]
        [Display(Name = "Password")]
        public string Password { get; set; }


        public ICollection<EmpTeam> EmpTeams { get; set; }
        public ICollection<EmpQuestionnaire> EmpQuestionnaires { get; set; }

        public ICollection<EmployeeCompetence> EmployeeCompetences { get; set; }
    }
}
