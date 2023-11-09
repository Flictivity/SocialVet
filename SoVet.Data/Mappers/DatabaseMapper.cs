﻿using Riok.Mapperly.Abstractions;
using SoVet.Data.Entities;

namespace SoVet.Data.Mappers;

[Mapper]
public sealed partial class DatabaseMapper
{
    public partial Domain.Models.Client Map(Client client) ;
    public partial Client Map(Domain.Models.Client client) ;
    public partial Domain.Models.Clinic Map(Clinic clinic) ;
    public partial Clinic Map(Domain.Models.Clinic clinic) ;
    public partial Employee Map(Domain.Models.Employee employee) ;
    public partial Domain.Models.Employee Map(Employee employee) ;
    public partial Domain.Models.Registration Map(Registration employee) ;
    public partial Registration Map(Domain.Models.Registration employee) ;
}