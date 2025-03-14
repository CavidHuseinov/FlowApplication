using Flow.Core.Entities;
using Flow.DAL.Context;
using Flow.DAL.Repositories.Implementations;
using Flow.DAL.Repository.Interfaces;

namespace Flow.DAL.Repository.Implementations
{
    public class SocialMediaRepository : WriteRepository<SocialMedia>, ISocialMediaRepository
    {
        public SocialMediaRepository(FlowDbContext context) : base(context)
        {
        }
    }
}
