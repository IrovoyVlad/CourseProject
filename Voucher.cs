using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auto
{
    class Voucher:IWritebleObject, IReadbleObject
    {
        private string number;
        private DateTime datedeparture;//Дата выезда
        private DateTime datearrival;//Дата прибытия
        private string destination;// Место назначения
        private double distance;// Расстояние
        private double consumptiontrip;//Расход горючего на поездку
        private double weigth;//Масса груза
        private Car car;
        private Driver driver;
        //
        //Конструктор с параметрами, который инициализирует поля класса
        //
        public Voucher(string number ,DateTime datedepar,DateTime datearriv,string destination,double distance , double consumptiontrip,double weigth , Car car, Driver driver) 
        {
            this.number = number;
            datedeparture = datedepar;
            datearrival = datearriv;
            this.destination = destination;
            this.distance = distance;
            this.consumptiontrip = consumptiontrip;
            this.weigth = weigth;
            this.car = car;
            this.driver = driver;
        }
        public Voucher(ILoadManager man)
        {
            number = man.ReadLine().Split(':')[1];
            datedeparture = WriteRead.ParseDate( man.ReadLine().Split(':')[1]);
            datearrival = WriteRead.ParseDate(man.ReadLine().Split(':')[1]);
            destination = man.ReadLine().Split(':')[1];
            distance = double.Parse( man.ReadLine().Split(':')[1]);
            consumptiontrip = double.Parse(man.ReadLine().Split(':')[1]);
            weigth = double.Parse(man.ReadLine().Split(':')[1]);
            car = new Car(man);
            driver = new Driver(man);
        }
        //
        //Конструктор без параметров который считывает поля класса
        //
        public Voucher()
        {
            Console.WriteLine("Введите номер путевки: ");
                number = Console.ReadLine();
            int year, day, month;
            do
            {
                Console.WriteLine("Введите день,месяц и год выезда(через Enter): ");
                day = int.Parse(Console.ReadLine());
                month = int.Parse(Console.ReadLine());
                year = int.Parse(Console.ReadLine());
            } while (day <= 0 || day > 31 || month <= 0 || month > 12 || year < 1900 || year > 2002);
            datedeparture = new DateTime(year, month, day);
            do
            {
                Console.WriteLine("Введите день,месяц и год прибытия(через Enter): ");
                day = int.Parse(Console.ReadLine());
                month = int.Parse(Console.ReadLine());
                year = int.Parse(Console.ReadLine());
            } while (day <= 0 || day > 31 || month <= 0 || month > 12 || year < 1900 || year > 2002);
            datearrival = new DateTime(year, month, day);
            Console.WriteLine("Введите место назначения: ");
             destination= Console.ReadLine();
           
            do
            {
                Console.WriteLine("Введите расстояние путевки(км): ");
                distance = double.Parse(Console.ReadLine());
            } while (distance < 0);
            do
            {
                Console.WriteLine("Введите расход горючего на поездку: ");
                consumptiontrip = double.Parse(Console.ReadLine());
            } while (consumptiontrip < 0);
            do
            {
                Console.WriteLine("Введите масса груза: ");
                weigth = double.Parse(Console.ReadLine());
            } while (weigth < 0);
        }
        public double getWeigth()
        {
            return weigth;
        }
        public void setCar(Car car)
        {
            this.car = car;
        }
        public void setDriver(Driver driver)
        {
            this.driver = driver;
        }
        public void setNumber(string number)
        {
            this.number = number;
        }
        public void Write(SaveManager sw)
        {
            sw.WriteLine($"Номер путевки: {number}");
            sw.WriteLine($"Дата выезда: {datedeparture.Date}");
            sw.WriteLine($"Дата прибытия: {datearrival.Date}");
            sw.WriteLine($"Место назначение:  {destination}");
            sw.WriteLine($"Дальность следования:  {distance}");
            sw.WriteLine($"расход горючего на поездку: {consumptiontrip}");
            sw.WriteLine($"Вес груза: {weigth}");
            car.Write(sw);
            driver.Write(sw);
            sw.WriteLine($"Стоимость путевки: {consumptiontrip * 42 + driver.getSalary()}");
        }
        public string getNumber()
        {
            return number;
        }
        public class Loader : IReadableObjectLoader
        {
            public Loader() { }
            public IReadbleObject Load(ILoadManager man)
            {
                return new Voucher(man);
            }
        }

    }
}
