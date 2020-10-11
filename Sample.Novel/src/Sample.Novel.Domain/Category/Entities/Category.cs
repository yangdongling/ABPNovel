using System;
using System.Diagnostics.CodeAnalysis;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Sample.Novel.Domain.Category.Entities
{
    public class Category : AggregateRoot<Guid>
    {
        public string Name { get; set; }

        protected Category()
        {
        }

        public Category(Guid id, [NotNull] string name) : base(id)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        }
    }
}