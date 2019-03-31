using ChemApp.Domain.Abstract;
using System;

namespace ChemApp.Domain.Concrete
{
    public abstract class BaseEntity : IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime? TimeModified { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public byte[] Version { get; set; }
    }
}