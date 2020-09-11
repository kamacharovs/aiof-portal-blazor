using System;

namespace aiof.portal.Models
{
    public class LiabilityType : ILiabilityType
    {
        public string Name { get; set; }
        public Guid PublicKey { get; set; }
    }
}