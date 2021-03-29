namespace confusion.matrix.lib
{
    public class DataHolder
    {
        public decimal Expected { get; set; }
        public decimal Value { get; set; }

        public decimal Difference => Expected - Value;
    }
}
