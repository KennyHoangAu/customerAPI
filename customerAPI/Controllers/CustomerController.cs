using Microsoft.AspNetCore.Mvc;
using CustomerService;
using System.Linq;

namespace CustomerService.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private List<Customer> _customers = new List<Customer>() {
      new Customer() {
          Id = 1,
          Name = "International Bicycles A/S",
          Address1 = "Nydamsvej 8",
          Address2 = null,
          PostalCode = 8362,
          City = "Hørning",
          TaxNumber = "DK-75627732"
      },
      new Customer() {
          Id = 2,
          Name = "Kenny",
          Address1 = "Benny 8",
          Address2 = null,
          PostalCode = 3000,
          City = "Chirag",
          TaxNumber = "O'Block"
      }
    };


    private readonly ILogger<CustomerController> _logger;

    public CustomerController(ILogger<CustomerController> logger)
    {
        _logger = logger;
    }


    [HttpGet("GetCustomerById")]
    public Customer Get(int customerId)
    {
        return _customers.Where(c => c.Id == customerId).First();
    }

    [HttpGet("GetAllCustomers")]
    public List<Customer> Get()
    {
        return _customers.ToList();
    }
   
}
