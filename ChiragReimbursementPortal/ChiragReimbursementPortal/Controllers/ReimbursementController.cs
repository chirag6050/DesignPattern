using AutoMapper;
using BusinessLayer.DTO;
using BusinessLayer.Services;
using ChiragReimbursementPortal.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChiragReimbursementPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReimbursementController :ControllerBase
    {
        private readonly IReimbursementService reimbursementService;
        private readonly IMapper mapper;

        // userservice is called dependency is injected 
        public ReimbursementController(IReimbursementService _reimbursementService, IMapper _mapper)
        {
            reimbursementService = _reimbursementService;
            mapper = _mapper;
        }

        // POST: api/AddReimbursement
        [HttpPost]
        [Route("AddReimbursement")]
        public async Task<ActionResult<RDetailModel>> AddReimbursement(RDetailModel reimbursementDetail)
        {
            var details = mapper.Map<RDetailModel, ReimbursementDTO>(reimbursementDetail);
            await reimbursementService.AddReimbursement(details);
            return CreatedAtAction("AddReimbursement", new { id = reimbursementDetail.EmployeeId }, reimbursementDetail);
        }


        // GET: api/GetAllReimbursement
        [HttpGet]
        public async Task<ActionResult<List<RDetailModel>>> GetAllReimbursement()
        {
            var listOfReimbursement = await reimbursementService.GetAllReimbursement();
            return mapper.Map<List<ReimbursementDTO>, List<RDetailModel>>(listOfReimbursement);
        }

        // GET: api/ReimbursementDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RDetailModel>> GetReimbursementById(int id)
        {
            var reimbursementDetail = await reimbursementService.GetReimbursementById(id);

            if (reimbursementDetail == null)
            {
                return NotFound();
            }
            return mapper.Map<ReimbursementDTO, RDetailModel>(reimbursementDetail);

        }

        // PUT: api/ReimbursementDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> GetReimbursementById(int id, RDetailModel reimbursementDetail)
        {
            if (id != reimbursementDetail.EmployeeId)
            {
                return BadRequest();
            }
            
            await reimbursementService.GetReimbursementById(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<bool>> Update(int id, RDetailModel reimbursementDetail)
        {
            var details = mapper.Map<RDetailModel, ReimbursementDTO>(reimbursementDetail);
            await reimbursementService.Update(id,details);
            return true;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteR(int id)
        {
            var check = await reimbursementService.DeleteR(id);
            if (check == false)
            {
                return NoContent();
            }
            return true;
        }

    }
}
