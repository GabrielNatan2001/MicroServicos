using AutoMapper;
using MicroServicos.ProductAPI.Data.ValueObjects;
using MicroServicos.ProductAPI.Model;
using MicroServicos.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace MicroServicos.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            var products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductVO>>(products);
        }

        public async Task<ProductVO> FindById(long id)
        {
            var product = await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<ProductVO> Create(ProductVO vo)
        {
            var entity = _mapper.Map<Product>(vo);
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(entity);
        }

        public async Task<ProductVO> Update(ProductVO vo)
        {
            var entity = _mapper.Map<Product>(vo);
             _context.Update(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(entity);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                var product = await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (product == null)
                    return false;

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
