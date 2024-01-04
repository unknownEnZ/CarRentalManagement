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
    public class MakesController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;

        //public MakesController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}


        private readonly IUnitOfWork _unitOfWork;

        public MakesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;


        }



        //// GET: api/Makes
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Make>>> GetMakes()
        //{
        //  if (_context.Makes == null)
        //  {
        //      return NotFound();
        //  }
        //    return await _context.Makes.ToListAsync();
        //}

        [HttpGet]
        public async Task<IActionResult> GetMakes()
        {
            var makes = await _unitOfWork.Makes.GetAll();
            return Ok(makes);
        }


        //// GET: api/Makes/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Make>> GetMake(int id)
        //{
        //  if (_context.Makes == null)
        //  {
        //      return NotFound();
        //  }
        //    var make = await _context.Makes.FindAsync(id);

        //    if (make == null)
        //    {
        //        return NotFound();
        //    }

        //    return make;
        //}

        [HttpGet("{id}")]

        public async Task<IActionResult> GetMake(int id)
        {
            var make = await _unitOfWork.Makes.Get(q => q.Id == id);

            if (make == null)
            {
                return NotFound();
            }

            return Ok(make);

        }




        //// PUT: api/Makes/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutMake(int id, Make make)
        //{
        //    if (id != make.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(make).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MakeExists(id))
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
        public async Task<IActionResult> PutMake(int id, Make make)
        {
            if (id != make.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            _unitOfWork.Makes.Update(make);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await MakeExists(id))
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



        //// POST: api/Makes
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Make>> PostMake(Make make)
        //{
        //  if (_context.Makes == null)
        //  {
        //      return Problem("Entity set 'ApplicationDbContext.Makes'  is null.");
        //  }
        //    _context.Makes.Add(make);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetMake", new { id = make.Id }, make);
        //}


        [HttpPost]
        public async Task<ActionResult<Make>> PostMake(Make make)
        {
            await _unitOfWork.Makes.Insert(make);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetMake", new { id = make.Id }, make);
        }







        //// DELETE: api/Makes/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteMake(int id)
        //{
        //    if (_context.Makes == null)
        //    {
        //        return NotFound();
        //    }
        //    var make = await _context.Makes.FindAsync(id);
        //    if (make == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Makes.Remove(make);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMake(int id)
        {
            var make = await _unitOfWork.Makes.Get(q => q.Id == id);
            if (make == null)
            {
                return NotFound();

            }

            await _unitOfWork.Makes.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }



        //private bool MakeExists(int id)
        //{
        //    return (_context.Makes?.Any(e => e.Id == id)).GetValueOrDefault();
        //}

        private async Task<bool> MakeExists(int id)
        {
            var make = await _unitOfWork.Makes.Get(q => q.Id == id);
            return make != null;
        }
    }
}

