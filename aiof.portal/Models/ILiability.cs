using System;

namespace aiof.portal.Models
{
    public interface ILiability
    {
        int Id { get; set; }
        Guid PublicKey { get; set; }
        string Name { get; set; }
        string TypeName { get; set; }
        LiabilityType Type { get; set; }
        decimal Value { get; set; }
        int? UserId { get; set; }
    }
}