using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Sample.Novel.Domain.Book.Entities
{
    public class Volume : Entity<Guid>, IHasCreationTime
    {
        // 和book中 Volumes对应的约定写法，这样仓储服务能知道，它是book的子表
        public virtual Book Book { get; set; }
        public Guid BookId { get; set; }
        
        
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual List<Chapter> Chapters { get; protected set; }

        public DateTime CreationTime { get; set; }

        protected Volume()
        {
        }

        public Volume([System.Diagnostics.CodeAnalysis.NotNull]
            string title, [CanBeNull] string description)
        {
            Title = Check.NotNullOrWhiteSpace(title, nameof(title));
            Description = description;
            Chapters= new List<Chapter>();
        }

        public void AddChapters(Chapter chapter)
        {
            if(Chapters.Any(c=>c.Title== chapter.Title))
                return;
            
            Chapters.Add(chapter);
        }
    }
}