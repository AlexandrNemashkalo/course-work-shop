using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Repositories
{
    public interface ILikeRepository
    {
        Task<Like> CreateAsync(Like item);
        Task<bool> UpdateAsync(Like item);
        Task<List<Like>> GetLikesByReviewAsync(Guid id);

    }
}
