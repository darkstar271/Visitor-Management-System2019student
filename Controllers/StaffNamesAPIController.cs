﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Visitor_Management_System2019student.Data;
using Visitor_Management_System2019student.Models;

namespace Visitor_Management_System2019student.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffNamesAPIController : ControllerBase
    {
        private readonly visitorDBcontext _context;

        public StaffNamesAPIController(visitorDBcontext context)
        {
            _context = context;
        }

        // GET: api/StaffNamesAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StaffNames>>> GetStaffNames()
        {
            return await _context.StaffNames.ToListAsync();
        }

        // GET: api/StaffNamesAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StaffNames>> GetStaffNames(int id)
        {
            var staffNames = await _context.StaffNames.FindAsync(id);

            if (staffNames == null)
            {
                return NotFound();
            }

            return staffNames;
        }

        // PUT: api/StaffNamesAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaffNames(int id, StaffNames staffNames)
        {
            if (id != staffNames.Id)
            {
                return BadRequest();
            }

            _context.Entry(staffNames).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffNamesExists(id))
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

        // POST: api/StaffNamesAPI
        [HttpPost]
        public async Task<ActionResult<StaffNames>> PostStaffNames(StaffNames staffNames)
        {
            _context.StaffNames.Add(staffNames);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStaffNames", new { id = staffNames.Id }, staffNames);
        }

        // DELETE: api/StaffNamesAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StaffNames>> DeleteStaffNames(int id)
        {
            var staffNames = await _context.StaffNames.FindAsync(id);
            if (staffNames == null)
            {
                return NotFound();
            }

            _context.StaffNames.Remove(staffNames);
            await _context.SaveChangesAsync();

            return staffNames;
        }

        private bool StaffNamesExists(int id)
        {
            return _context.StaffNames.Any(e => e.Id == id);
        }
    }
}
