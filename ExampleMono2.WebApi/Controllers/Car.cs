namespace ExampleMono2.WebApi.Controllers
{
    public class Car
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public int Id { get; set; }
        public int ManufacturYear { get; set; }

        public Car(string model, string brand, int id, int manufacturYear)
        {
            Model = model;
            Brand = brand;
            Id = id;
            ManufacturYear = manufacturYear;
        }
    }
}
