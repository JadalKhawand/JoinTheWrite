using JoinTheWrite.Data;
using JoinTheWrite.Models.enums;
using Microsoft.EntityFrameworkCore;

namespace JoinTheWrite.Services.WritingsService.VoteServices
{
    public class VotingFinalizerService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<VotingFinalizerService> _logger;

        public VotingFinalizerService(IServiceProvider serviceProvider, ILogger<VotingFinalizerService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                    var voteService = scope.ServiceProvider.GetRequiredService<IVoteService>();
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<VotingFinalizerService>>();

                    // 🔍 Fetch newest chapter per creation that needs finalizing
                    var chaptersToFinalize = await context.Creations
                        .Select(c => c.Chapters
                            .Where(ch => ch.Status == WritingStatus.Voting && ch.VotingDeadline < DateTime.UtcNow)
                            .OrderByDescending(ch => ch.CreatedAt) // Replace with your timestamp field
                            .FirstOrDefault())
                        .Where(ch => ch != null)
                        .Select(ch => ch.ChapterId)
                        .ToListAsync();

                    foreach (var chapterId in chaptersToFinalize)
                    {
                        try
                        {
                            await voteService.EvaluateVotesAndFinalizeAsync(chapterId);
                            logger.LogInformation($"✅ Finalized voting for chapter {chapterId}");
                        }
                        catch (Exception ex)
                        {
                            logger.LogError(ex, $"❌ Error finalizing voting for chapter {chapterId}");
                        }
                    }
                }

                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken); // ⏱️ Run every 5 min
            }
        }

    }

}
