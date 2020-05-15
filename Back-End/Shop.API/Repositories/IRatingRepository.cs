using Shop.Domain.Dto;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Repositories
{
    public interface IRatingRepository
    {
        Task<RatingDto> CreateAsync(Rating item);
        Task<RatingDto> UpdateAsync(Rating item);
        Task<List<RatingDto>> GetRatingsByItemAsync(Guid id);
        Task<List<RatingDto>> GetRatingsByUserAsync(Guid id);
        Task<List<RatingDto>> GetAllRatingsAsync();
        Task<bool> DeleteAsync(Guid id);
        //Task<List<Rating>> GetRatingsByItem

    }
}
