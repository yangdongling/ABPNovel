using AutoMapper;
using Sample.Novel.Application.Contracts.Dtos.Author;
using Sample.Novel.Domain.Author.Entities;
using Volo.Abp.AutoMapper;

namespace Sample.Novel.Application.Profiles
{
    public class AuthorProfile: Profile
    {
        public AuthorProfile()
        {
            CreateMap<CreateAuthorInput, Author>()
                .Ignore(author => author.Id)
                .Ignore(author => author.ConcurrencyStamp)
                .Ignore(author => author.ExtraProperties);

            CreateMap<Author, AuthorDto>();
        }
    }
}