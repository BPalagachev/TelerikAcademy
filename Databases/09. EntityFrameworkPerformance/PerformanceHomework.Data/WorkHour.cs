//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PerformanceHomework.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class WorkHour
    {
        public int WorkHourID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Task { get; set; }
        public Nullable<int> Hours { get; set; }
        public Nullable<int> EmployeeID { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
