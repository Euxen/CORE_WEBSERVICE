//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAppMAINCORE
{
    using System;
    using System.Collections.Generic;
    
    public partial class clientTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public clientTable()
        {
            this.accountTables = new HashSet<accountTable>();
            this.accountTables1 = new HashSet<accountTable>();
        }
    
        public string IDENTIFIER { get; set; }
        public string NAME { get; set; }
        public string LAST { get; set; }
        public int ACCOUNTS { get; set; }
        public string PASSWORD { get; set; }
        public string PIN { get; set; }
        public string DIRECTION { get; set; }
        public string EMAIL { get; set; }
        public string STATE { get; set; }
        public System.DateTime REGDATE { get; set; }
        public Nullable<System.DateTime> LOGDATE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<accountTable> accountTables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<accountTable> accountTables1 { get; set; }
    }
}
