using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество новых водителей на вашем предприятии: ");
            int count = int.Parse(Console.ReadLine());
         
            Driver[] drivers = new Driver[count+WriteRead.getcountDriv()];
            Driver[] olddriver;
            Car[] oldcar;
          
            for (int i = 0; i < count; i++)
            {
                drivers[i] = new Driver();
                WriteRead.Write(drivers[i]);
            }
               
         
            try
            {
                olddriver = WriteRead.ReadAllDrivers();
                for (int i = drivers.Length - WriteRead.getcountDriv(), b = 0; i < drivers.Length; i++, b++)
                {
                    drivers[i] = olddriver[b];
                }
            }
            catch  { }
            Console.WriteLine("Введите количество новых машин на вашем предприятии: ");
            count = int.Parse(Console.ReadLine());
            Car[] cars = new Car[count+WriteRead.getcountCar()];
            
            for (int i = 0; i < count; i++)
            {
                cars[i] = new Car();
                WriteRead.Write(cars[i]);
            }
                 
           
            try
            {
                oldcar = WriteRead.ReadAllCars();
                for (int i = cars.Length - WriteRead.getcountCar(), b = 0; i < drivers.Length; i++, b++)
                {
                    cars[i] = oldcar[b];
                }
            }
            catch { }
            Voucher v1=new Voucher();
            int  indexcar = 0;
            int indexdriv = 0;
            for (int i = 0; i < cars.Length; i++)
            {                
                    if (cars[i].getCategory() == Category.isCategory(v1.getWeigth()))

                    {
                        for (int j = 0; j < drivers.Length; j++)
                        {                           
                                indexcar = i;
                                if (drivers[j].getCategory() == cars[i].getCategory())
                                {
                                    indexdriv = j;
                                    break;
                                }
                        }
                        break;
                    }                
            }
            v1.setCar(cars[indexcar]);
            v1.setDriver(drivers[indexdriv]);
            WriteRead.Write( v1);
            Voucher v2 = WriteRead.ReadVoucher(v1.getNumber()+".txt");
            v2.setNumber(v2.getNumber() + 1);
            WriteRead.Write(v2);
            Console.ReadKey();
        }
    }
}
