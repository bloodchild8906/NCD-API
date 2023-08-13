using System.Linq.Expressions;

namespace MH.Application.Exception;

public class RecordNotFound : DomainException
{
    public RecordNotFound(string msg = "The record you are trying to update is not found") : base(msg)
        => Expression.Empty();

}