using System.Linq.Expressions;
using MH.Domain.Constant;

namespace MH.Application.Exception;

public class DomainException : System.Exception
{
    protected DomainException(string msg) : base(msg)
        => Expression.Empty();

    public virtual int ToHttpStatusCode() 
        => AppStatusCode.BadRequestStatusCode;
}