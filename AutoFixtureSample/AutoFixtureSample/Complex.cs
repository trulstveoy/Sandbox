namespace AutoFixtureSample
{
    public class Complex
    {
        public IMyInterface Instance { get; set; }
        public AbstractClass AbstractClass { get; set; }

        public Complex(string s, decimal d, IMyInterface instance, AbstractClass abstractClass)
        {
            Instance = instance;
            AbstractClass = abstractClass;
        }
    }

    public abstract class AbstractClass
    {
    }

    public interface IMyInterface
    {
    }
}