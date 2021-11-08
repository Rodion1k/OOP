using System;
using System.Collections;
using System.Collections.Generic;

namespace LP_Lab10
{
    public class CarCollection:IList<Car>
    {
        private readonly IList<Car> _cars;

        public CarCollection()
        {
            _cars = new List<Car>();
        }

        public void Add(Car car) => _cars.Add(car);
        public void Clear() => _cars.Clear();
        public bool Remove(Car car) => _cars.Remove(car);
        public bool Contains(Car car) => _cars.Contains(car);
        public void RemoveAt(int index) => _cars.RemoveAt(index);
        public void CopyTo(Car[] array, int arrayIndex) => _cars.CopyTo(array, arrayIndex);
        public void Insert(int index, Car item) => _cars.Insert(index, item);
        public int IndexOf(Car item) => _cars.IndexOf(item);
        public IEnumerator<Car> GetEnumerator() => _cars.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public void ShowElements()
        {
            Console.WriteLine($"сейчас в коллекции {Count} элементов");
            foreach (var T in this)
            {
                Console.WriteLine(T);
            }
        }
        public bool IsReadOnly => _cars.IsReadOnly;
        public int Count => _cars.Count;
        public Car this[int index]
        {
            get { return _cars[index]; }
            set { _cars[index] = value; }
        }
    }
}