using System;
using System.Collections.Generic;
using System.Linq;

namespace SwitchCase
{
    class Program
    {
        interface ICase
        {
            string Result { get; }
            bool Evaluate();
        }

        class ACase : ICase 
        {
            public string Result { get { return "A"; } }
            private readonly int _number;
            public ACase(int number)
            {
                _number = number;
            }

            public bool Evaluate()
            {
                return _number < 5;
            }
        }

        class BCase : ICase
        {
            public string Result { get { return "B"; } }
            private readonly List<int> _numbers;
            public BCase(List<int> numbers)
            {
                _numbers = numbers;
            }

            public bool Evaluate()
            {
                return _numbers.Any(x => x > 5);
            }
        }

        class CatchAllCase : ICase
        {
            public string Result { get { return "CatchAll"; } }
            public bool Evaluate()
            {
                return true;
            }
        }

        static void Main(string[] args)
        {
            int number = 8;
            var numbers = new List<int> {8, 2};

            var list = new List<ICase>
            {
                new ACase(number),
                new BCase(numbers),
                new CatchAllCase()
            };

            ICase first = list.First(x => x.Evaluate());
            Console.WriteLine(first.Result);
        }
    }
}
