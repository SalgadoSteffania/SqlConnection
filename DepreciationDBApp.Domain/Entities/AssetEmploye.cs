using System;
using System.Collections.Generic;

#nullable disable

namespace DepreciationDBApp.Domain.Entities
{
    public partial class AssetEmploye
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public int Employeed { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
    }
}
