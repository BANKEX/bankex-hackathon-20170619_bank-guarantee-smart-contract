using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankGuranteeHack.Contracts;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BankGuranteeHack.Controllers
{
    [Route("api/[controller]")]
    public class GuaranteeController : Controller
    {
        public BcIntegration.BcAccess bc = new BcIntegration.BcAccess();

        // GET: api/values
        [HttpGet("contract/{contract}")]
        public ContractInfo GetContract(string contract)
        {
            string amount = "3 500 000";
            string description = "Закупка лекарственных препаратов, которые предназначены для назначения пациенту";

            string tx = bc.CreateContract(contract, $"{contract},{description}");

            return new ContractInfo {
                Amount = amount,
                Description = "Закупка лекарственных препаратов, которые предназначены для назначения пациенту",
                Customer = new Customer
                {
                    Inn = "7707089084",
                    Kpp = "770701001",
                    Name = "ДЕПАРТАМЕНТ ЗДРАВООХРАНЕНИЯ ГОРОДА МОСКВЫ"
                },
                Producer = new Producer
                {
                    Inn = "7726311464",
                    Kpp = "774850001",
                    Name = "АО \"Р - Фарм\""
                },
                Tx = tx
            };
        }

        
        [HttpGet("conditions")]
        public List<BankCondition> GetBankConditions()
        {

            return new List<BankCondition> {
                new BankCondition {
                    Id = Guid.NewGuid(),
                    BankName = "ОАО «Сбербанк России»",
                    Commission = "340 000",
                },
                new BankCondition {
                    Id = Guid.NewGuid(),
                    BankName = "ОАО «Альфа-банк»",
                    Commission = "250 000",
                },
                new BankCondition {
                    Id = Guid.NewGuid(),
                    BankName = "АО КБ «Модульбанк»",
                    Commission = "200 000",
                },
            };
        }

        [HttpPost("setbank/{bankId}")]
        public Guid SetBank(Guid bankId)
        {
            return Guid.NewGuid();
        }

        [HttpGet("pay/{applicationId}")]
        public string Pay(Guid applicationId)
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
