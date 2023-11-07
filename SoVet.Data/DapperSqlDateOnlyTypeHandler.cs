using System.Data;
using Dapper;

namespace SoVet.Data;

public class DapperSqlDateOnlyTypeHandler : SqlMapper.TypeHandler<DateOnly>
{
    public override void SetValue(IDbDataParameter parameter, DateOnly date)
    {
        parameter.Value = date.ToDateTime(TimeOnly.MinValue);
    }
    
    public override DateOnly Parse(object value)
        => DateOnly.FromDateTime((DateTime)value);
}