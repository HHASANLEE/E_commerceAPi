using E_commerceAPi.Dtoes;

namespace E_commerceAPi.Interfaces
{
    public interface IProduct
    {
        public Task<ProductGetDto> GetByNameAsync(string Name);
        public Task<List<ProductGetDto>> GetAsync();
        public Task<List<ProductGetDto>> GetAllAsync();
        public Task<ProductGetDto> PostAsync(ProductPostDto dto);
        public Task<ProductGetDto> PutAsync(ProductPostDto dto);
        public Task<bool> DeleteFakeAsync(string Name);
        public Task<bool> DeleteAsync(string Name);
    }
}
