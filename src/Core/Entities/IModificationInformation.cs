namespace Core.Entities
{
    using System;

    public interface IModificationInformation
    {
        DateTime CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }

        DateTime? DeletedOn { get; set; }

        bool IsModified { get; set; }

        bool IsDeleted { get; set; }
    }
}
