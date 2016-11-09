//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SandwichSwap
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sandwich
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sandwich()
        {
            this.Toppings = new HashSet<Topping>();
            this.Users = new HashSet<User>();
        }
    
        public int Id { get; set; }
        public string username { get; set; }
        public string sandwichname { get; set; }
        public int BreadId { get; set; }
        public int votes { get; set; }
    
        public virtual Bread Bread { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Topping> Toppings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }
}
