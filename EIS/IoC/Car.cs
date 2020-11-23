namespace IoC
{
    public class Car
    {
        public Car()
        {
            Color = "Синяя";
            Model = "Opel Astra";
            Horsepower = 99.5f;
            Drive = Drive.FrontWheel;
        }

        public Car(string color, string sort, float horsepower, Drive drive)
        {
            Color = color;
            Model = sort;
            Horsepower = horsepower;
            Drive = drive;
        }

        public string Color { get; set; }

        public float Horsepower { get; set; }

        public string Model { get; set; }

        public Drive Drive { get; set; }
    }

    public enum Drive
    {
        FrontWheel = 0,
        Rear = 1,
        FourWheel = 2,
    }
}
