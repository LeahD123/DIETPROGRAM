using DietP.Core.Entities;
using DietP.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DietP.Infrastructure.DataRepository
{

    public partial class DataRepository : IDataRepository
    {
        private readonly DietContext _dbContext;

        public DataRepository(DietContext dbContext)
        {
            _dbContext = dbContext;
        }
    }



}
