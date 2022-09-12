namespace Models
{
    public class Value: IValue
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public interface IValue
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}