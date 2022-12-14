using FrameworksProject.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrameworksProject.Data.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IClubRepository Clubs { get; }
        IEventRepository Events { get; }
        bool Complete();
    }
}
