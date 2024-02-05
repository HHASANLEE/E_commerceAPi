using E_commerceAPi.Dtoes;

namespace E_commerceAPi.Interfaces
{
    public interface IProductReport
    {
        public Task<ProductReportGetDto> GetByIdAsync(int id);
        public Task<ProductGetDto> GetByIdAsync(ProductPostDto id);
        public Task<List<ProductReportGetDto>> GetAsync();
        public Task<List<ProductReportGetDto>> GetAllAsync();
        public Task<ProductReportGetDto> PostAsync(ProductReportPostDto dto);
        public Task<ProductReportGetDto> PutAsync(ProductReportPostDto dto);
        public Task<bool> DeleteFakeAsync(int id);
        public Task<bool> DeleteAsync(int id);
    }
}
