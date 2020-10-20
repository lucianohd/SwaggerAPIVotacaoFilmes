using System.Data;

namespace Repositories.Spec.Context
{
    public interface ISqlServerConnection
    {
        IDbConnection Open();
    }
}