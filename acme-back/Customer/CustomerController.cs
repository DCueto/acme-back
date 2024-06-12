using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace acme_back.Customer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CustomerDto>>> GetAllCustomers()
        {
            List<Customer> customers = await _customerRepository.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerById(int id)
        {
            Customer customer = await _customerRepository.GetCustomerById(id);
            return Ok(customer);
        }
        
        [HttpPost]
        public async Task<ActionResult<CustomerDto>> CreateCustomer(CreateCustomerDto createCustomerDto)
        {
            var customer = _mapper.Map<Customer>(createCustomerDto);
            await _customerRepository.CreateCustomer(customer);

            return Ok(customer);
        }
        
        [HttpPut("{id:int}")]
        public async Task<ActionResult<CustomerDto>> UpdateCustomer(int id, CreateCustomerDto updateCustomerDto)
        {
            var customer = _mapper.Map<Customer>(updateCustomerDto);
            await _customerRepository.UpdateCustomer(id, customer);
            return Ok(customer);
        }
        
        
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CustomerDto>> DeleteCustomer(int id)
        {
            var customer = await _customerRepository.DeleteCustomer(id);
            return Ok(customer);
        }
    }
}
