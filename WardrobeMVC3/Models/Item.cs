//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WardrobeMVC3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Item
    {
        public Item()
        {
            this.Wardrobes = new HashSet<Wardrobe>();
        }
    

        [Display (Name ="Items")]
        public int ItemsID { get; set; }

        [Display (Name ="Item")]
        public string Item1 { get; set; }
    
        public virtual ICollection<Wardrobe> Wardrobes { get; set; }
    }
}