using System.Drawing;

namespace ExampleMono2.WebApi.Controllers
{
    public class Car
    {
        private string model;
        private string brand;
        private int id;
        private int manufacturYear;
        public string Model {
            get { return model; }
            set { model = value; }
        }
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int ManufacturYear
        {
            get { return manufacturYear; }
            set { manufacturYear = value; }
        }
        public Car (string model, string brand, int id,int manufacturYear)
        {
            Model = model;
            Brand = brand;
            Id = id;
            ManufacturYear = manufacturYear;
        }

    }
}