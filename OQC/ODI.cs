//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OQC
{
    using System;
    using System.Collections.Generic;
    
    public partial class ODI
    {
        public int ID { get; set; }
        public System.DateTime DateOccur { get; set; }
        public string Customer { get; set; }
        public string Shift { get; set; }
        public string Station { get; set; }
        public string Inspector { get; set; }
        public string GroupModel { get; set; }
        public string ModelName { get; set; }
        public string WO { get; set; }
        public int WOQty { get; set; }
        public int CheckNumber { get; set; }
        public int NumberNG { get; set; }
        public string Note { get; set; }
        public string Occur_Time { get; set; }
        public string Occur_Line { get; set; }
        public string Serial_Number { get; set; }
        public string Position { get; set; }
        public string Defection { get; set; }
        public string Detail { get; set; }
        public string NG_Photo { get; set; }
        public string OK_Photo { get; set; }
        public string Area { get; set; }
        public string Sample_Form { get; set; }
        public Nullable<bool> IsConfirm { get; set; }
    }
}
