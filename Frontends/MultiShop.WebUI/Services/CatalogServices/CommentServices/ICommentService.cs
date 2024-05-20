using MultiShop.DtoLayer.CommentDtos;

namespace MultiShop.WebUI.Services.CatalogServices.CommentServices
{
    public interface ICommentService
    {
        Task<List<ResultCommentDto>> GetCommentAllAsync();
        Task<List<ResultCommentGetByProductIdDto>> CommentListByProductIdAsync(string id);
        Task CreateCommentAsync(CreateCommentDto createCommentDto);
        Task UpdateCommentAsync(UpdateCommentDto updateCommentDto);
        Task DeleteCommentAsync(int id);
        Task<ResultCommentGetByIdDto> GetByIdCommentAsync(string id);

        Task<int> GetTotalCommentCount();
        Task<int> GetActiveCommentCount();
        Task<int> GetPassiveCommentCount();
    }
}
