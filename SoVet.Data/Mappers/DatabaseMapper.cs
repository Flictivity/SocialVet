using Riok.Mapperly.Abstractions;
using SoVet.Data.Entities;

namespace SoVet.Data.Mappers;

[Mapper]
public sealed partial class DatabaseMapper
{
    public partial Domain.Models.Client Map(Client client) ;
    public partial Client Map(Domain.Models.Client client) ;
    public partial Domain.Models.Clinic Map(Clinic clinic) ;
}