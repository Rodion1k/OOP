using System;
namespace LP_Lab10
{
    public class Car
    {
        public enum Type
        {
            sedan,
            jeep,
            minivan,
            convertible,
            limousine,
            pickup,
        }

        private Type _type;

        public Car(Type type)
        {
            _type = type;
        }

        public override string ToString() => $"тип машины: {Convert.ToString(_type)}";

    }
}