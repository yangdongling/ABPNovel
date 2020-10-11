using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Sample.Novel.Domain.Author.Entities
{
    public class Author : AggregateRoot<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        protected Author()
        {
        }

        public Author(Guid id, [NotNull] string name,[CanBeNull] string description) : base(id)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
            Description = description;
        }
    }
}