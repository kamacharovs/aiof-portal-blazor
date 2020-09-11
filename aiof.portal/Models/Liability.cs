using System;

namespace aiof.portal.Models
{
    public class Liability : ILiability
    {
        public int Id { get; set; }
        public Guid PublicKey { get; set; }
        public string Name { get; set; }
        public string TypeName { get; set; }
        public LiabilityType Type { get; set; }
        public decimal Value { get; set; }
        public int? UserId { get; set; }
    }
}