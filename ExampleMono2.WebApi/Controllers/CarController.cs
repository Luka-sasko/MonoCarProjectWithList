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

        public HttpResponseMessage Get()
        {
            if (cars.Count == 0) 
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,"Cars not found!");
            }
            return Request.CreateResponse<List<Car>>(HttpStatusCode.OK, cars);
        }

        // GET api/Car/5
        public HttpResponseMessage Get(int id)
        {
            var car = cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Car not found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, car);
        }

        public HttpResponseMessage Get([FromUri] CarFilter filter)
        {
            List<Car> filteredCar = new List<Car>();
            if (filter != null) {
                return Request.CreateResponse<List<Car>>(HttpStatusCode.OK, cars);
            }
            else {
                if (filter.Model != null)
                {
                    foreach (var item in cars)
                    {
                        if (item.Model == filter.Model) {
                            filteredCar.Add(item);
                        }
                    }
                }
                if (filter.Brand != null)
                {
                    if (filteredCar.Count != 0) {
                        foreach (var item in filteredCar)
                        {
                            if (item.Brand == filter.Brand && !(item.Model == filter.Model))
                            {
                                filteredCar.Remove(item);
                            }

                        }
                    }
                    else
                    {
                        foreach (var item in cars)
                            if (item.Brand == filter.Brand{
                                {
                                    if (item.Brand == filter.Brand)
                                    {
                                        filteredCar.Add(item);
                                    }
                                }
                            }
                    } 
                } 
            }
            /*
            filteredCar = cars.Where(model => filter.Model == model)
                .Where(brand => filter.Brand == brand)
                .Where(manufactorYear => filter.ManufactorYear == manufactorYear);
            */

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
                return Request.CreateResponse(HttpStatusCode.NotFound, "Car not found!");
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
                return Request.CreateResponse(HttpStatusCode.NotFound, "Car not found!");
            cars.Remove(cars.FirstOrDefault(car => car.Id.Equals(id)));
            return Request.CreateResponse<List<Car>>(HttpStatusCode.OK, cars);
        }


    }
}
