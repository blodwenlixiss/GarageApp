namespace WebApplication1.Models.Dtos;

public class CarGarageDto
{

        public Guid CarId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public int Quantity { get; set; }

}