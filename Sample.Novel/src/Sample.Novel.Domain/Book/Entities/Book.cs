using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Sample.Novel.Domain.Book.Entities
{
    public class Book : AggregateRoot<Guid>, IHasCreationTime
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        
        // 和book中 Volumes对应的约定写法，这样仓储服务能知道，它是book的子表
        public List<Volume> Volumes { get; protected set; }
        
        
        public DateTime CreationTime { get; set; }

        // 默认无参数的构造器给ABP使用
        protected Book()
        {
        }

        public Book(Guid id,
            [System.Diagnostics.CodeAnalysis.NotNull]
            string name,
            [System.Diagnostics.CodeAnalysis.NotNull]
            string description,
            Guid authorId,
            [System.Diagnostics.CodeAnalysis.NotNull]
            string authorName,
            Guid categoryId,
            [System.Diagnostics.CodeAnalysis.NotNull]
            string categoryName) : base(id)
        {
            Name = name;
            Description = description;
            AuthorId = authorId;
            AuthorName = authorName;
            CategoryId = categoryId;
            CategoryName = categoryName;

            Volumes = new List<Volume>();
        }

        // 实体命令
        public void AddVolume(Volume volume)
        {
            if(Volumes.Any(v=>v.Title== volume.Title))
                return;
            
            
            Volumes.Add(volume);
        }
    }
}