using System;

namespace ChemApp.Domain.Abstract
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
        DateTime TimeCreated { get; set; }
        DateTime? TimeModified { get; set; }
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
        byte[] Version { get; set; }
    }
}