using System;

namespace aiof.portal.Models
{
    public interface ILiabilityType
    {
        string Name { get; set; }
        Guid PublicKey { get; set; }
    }
}