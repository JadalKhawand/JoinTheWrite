﻿using AutoMapper;
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
                .ForMember(dest => dest.ModifiedAt, opt => opt.Ignore()) // Ignore, system will set it
                .ForMember(dest => dest.Status, opt => opt.Ignore()) // Set system default (e.g., Draft)
                .ForMember(dest => dest.AuthorId, opt => opt.Ignore()) // Set in controller based on logged-in user
                .ForMember(dest => dest.Contributions, opt => opt.Ignore()) // Contributions will be handled later
                .ForMember(dest => dest.Comments, opt => opt.Ignore()); // Comments are empty at first

            CreateMap<Creation, CreationDto>();

            CreateMap<Chapter, ChapterDto>()
                .ForMember(dest => dest.FinalizedContent, opt => opt.MapFrom(src =>
                    src.Contributions.FirstOrDefault(c => c.ContributionId == src.FinalizedContributionId).Content));

            CreateMap<ChapterDto, Chapter>()
                .ForMember(dest => dest.Contributions, opt => opt.Ignore()) // not needed from DTO
                .ForMember(dest => dest.Creation, opt => opt.Ignore())      // avoid circular mapping
                .ForMember(dest => dest.FinalizedContributionId, opt => opt.Ignore()) // since DTO has content not ID
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())     // managed by system
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
        }
    }
}
