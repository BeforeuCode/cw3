﻿using cw3.DAL.DTO;
using cw3.DAL.DTOs.Requests;
using cw3.DAL.Services;
using cw3.Models;
using Microsoft.AspNetCore.Mvc;

namespace cw3.Controllers
{
    [ApiController]
    [Route("api/enrollments")]
    public class EnrollmentsController : Controller
    {
        private readonly IStudentsDbService _dbService;

        public EnrollmentsController(IStudentsDbService dbService)
        {
            _dbService = dbService;
        }
        [HttpPost]
        public IActionResult AddEnrollment(EnrollmentDTO enrollmentDTO)
        {
            if (!ModelState.IsValid)
                {
                    var state = ModelState;
                    return BadRequest();
                }
            Enrollment enrollment = _dbService.EnrollStudent(enrollmentDTO);

            if (enrollment != null)
                {
                    return Created("api/students/" + enrollmentDTO.IndexNumber, enrollment);
                }
            else
                {
                    return BadRequest();
                }

        }




        [HttpPost("promotions")]
        public IActionResult Promote(PromotionDTO promotionDTO)
        {
         
            if (!ModelState.IsValid)
                {
                    var state = ModelState;
                    return BadRequest();
                }
            Enrollment enrollment = _dbService.Promote(promotionDTO);
            if (enrollment != null)
                {
                    return Created("", enrollment);
                }
            else
                {
                    return BadRequest();
                }
        }

    }
}
  

