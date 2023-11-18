using MediatR;
using SoVet.Data.Repositories;
using SoVet.Domain.Commands.Facility;
using SoVet.Domain.Responses;

namespace SoVet.Data.Handlers.Facility;

public sealed class DeleteFacilityCommandHandler : IRequestHandler<DeleteFacilityCommand, BaseResponse>
{
    private readonly IFacilityRepository _repository;

    public DeleteFacilityCommandHandler(IFacilityRepository repository)
    {
        _repository = repository;
    }

    public async Task<BaseResponse> Handle(DeleteFacilityCommand request, CancellationToken cancellationToken)
    {
        return await _repository.DeleteFacilityInAppointmentAsync(request.AppointmentFacilityId);
    }
}