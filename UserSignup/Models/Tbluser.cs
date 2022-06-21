//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UserSignup.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Tbluser
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="This field is required")]
        [Display(Name="Username")]
        public string username { get; set; }

       
        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Re-Password")]
        [DataType(DataType.Password)]
        [NotMapped]
        [Compare("Password",ErrorMessage ="Password doesnt match")]
        public string RePassword { get; set; }
    }
}
