using AutoMapper;
using JoinTheWrite.Models.Dto;
using JoinTheWrite.Models;

namespace JoinTheWrite.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreationDto, Creation>()
                .ForMember(dest => dest.CreationId, opt => opt.Ignore()) // Let DB generate it if needed
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore()) // Ignore, system will set it
                .ForMember(dest => dest.ModifiedAt, opt => opt.Ignore());// Ignore, system will set it

            CreateMap<Creation, CreationDto>();

            CreateMap<Chapter, ChapterDto>();

            CreateMap<ChapterDto, Chapter>()
                .ForMember(dest => dest.FinalizedContributionId, opt => opt.Ignore()) // not set at creation
                .ForMember(dest => dest.Contributions, opt => opt.Ignore())
                .ForMember(dest => dest.ChapterId, opt => opt.Ignore())
                .ForMember(dest => dest.ChapterNumber, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreationId, opt => opt.Ignore());
            CreateMap<ContributionDto, Contribution>()
                .ForMember(dest => dest.ContributionId, opt => opt.Ignore())
                .ForMember(dest => dest.SubmittedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.Votes, opt => opt.Ignore())
                .ForMember(dest => dest.Chapter, opt => opt.Ignore());
            CreateMap<Contribution, ContributionDto>();
            CreateMap<CommentDto, Comment>();
            CreateMap<Comment, CommentDto>();

        }
    }
}
