namespace Core.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseEntity<TKey> : IModificationInformation
    {
        [Key]
        public TKey Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsModified { get; set; }

        public bool IsDeleted { get; set; }
    }
}
