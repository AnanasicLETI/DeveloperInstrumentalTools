using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Database.EFCore.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication.EFCore.Controllers
{
    [ApiController]
    [Route("advert")]
    public class AdvertController : ControllerBase
    {
        private ILogger<AdvertController> Logger { get; }
        private IAdvertDataAccess AdvertDataAccess { get; }
        private IMapper Mapper { get;  }
        

        public AdvertController(ILogger<AdvertController> logger, IAdvertDataAccess advertDataAccess, IMapper mapper)
        {
            Logger = logger;
            AdvertDataAccess = advertDataAccess;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Advert>> Get(CancellationToken ct = default)
        {
            this.Logger.LogDebug($"{nameof(AdvertController)}.{nameof(Get)} executed");
            
            return this.Mapper.Map<IEnumerable<Advert>>(await this.AdvertDataAccess.GetAllAsync(ct));
        }
    }
}