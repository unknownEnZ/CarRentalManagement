using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRentalManagement.Server.Data;
using CarRentalManagement.Shared.Domain;
using Microsoft.Identity.Client;
using CarRentalManagement.Server.IRepository;

namespace CarRentalManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;

        //public CustomersController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}


        private readonly IUnitOfWork _unitOfWork;

        public CustomersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;


        }



        //// GET: api/Customers
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        //{
        //  if (_context.Customers == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.Customers.ToListAsync();
        //}

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var Customers = await _unitOfWork.Customers.GetAll();
            return Ok(Customers);
        }


        //// GET: api/Customers/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Customer>> GetCustomer(int id)
        //{
        //  if (_context.Customers == null)
        //  {
        //      return NotFound();
        //  }
        //    var Customer = await _context.Customers.FindAsync(id);

        //    if (Customer == null)
        //    {
        //        return NotFound();
        //    }

        //    return Customer;
        //}

        [HttpGet("{id}")]

        public async Task<IActionResult> GetCustomer(int id)
        {
            var Customer = await _unitOfWork.Customers.Get(q => q.Id == id);

            if (Customer == null)
            {
                return NotFound();
            }

            return Ok(Customer);

        }




        //// PUT: api/Customers/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCustomer(int id, Customer Customer)
        //{
        //    if (id != Customer.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(Customer).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CustomerExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}


        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer Customer)
        {
            if (id != Customer.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            _unitOfWork.Customers.Update(Customer);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }



        //// POST: api/Customers
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Customer>> PostCustomer(Customer Customer)
        //{
        //  if (_context.Customers == null)
        //  {
        //      return Problem("Entity set 'ApplicationDbContext.Customers'  is null.");
        //  }
        //    _context.Customers.Add(Customer);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCustomer", new { id = Customer.Id }, Customer);
        //}


        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer Customer)
        {
            await _unitOfWork.Customers.Insert(Customer);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetCustomer", new { id = Customer.Id }, Customer);
        }







        //// DELETE: api/Customers/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCustomer(int id)
        //{
        //    if (_context.Customers == null)
        //    {
        //        return NotFound();
        //    }
        //    var Customer = await _context.Customers.FindAsync(id);
        //    if (Customer == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Customers.Remove(Customer);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var Customer = await _unitOfWork.Customers.Get(q => q.Id == id);
            if (Customer == null)
            {
                return NotFound();

            }

            await _unitOfWork.Customers.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }



        //private bool CustomerExists(int id)
        //{
        //    return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        //}

        private async Task<bool> CustomerExists(int id)
        {
            var Customer = await _unitOfWork.Customers.Get(q => q.Id == id);
            return Customer != null;
        }
    }
}

