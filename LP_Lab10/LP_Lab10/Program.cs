using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Microsoft.VisualBasic;

namespace LP_Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car(Car.Type.limousine);
            Console.WriteLine(car);
            CarCollection cars = new CarCollection();
            cars.Add(new Car(Car.Type.jeep));
            cars.Add(car);
            cars.ShowElements();
            cars.Remove(car);
            cars.ShowElements();
            

            MyDictionary<Car> garage = new MyDictionary<Car>();
            garage.Add(0, car);
            garage.Add(1, new Car(Car.Type.minivan));
            garage.Add(2, new Car(Car.Type.jeep));
            garage.Add(3, new Car(Car.Type.sedan));
            garage.Add(4, new Car(Car.Type.pickup));
            garage.ShowElements();
            garage.RemoveElements(1, 3);
            garage.ShowElements();
            Console.WriteLine(garage.TryAdd(3, new Car(Car.Type.limousine)));
            Console.WriteLine(garage.TryAdd(5, new Car(Car.Type.minivan)));

            SortedList<int, Car> list = new SortedList<int, Car>();
            foreach (var val in garage)
            {
                list.Add(val.Key, val.Value);
            }

            foreach (var val in list)
            {
                Console.WriteLine(val);
            }
            FindValue(list,car);
            ObservableCollection<Car> collection = new ObservableCollection<Car>()
            {
                new Car(Car.Type.limousine),
                new Car(Car.Type.jeep),
                new Car(Car.Type.minivan),
            };
            collection.CollectionChanged += Car_CollectionChanged;
            collection.Remove(new Car(Car.Type.jeep)); // не работает!!!
            collection.Add(new Car(Car.Type.pickup));
            
            

        }

        private static void Car_CollectionChanged(object obj, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Car newCar = e.NewItems[0] as Car;
                    Console.WriteLine($"добавлен новый объект {newCar}");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Car oldCar = e.OldItems[0] as Car;
                    Console.WriteLine($"удален объект {oldCar}");
                    break;
                case NotifyCollectionChangedAction.Replace:
                    Car replacedCar = e.OldItems[0] as Car;
                    Car replacingCar = e.NewItems[0] as Car;
                    Console.WriteLine($"объект {replacedCar} заменен {replacingCar} ");
                    break;
            }
        }

        public static void FindValue<T>( SortedList<int,T> list,T value)
        {
            if (list.ContainsValue(value))
            {
                Console.WriteLine(value);
            }
            
        }
    }
}
        
        
        