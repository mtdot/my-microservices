using System;

namespace AccountService.Repository.Models
{
    public abstract class EntityBase<TKey> where TKey : IEquatable<TKey>
    {
        public TKey Id { get; set; }
    }

    public class EntityBase : EntityBase<Guid>
    {
        
    }
}