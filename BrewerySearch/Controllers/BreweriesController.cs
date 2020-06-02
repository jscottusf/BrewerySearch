using System.Collections.Generic;
using AutoMapper;
using BrewerySearch.Data;
using BrewerySearch.Dtos;
using BrewerySearch.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BrewerySearch.Controllers
{
    [Route("api/breweries")]
    [ApiController]
    public class BreweriesController : Controller
    {
        private readonly IBreweryRepo _repository;
        private readonly IMapper _mapper;

        public BreweriesController(IBreweryRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/breweries
        [HttpGet]
        public ActionResult<IEnumerable<BreweryReadDto>> GetAllBreweries()
        {
            var breweryItems = _repository.GetAllBreweries();
            return Ok(_mapper.Map<IEnumerable<BreweryReadDto>>(breweryItems));
        }

        [HttpGet("{id}", Name = "GetBreweryById")]
        public ActionResult<BreweryReadDto> GetBreweryById(int id)
        {
            var breweryItem = _repository.GetBreweryById(id);
            if (breweryItem != null)
            {
                return Ok(_mapper.Map<BreweryReadDto>(breweryItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<BreweryReadDto> CreateBrewery(BreweryCreateDto breweryCreateDto)
        {
            var breweryModel = _mapper.Map<Brewery>(breweryCreateDto);
            _repository.CreateBrewery(breweryModel);
            _repository.SaveChanges();

            var BreweryReadDto = _mapper.Map<BreweryReadDto>(breweryModel);

            return CreatedAtRoute(nameof(GetBreweryById), new { Id = BreweryReadDto.Id }, BreweryReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateBrewery(int id, BreweryUpdateDto breweryUpdateDto)
        {
            var breweryModelFromRepo = _repository.GetBreweryById(id);
            if (breweryModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(breweryUpdateDto, breweryModelFromRepo);
            _repository.UpdateBrewery(breweryModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpPatch{"{id}"]
        public ActionResult PartialBreweryUpdate(int id, JsonPatchDocument<BreweryUpdateDto> patchDoc)
        {
            var breweryModelFromRepo = _repository.GetBreweryById(id);
            if (breweryModelFromRepo == null)
            {
                return NotFound();
            }
            var breweryToPatch = _mapper.Map<BreweryUpdateDto>(breweryModelFromRepo);
            patchDoc.ApplyTo(breweryToPatch, ModelState);
            if (!TryValidateModel(breweryToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(breweryToPatch, breweryModelFromRepo);
            _repository.UpdateBrewery(breweryModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}
