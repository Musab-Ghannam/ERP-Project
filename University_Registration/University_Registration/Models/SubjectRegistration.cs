//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace University_Registration.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SubjectRegistration
    {
        public int SubjectRegistrations_ID { get; set; }
        public Nullable<int> Student_ID { get; set; }
        public Nullable<int> Subject_ID { get; set; }
        public Nullable<bool> PaymentStatus { get; set; }
        public Nullable<int> Section_ID { get; set; }
        public Nullable<int> Price { get; set; }
    
        public virtual Section Section { get; set; }
        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
