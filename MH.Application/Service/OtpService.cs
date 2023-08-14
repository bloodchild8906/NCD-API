using AutoMapper;
using MH.Application.IService;
using MH.Domain.Dto;
using MH.Domain.IRepository;
using MH.Domain.Model;
using MH.Domain.UnitOfWork;
using MH.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace MH.Application.Service;

public class OtpService : IOtpService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IOtpRepository _otpRepository;
    private readonly IUnitOfWork _unitOfWork;

    public OtpService(IOtpRepository otpRepository, IMapper mapper, IUnitOfWork unitOfWork,
        ApplicationDbContext dbContext)
    {
        _otpRepository = otpRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _dbContext = dbContext;
    }

    public async Task<Otp> GetByMobileNo(string mobileNo)
    {
        var otp = await _dbContext
            .Otp
            .Where(otpFilter => otpFilter.MobileNo == mobileNo)
            .OrderByDescending(otpFilter => otpFilter.Id)
            .FirstOrDefaultAsync();
        return _mapper.Map<Otp>(otp);
    }

    public async Task Add(OtpModel otp)
    {
        var data = _mapper.Map<Domain.DBModel.Otp>(otp);
        await _unitOfWork.OtpRepository.Insert(data);
        await _unitOfWork.CommitAsync();
    }


    public async Task<Otp> GetById(int id)
    {
        var data = await _unitOfWork
            .OtpRepository
            .FindBy(otp => otp.Id == id);
        var result = _mapper.Map<Otp>(data);
        return result;
    }
}