using System;

namespace Project.Entity.Entities
{
    public abstract class BaseEntity<T>:IEntity
    {
       public T Id { get; set; }
       public DateTime Created { get; set; }
       public Guid CreatedBy { get; set; }
       public DateTime Changed { get; set; }
       public Guid ChangedBy { get; set; }
    }
}