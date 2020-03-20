using System;

namespace P04.WildFarm.Exceptions
{
    public class FoodException : Exception
    {
        public FoodException(string message) 
            : base(message)
        {

        }
    }
}
