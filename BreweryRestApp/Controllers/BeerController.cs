using App.ApplicationCore.Entities;
using App.ApplicationCore.Interfaces;
using App.ApplicationCore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace BreweryRestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController: Controller
    {
        private readonly IServiceBeer _beerService;

        public BeerController(IServiceBeer beerService)
        {
            _beerService = beerService;
        }


        [HttpGet("ByBrewery/{breweryId}")]
        public ActionResult<List<Beer>> GetAllBeerByBrewery(int breweryId)
        {
            // Assuming you have a way to get a Brewery entity by ID,
            // perhaps using another service or repository method.


            var beers = _beerService.getBeersByBrewery(breweryId);
            return Ok(beers);
        }

        [HttpPost("AddBeer/{breweryId}")]
        public void addBeerByBrewery( Beer beer, int breweryId)
        {
            _beerService.addBeerByBrewery(beer,breweryId);
        }



        [HttpPost("AddSale")]
        public ActionResult<Sale> AddSale(Sale sale)
        {
            try
            {
                var newSale = _beerService.AddBeerSale(sale.BeerFK, sale.WholesalerFK);
                return newSale;
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here
                return BadRequest(ex.Message);
            }
        }

    }
}
