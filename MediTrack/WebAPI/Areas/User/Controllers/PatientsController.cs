using AutoMapper;
using MediTrack.Core.Interfaces;
using MediTrack.Core.Models;
using MediTrack.WebAPI.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MediTrack.WebAPI.Areas.User.Controllers
{
    [Area("User")]
    [Route("api/[area]/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IDataRepository<Patient> _dataRepository;
        private readonly IMapper _mapper;

        public PatientsController(IDataRepository<Patient> dataRepository, IMapper mapper)
        {
            _dataRepository = dataRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody] PatientDto patientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var patient = _mapper.Map<Patient>(patientDto);
            await _dataRepository.Add(patient);

            // ممكن ترجعي الـ patient اللي اتحفظ أو DTO بعد المابنج
            return Ok(_mapper.Map<PatientDto>(patient));
        }
    }
}
