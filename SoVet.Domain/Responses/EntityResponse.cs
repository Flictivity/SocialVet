namespace SoVet.Domain.Responses;

public sealed class EntityResponse<TEntity> : BaseResponse
{
    public TEntity Entity { get; set; } = default!;
}