﻿using JoinTheWrite.Models;
using JoinTheWrite.Models.Dto;

namespace JoinTheWrite.Services.WritingsService.ChapterServices
{
    public interface IChapterService
    {
        Task<List<Chapter>> GetChaptersByCreationIdAsync(Guid creationId);
        Task<Chapter> CreateChapterAsync(Guid creationId);
        Task<bool> IsLastChapterAsync(Guid chapterId);

        Task<Chapter?> GetChapterByIdAsync(Guid chapterId);

    }
}
