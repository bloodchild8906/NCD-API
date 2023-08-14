using AutoMapper;
using MH.Application.IService;
using MH.Domain.DBModel;
using MH.Domain.Dto;
using MH.Domain.IRepository;
using MH.Domain.Model;
using MH.Domain.UnitOfWork;

namespace MH.Application.Service;

public class ContactDetailsService : IContactDetailsService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserProfileRepository _userProfileRepository;

    public ContactDetailsService(IMapper mapper, IUnitOfWork unitOfWork, IUserProfileRepository userProfileRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _userProfileRepository = userProfileRepository;
    }

    public async Task Add(ContactDetailsModel contactDetails)
    {
        var userProfile = await _userProfileRepository
            .FindBy(profile => profile.UserId == contactDetails.Userid);
        var data = _mapper.Map<ContactDetails>(contactDetails);
        data.UserProfileId = userProfile.Id;
        await _unitOfWork.ContactDetailsRepository.Insert(data);
        await _unitOfWork.CommitAsync();
    }

    public async Task<List<ContactDetail>> GetAll()
    {
        var data = await _unitOfWork.ContactDetailsRepository
            .GetAll(details => !details.IsDeleted,
                include => include.UserProfile,
                include => include.ContactDataType,
                include => include.ContactType,
                include => include.ContactEntity);
        var result = _mapper.Map<List<ContactDetail>>(data);
        return result.OrderByDescending(detailsViewModel => detailsViewModel.DateCreated).ToList();
    }

    public async Task<ContactDetail> GetByUserId(int userId)
    {
        var data = await _unitOfWork.ContactDetailsRepository.FindBy(
            x => !x.IsDeleted && x.UserProfile.UserId == userId,
            include => include.UserProfile,
            include => include.ContactDataType,
            include => include.ContactType,
            include => include.ContactEntity
        );
        var result = _mapper.Map<ContactDetail>(data);
        return result;
    }

    public async Task Update(ContactDetailsModel contactDetails)
    {
        var existingData = await _unitOfWork
            .ContactDetailsRepository
            .FindBy(details => details.UserProfile.UserId == contactDetails.Userid && !details.IsDeleted,
                details => details.UserProfile);
        existingData.Name = contactDetails.Name;
        existingData.ContactTypeId = contactDetails.ContactTypeId;
        existingData.ContactDataTypeId = contactDetails.ContactDataTypeId;
        existingData.ContactEntityId = contactDetails.ContactEntityId;
        existingData.Data = contactDetails.Data;

        await _unitOfWork.ContactDetailsRepository.Update(existingData);
        await _unitOfWork.CommitAsync();
    }

    public async Task Delete(int id)
    {
        var existingData = await _unitOfWork
            .ContactDetailsRepository
            .FindBy(details => details.Id == id && !details.IsDeleted);
        existingData.IsDeleted = true;
        await _unitOfWork.ContactDetailsRepository.Update(existingData);
        await _unitOfWork.CommitAsync();
    }
}