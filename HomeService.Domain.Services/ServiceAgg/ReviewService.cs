using AutoMapper;
using HomeService.Domain.Core.ServiceAgg.Data;
using HomeService.Domain.Core.ServiceAgg.DTOs;
using HomeService.Domain.Core.ServiceAgg.Entities;
using HomeService.Domain.Core.ServiceAgg.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Services.ServiceAgg
{
    public class ReviewService : IReviewService
    {
        private readonly IMapper _mapper;
        private readonly IReviewRepository _reviewRepository;
        private readonly IMemoryCache _cache;
        private readonly ILogger<ReviewService> _logger;

        public ReviewService(IMapper mapper, IReviewRepository reviewRepository, IMemoryCache cache, ILogger<ReviewService> logger)
        {
            _mapper = mapper;
            _reviewRepository = reviewRepository;
            _cache = cache;
            _logger = logger;
        }

        public async Task<IEnumerable<ReviewDTO>> GetAllReviewsAsync()
        {
            if (!_cache.TryGetValue("AllReviews", out IEnumerable<ReviewDTO> cachedReviews))
            {
                var reviews = await _reviewRepository.GetAllAsync();
                cachedReviews = _mapper.Map<IEnumerable<ReviewDTO>>(reviews);
                _cache.Set("AllReviews", cachedReviews);
            }

            _logger.LogInformation("Retrieved all reviews from cache");
            return cachedReviews;
        }

        public async Task<ReviewDTO> GetReviewByIdAsync(int id)
        {
            var review = await _reviewRepository.GetByIdAsync(id);
            if (review == null)
            {
                _logger.LogWarning("Review not found: {Id}", id);
                throw new KeyNotFoundException("Review not found.");
            }

            _logger.LogInformation("Retrieved review by id: {Id}", id);
            return _mapper.Map<ReviewDTO>(review);
        }

        public async Task AddReviewAsync(ReviewDTO reviewDto)
        {
            var review = _mapper.Map<Review>(reviewDto);
            await _reviewRepository.AddAsync(review);
            _logger.LogInformation("Review added: {@Review}", review);
            _cache.Remove("AllReviews");
        }

        public async Task UpdateReviewAsync(ReviewDTO reviewDto)
        {
            var review = _mapper.Map<Review>(reviewDto);
            await _reviewRepository.UpdateAsync(review);
            _logger.LogInformation("Review updated: {@Review}", review);
            _cache.Remove("AllReviews");
        }

        public async Task DeleteReviewAsync(int id)
        {
            await _reviewRepository.DeleteAsync(id);
            _logger.LogInformation("Review deleted: {Id}", id);
            _cache.Remove("AllReviews");
        }
    }
}
