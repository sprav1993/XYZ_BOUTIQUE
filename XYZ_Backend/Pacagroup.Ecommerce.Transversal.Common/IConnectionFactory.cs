using System.Data;

namespace XYZ.BOUTIQUE.Transversal.Common
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
