using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Base;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Staff")]
    public class BuyerController : BaseController<Buyer, BuyerRepository, int>
    {
        BuyerRepository buyerRepositor;

        public BuyerController(BuyerRepository buyerRepository) : base(buyerRepository)
        {
            this.buyerRepositor = buyerRepository;
        }
    }
}
