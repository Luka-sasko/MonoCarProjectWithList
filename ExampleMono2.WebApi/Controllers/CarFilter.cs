namespace ExampleMono2.WebApi.Controllers
{
    public class CarFilter
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int? ManufacturYear { get; set; }

        public CarFilter()
        {
            Brand = null;
            Model = null;
            ManufacturYear = null;
        }
    }
}
