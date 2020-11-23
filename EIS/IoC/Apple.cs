namespace IoC
{
    public class Apple
    {
        public Apple()
        {
            Color = "Зелёное";
            Sort = "Симиренко";
            IsRotten = false;
        }

        public Apple(string color, string sort, bool isRotten)
        {
            Color = color;
            Sort = sort;
            IsRotten = isRotten;
        }

        public string Color { get; set; }

        public bool IsRotten { get; set; }

        public string Sort { get; set; }
    }
}
