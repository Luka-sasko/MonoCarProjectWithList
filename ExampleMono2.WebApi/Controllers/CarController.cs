using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ExampleMono2.WebApi.Controllers
{
    public class CarController : ApiController
    {


        private static List<Car> cars = new List<Car>();

        // GET api/Car
        /*
        public HttpResponseMessage Get()
        {
            if (cars.Count == 0) 
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,"No Car was found!");
            }
            return Request.CreateResponse<List<Car>>(HttpStatusCode.OK, cars);
        }

        // GET api/Car/5
        public HttpResponseMessage Get(int id)
        {
            var car = cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Car was found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, car);
        }
        */


        public HttpResponseMessage Get([FromUri] CarFilter filter)
        {
            if (filter == null)
                return Request.CreateResponse(HttpStatusCode.OK, cars);

            var filteredCars = cars.Where(car => car != null &&
                (filter.Model == null || car.Model == filter.Model) &&
                (filter.Brand == null || car.Brand == filter.Brand) &&
                (filter.ManufacturYear == null || car.ManufacturYear == filter.ManufacturYear)
            ).ToList();


            if (filteredCars.Any())
                return Request.CreateResponse(HttpStatusCode.OK, filteredCars);

            return Request.CreateResponse(HttpStatusCode.NoContent, "No car was found with the chosen filters!");
        }


        // POST api/Car
        public HttpResponseMessage Post([FromBody] Car newCar)
        {
            if (cars.FirstOrDefault(car => car.Id.Equals(newCar.Id)) == null)
            {
                cars.Add(newCar);
                return Request.CreateResponse(HttpStatusCode.OK, newCar);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, "Car alredy exist");
        }

        public HttpResponseMessage Put(int id, [FromBody] Car editedCar)
            { 

            if (cars.FirstOrDefault(car => car.Id.Equals(id)) == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Car was found!");
            if(editedCar.Id != null)
                cars.FirstOrDefault(car => car.Id.Equals(id)).Id = editedCar.Id;
            if(editedCar.Brand != null)
                cars.FirstOrDefault(car => car.Id.Equals(id)).Brand= editedCar.Brand;
            if(editedCar.Model != null)
                cars.FirstOrDefault(car => car.Id.Equals(id)).Model = editedCar.Model;
            if(editedCar.ManufacturYear != null)
                cars.FirstOrDefault(car => car.Id.Equals(id)).ManufacturYear= editedCar.ManufacturYear;
            var newEditedCar = cars.FirstOrDefault(car => car.Id.Equals(id));
            return Request.CreateResponse(HttpStatusCode.OK, newEditedCar);
        }



                // DELETE api/Car/5
        public HttpResponseMessage Delete(int id)
        {
            if (cars.FirstOrDefault(car => car.Id.Equals(id)) == null)
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Car was found!");
            cars.Remove(cars.FirstOrDefault(car => car.Id.Equals(id)));
            return Request.CreateResponse<List<Car>>(HttpStatusCode.OK, cars);
        }


    }
}
