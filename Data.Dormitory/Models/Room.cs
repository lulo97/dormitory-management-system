//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data.Dormitory.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Room
    {
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public string Description { get; set; }
        public int BuildingID { get; set; }
        public Nullable<int> Slot { get; set; }
        public Nullable<int> MaxSlot { get; set; }
        public string Room_Gender { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<System.DateTime> CreatedTime { get; set; }
        public Nullable<System.DateTime> ModifiedTime { get; set; }
        public string CreatedUser { get; set; }
        public string ModifiedUser { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
