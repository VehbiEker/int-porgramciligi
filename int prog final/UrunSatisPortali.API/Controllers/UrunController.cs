using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UrunSatisPortali.Dtos;
using UrunSatisPortali.Models;
using Microsoft.AspNetCore.Authorization;
using UrunSatiSPortali.Models;

namespace UrunSatisPortali.Controllers
{
    [Route("api/Urun")]
    [ApiController]
    public class UrunController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        ResultDto result = new ResultDto();
        public UrunController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<UrunDto> GetList()
        {
            var urun = _context.Urun.ToList();
            var urunDtos = _mapper.Map<List<UrunDto>>(urun);
            return urunDtos;
        }


        [HttpGet]
        [Route("{id}")]
        public UrunDto Get(int id)
        {
            var urun = _context.Urun.Where(s => s.Id == id).SingleOrDefault();
            var urunDto = _mapper.Map<UrunDto>(urun);
            return urunDto;
        }

        [HttpPost]
        public ResultDto Post(UrunDto dto)
        {
            if (_context.Urun.Count(c => c.Name == dto.Name) > 0)
            {
                result.Status = false;
                result.Message = "Girilen Ürün Adı Kayıtlıdır!";
                return result;
            }
            var urun = _mapper.Map<Urun>(dto);
            urun.Updated = DateTime.Now;
            urun.Created = DateTime.Now;
            _context.Urun.Add(urun);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Ürün Eklendi";
            return result;
        }


        [HttpPut]
        public ResultDto Put(UrunDto dto)
        {
            var urun = _context.Urun.Where(s => s.Id == dto.Id).SingleOrDefault();
            if (urun == null)
            {
                result.Status = false;
                result.Message = "Ürün Bulunamadı!";
                return result;
            }
            urun.Name = dto.Name;
            urun.IsActive = dto.IsActive;
            urun.Fiyat = dto.Fiyat;
            urun.Updated = DateTime.Now;
            urun.CategoryId = dto.CategoryId;
            _context.Urun.Update(urun);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Ürün Düzenlendi";
            return result;
        }


        [HttpDelete]
        [Route("{id}")]
        public ResultDto Delete(int id)
        {
            var urun = _context.Urun.Where(s => s.Id == id).SingleOrDefault();
            if (urun == null)
            {
                result.Status = false;
                result.Message = "Ürün Bulunamadı!";
                return result;
            }
            _context.Urun.Remove(urun);
            _context.SaveChanges();
            result.Status = true;
            result.Message = "Ürün Silindi";
            return result;
        }
    }
}
