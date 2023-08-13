using AutoMapper;
using MH.Application.IService;
using MH.Domain.DBModel;
using MH.Domain.IRepository;
using MH.Domain.Model;
using MH.Domain.UnitOfWork;
using MH.Domain.ViewModel;
using MH.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;


namespace MH.Application.Service;

public class OtpService : IOtpService
{
    private readonly IOtpRepository _otpRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ApplicationDbContext _dbContext;

    public OtpService(IOtpRepository otpRepository, IMapper mapper, IUnitOfWork unitOfWork, ApplicationDbContext dbContext)
    {
        _otpRepository = otpRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _dbContext = dbContext;
    }

    public async Task<OtpViewModel> GetByMobileNo(string mobileNo)
    {
        var otp = await _dbContext
            .Otp
            .Where(otpFilter => otpFilter.MobileNo == mobileNo)
            .OrderByDescending(otpFilter => otpFilter.Id)
            .FirstOrDefaultAsync();
        return _mapper.Map<OtpViewModel>(otp);
    }

    public async Task Add(OtpModel otp)
    {
        var data = _mapper.Map<Otp>(otp);
        await _unitOfWork.OtpRepository.Insert(data);
        await _unitOfWork.CommitAsync();
    }

        
    public async Task<OtpViewModel> GetById(int id)
    {
        var data = await _unitOfWork
            .OtpRepository
            .FindBy(otp => otp.Id == id);
        var result = _mapper.Map<OtpViewModel>(data);
        return result;
    }
}