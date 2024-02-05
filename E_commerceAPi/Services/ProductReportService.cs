using AutoMapper;
using System.Data.SqlTypes;

namespace E_commerceAPi.Services
{
    public class CourseReportService : IProductReport
        {
            private readonly ProductDbContext _db;
            private readonly IMapper _mapper;
            private readonly ILogger _log;
            public ProductReportService(ProductDbContext db, IMapper mapper)
            {
                _db = db;
                _mapper = mapper;
            }

            private async Task<List<Product_Report>> PrivateGet()
            {
                try
                {
                    var data = await _db.Product_Reports.ToListAsync();
                    return data;
                }
                catch (Exception ex)
                {
                    _log.LogInformation(ex, ex.Message);
                    return null;
                }

            }



            private async Task<Product_Report> PrivateGetById(int id)
            {
                try
                {
                    var data = await _db.Product_Reports.FirstOrDefaultAsync(c => c.Id == id);
                    return data;
                }
                catch (Exception ex)
                {
                    _log.LogError(ex, ex.Message);
                    return null;
                }
            }




            public async Task<bool> DeleteAsync(int id)
            {
                try
                {
                    var data = await PrivateGetById(id);
                    if (data != null)
                    {
                        _db.Product_Reports.Remove(data);
                        await _db.SaveChangesAsync();
                        return true;
                    }
                    else
                        throw new SqlNullValueException();
                }
                catch (Exception ex)
                {
                    _log.LogError(ex, ex.Message);
                    return false;
                }
            }

            public async Task<bool> DeleteFakeAsync(int id)
            {
                try
                {
                    var data = await PrivateGetById(id);
                    if (data != null)
                    {
                        data.State = "IsDelete";
                        await _db.SaveChangesAsync();
                        return true;
                    }
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    _log.LogError(ex, ex.Message);
                    return false;
                }
            }

            public async Task<List<ProductReportGetDto>> GetAsync()
            {
                try
                {
                    var data = await PrivateGet();
                    List<ProductReportGetDto> response = new();
                    _mapper.Map(data, response);
                    return response;
                }
                catch (Exception ex)
                {
                    _log.LogError(ex, ex.Message);
                    return null;
                }
            }

            public async Task<ProductReportGetDto> GetByIdAsync(int id)
            {
                try
                {
                    var data = await PrivateGetById(id);
                    ProductReportGetDto response = new();
                    _mapper.Map(data, response);
                    return response;
                }
                catch (Exception ex)
                {
                    _log.LogError(ex, ex.Message);
                    return null;
                }
            }

            public async Task<ProductReportGetDto> PostAsync(ProductReportPostDto dto)
            {
                try
                {
                    Product_Report request = new();
                    _mapper.Map(dto, request);
                    _db.Course_Reports.Add(request);
                    await _db.SaveChangesAsync();

                    ProductReportGetDto response = new();
                    _mapper.Map(dto, response);
                    return response;
                }
                catch (Exception ex)
                {
                    _log.LogError(ex, ex.Message);
                    return null;
                }

            }

            public async Task<ProductReportGetDto> PutAsync(ProductReportPostDto dto)
            {
                try
                {
                    var data = await PrivateGetById(dto.Id);
                    if (data != null)
                    {
                        _mapper.Map(dto, data);
                        await _db.SaveChangesAsync();
                    }
                    else
                        throw new Exception();

                    ProductReportGetDto response = new();
                    _mapper.Map(dto, response);
                    return response;
                }
                catch (Exception ex)
                {
                    _log.LogError(ex, ex.Message);
                    return null;
                }
            }

            public async Task<List<ProductReportGetDto>> GetAllAsync()
            {

                try
                {
                    var data = await _db.Product_Reports.ToListAsync();
                    List<ProductReportGetDto> response = new();
                    _mapper.Map(data, response);
                    return response;
                }
                catch (Exception ex)
                {
                    _log.LogError(ex, ex.Message);
                    return null;
                }
            }
    }
}
