using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Commands.Facility;
using SoVet.Domain.Responses;

namespace SoVet.Data.Handlers.Facility;

public sealed class SaveFacilityCommandHandler : IRequestHandler<SaveFacilityCommand, BaseResponse>
{
    private readonly IFacilityRepository _repository;

    public SaveFacilityCommandHandler(IFacilityRepository repository)
    {
        _repository = repository;
    }

    public async Task<BaseResponse> Handle(SaveFacilityCommand request, CancellationToken cancellationToken)
    {
        request.Facility.Sum = request.Facility.Facility.Cost * request.Facility.Count * (1 - (decimal)request.Facility.Discount/100); 
        return await _repository.SaveFacilityInAppointmentAsync(request.Facility);
    }
};