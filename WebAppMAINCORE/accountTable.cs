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
    
    public partial class accountTable
    {
        public string IDENTIFIER { get; set; }
        public string ACCOUNT_NAME { get; set; }
        public string ACCOUNT_TYPE { get; set; }
        public string ACCOUNT_STATE { get; set; }
        public decimal BALANCE { get; set; }
        public System.DateTime OPENDATE { get; set; }
    
        public virtual clientTable clientTable { get; set; }
        public virtual clientTable clientTable1 { get; set; }
    }
}
