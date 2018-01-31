using System.Threading.Tasks;

namespace XF.Atividade6.Infrastructure
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate();
    }
}
