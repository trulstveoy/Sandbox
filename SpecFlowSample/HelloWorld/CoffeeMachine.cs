namespace HelloWorld
{
    using System;

    public class CoffeeMachine
    {
        private bool _hasWater;
        private bool _hasBeans;
        private Coffee _coffee;

        public void AddBeans()
        {
            _hasBeans = true;
        }

        public void AddWater()
        {
            _hasWater = true;
        }

        public void BrewCoffee()
        {
            if(_hasBeans && _hasWater)
            {
                _coffee = new Coffee() {Cups = 1};
                _hasBeans = false;
                _hasWater = false;
            }
        }

        public Coffee GetCoffee()
        {
            return _coffee;
        }
    }
}
