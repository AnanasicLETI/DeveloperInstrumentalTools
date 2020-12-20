using System.Collections.Generic;
using System.Threading.Tasks;
using RazorWebApplication.Models;

namespace RazorWebApplication.Services
{
    public interface IAdvertsService
    {
        Task<IEnumerable<Adverts>> GetAdverts();
    }
}