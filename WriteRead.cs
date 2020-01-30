using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace auto
{

    class WriteRead
    {
        //
        //локальная пеменная в которой храниться имя папки, внутри которой содержатиься папки с файлами данных об объектах.
        //
        // private static string[] path = Directory.GetDirectories(@"C:", "dataauto", SearchOption.AllDirectories);
        private static string[] path = { @"C:\Users\Student\Desktop\покс-31\CourseProject\bin\Debug\dataauto" };
        //
        // функция которая принимает объект типа Voucher и записывет его поля в файл с именем поля number этого объекта.
        //
        static public void Write(Voucher vouch)
        {
            SaveManager output = new SaveManager(path[0]+@"\vouchers\"+vouch.getNumber());
            vouch.Write(output);
           
        }
        //
        // функция которая принимает объект типа Car и записывет его поля в файл с именем поля numbercar этого объекта.
        //
        static public void Write( Car car)
        {
            SaveManager output = new SaveManager(path[0] + @"\cars\"+car.getNumbercar());
            car.Write(output);
       
        }
        //
        // функция которая принимает объект типа Driver и записывет его поля в файл с именем поля persnumber этого объекта.
        //
        static public void Write( Driver driver)
        {
            SaveManager output = new SaveManager(path[0] + @"\drivers\"+driver.getPersnumber());
            driver.Write(output);
           
        }
        //
        //функция принимает имя файла, внутри которого содержаться поля типа Voucher, считывает их и возвращает  объект типа Voucher
        //
        static public Voucher ReadVoucher(string file)
        {
            
            LoadManager sr = new LoadManager(path[0] + @"\vouchers\" + file);
            sr.BeginRead();
            Voucher s= new Voucher(sr);
            sr.EndRead();
            return s;
        }
        //
        //функция принимает имя файла, внутри которого содержаться поля типа Driver, считывает их и возвращает  объект типа Driver
        //
        static public Driver ReadDriver(string file)
        {
           
            LoadManager sr = new LoadManager(/*path[0] + @"\drivers\"*/  file);
            sr.BeginRead();
            Driver s = new Driver(sr);
            sr.EndRead();
            return s;
        }
        //
        //функция принимает имя файла, внутри которого содержаться поля типа Car, считывает их и возвращает  объект типа Car
        //
        static public Car ReadCar(string file )
        {
            LoadManager sr = new LoadManager(/*path[0] + @"\cars\"*/  file );
            sr.BeginRead();
            Car s = new Car(sr);
            sr.EndRead();
            return s;
        }
        //
        //функция считывает из файлов объекты типа Car в массив и возвращает его
        //
        static public Car[] ReadAllCars()
        {
            string[] carfile;
            try
            {
                carfile = Directory.GetFiles(path[0] + @"\cars", "*txt", SearchOption.TopDirectoryOnly);
            }
            catch
            {
                return null;
            }
            Car[] car = new Car[getcountCar()];
            for(int i=0;i<carfile.Length;i++)
            {
                car[i] = ReadCar(carfile[i]);
            }
            return car;
        }
        //
        //функция считывает из файлов объекты типа Driver в массив и возвращает его
        //
        static public Driver[] ReadAllDrivers()
        {
            string[] driverfile;
            try {
                driverfile = Directory.GetFiles(path[0] + @"\drivers", "*txt", SearchOption.TopDirectoryOnly);
            }
            catch
            {
                return null;
            }
            Driver[] drivers = new Driver[getcountDriv()];
            for (int i = 0; i < driverfile.Length; i++)
            {
                drivers[i] = ReadDriver(driverfile[i]);
            }
            return drivers;
        }
        //
        //функция считывает из файлов объекты типа Voucher в массив и возвращает его
        //
        static public Voucher[] ReadAllVouchers()
        {
            string[] vouchfile;
            try
            {
                vouchfile = Directory.GetFiles(path[0] + @"\vouchers", "*txt", SearchOption.TopDirectoryOnly);
            }
            catch
            {
                return null;
            }
            
            Voucher[] vouchers = new Voucher[getcountDriv()];
            for (int i = 0; i < vouchers.Length; i++)
            {
                    vouchers[i] = ReadVoucher(vouchfile[i]);
            }
            return vouchers;
            
        }
        //
        //функция принимает строку,выделяет из неё значимую часть, преобразует ее в объект типа DataTime и возвращает преобразованное значение
        //
       public static DateTime ParseDate(string date)
        {
            date = date.Remove(0, date.IndexOf(':') + 2);
            date = date.Remove(date.IndexOf(' '), 2);
            Console.WriteLine(date);
            string[] dat = date.Split('.');
            return new DateTime(int.Parse(dat[2]),int.Parse( dat[1]),int.Parse (dat[0]));
        }
        //
        //функция принимает строку, выделяет из неё значимую часть и возвращает полученное значение
        //
        private static string ParseString(string str)
        {
           str= str.Remove(0, str.IndexOf(':') + 2);
            return str;
        }
        //
        //функция принимает строку,выделяет из неё значимую часть, преобразует в тип double и возвращает преобразованное значение
        //
        private static double ParseDouble(string str)
        {
            str=str.Remove(0, str.IndexOf(':') + 1);
            return double.Parse(str);
        }
        //
        //функция принимает строку,выделяет из неё значимую часть, преобразует в тип int и возвращает преобразованное значение
        //
        private static int ParseInt(string str)
        {
           str= str.Remove(0, str.IndexOf(':') + 1);
            return int.Parse(str);
        }
        //
        //функция принимает строку,выделяет из неё значимую часть, преобразует в тип char и возвращает преобразованное значение
        //
        private static char ParseChar(string str)
        {
           str=  str.Remove(0, str.IndexOf(':') + 1);
            return char.Parse(str.Trim(' '));
        }
        //
        //функция возвращает количество объектов типа Voucher записанных в папке vouchers
        //
        public static int getcountVouch()
        {
            string[] s = Directory.GetFiles(path[0] + @"\vouchers");
            return s.Length;
        }
        //
        //функция возвращает количество объектов типа Driver записанных в папке drivers
        //
        public static int getcountDriv()
        {
            string[] s = Directory.GetFiles(path[0] + @"\drivers");
            return s.Length;
        }
        //
        //функция возвращает количество объектов типа Car записанных в папке cars
        //
        public static int getcountCar()
        {
            string[] s = Directory.GetFiles(path[0] + @"\cars");
            return s.Length;
        }
    }
}
