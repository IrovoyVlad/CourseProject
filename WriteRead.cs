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
        private static string[] path = Directory.GetDirectories(@"D:", "data", SearchOption.AllDirectories);
        //
        // функция которая принимает объект типа Voucher и записывет его поля в файл с именем поля number этого объекта.
        //
        static public void Write(Voucher vouch)
        {
            StreamWriter output = new StreamWriter(path[0]+@"\vouchers\"+vouch.getNumber()+".txt");
            vouch.Write(output);
            output.Close();
        }
        //
        // функция которая принимает объект типа Car и записывет его поля в файл с именем поля numbercar этого объекта.
        //
        static public void Write( Car car)
        {
            StreamWriter output = new StreamWriter(path[0] + @"\cars\"+car.getNumbercar()+".txt");
            car.Print(output);
            output.Close();
        }
        //
        // функция которая принимает объект типа Driver и записывет его поля в файл с именем поля persnumber этого объекта.
        //
        static public void Write( Driver driver)
        {
            StreamWriter output = new StreamWriter(path[0] + @"\drivers\"+driver.getPersnumber()+".txt");
            driver.Print(output);
            output.Close();
        }
        //
        //функция принимает имя файла, внутри которого содержаться поля типа Voucher, считывает их и возвращает  объект типа Voucher
        //
        static public Voucher ReadVoucher(string file)
        {
            string number;
            DateTime datedepar;
            DateTime datearriv;
            string destination;
            double distance;
            double consumptiontrip;
            double weigth;
            Car car;
            Driver driver;
            StreamReader sr = new StreamReader(path[0]+@"\vouchers\"+ file);
            number = ParseString(sr.ReadLine());
            datedepar = ParseDate(sr.ReadLine());
            datearriv = ParseDate(sr.ReadLine());
            destination = ParseString(sr.ReadLine());
            distance = ParseDouble(sr.ReadLine());
            consumptiontrip = ParseDouble(sr.ReadLine());
            weigth = ParseDouble(sr.ReadLine());
            car = ReadCar( null,sr);
            driver = ReadDriver( null,  sr);
            sr.ReadLine();
            sr.Close();
            return new Voucher(number ,datedepar, datearriv, destination, distance, consumptiontrip, weigth, car, driver);
        }
        //
        //функция принимает имя файла, внутри которого содержаться поля типа Driver, считывает их и возвращает  объект типа Driver
        //
        static public Driver ReadDriver(string file=null,StreamReader sr=null)
        {
            int persnumber;
            string FIO;
            DateTime datebirth;
            double experience;
            Category category;
            double salary;
            if (sr == null)
            {
                sr = new StreamReader( file);
            }
            persnumber = ParseInt(sr.ReadLine());
            FIO = ParseString(sr.ReadLine());
            datebirth = ParseDate(sr.ReadLine());
            experience= ParseDouble(sr.ReadLine());
            category = new Category(ParseChar(sr.ReadLine()));
            salary = ParseDouble(sr.ReadLine());
            return new Driver(persnumber, FIO, datebirth,experience, category, salary);
        }
        //
        //функция принимает имя файла, внутри которого содержаться поля типа Car, считывает их и возвращает  объект типа Car
        //
        static public Car ReadCar(string file = null, StreamReader sr = null)
        {
            string numbercar;
            string carbrand;
            string carmodel;
            double run;
            double carrying;
            double consumption;
            Category category;
            if (sr == null)
            {
                sr = new StreamReader( file );
            }
            numbercar = ParseString(sr.ReadLine());
            carbrand = ParseString(sr.ReadLine());
            carmodel = ParseString(sr.ReadLine());
            run = ParseDouble(sr.ReadLine());
            carrying = ParseDouble(sr.ReadLine());
            consumption = ParseDouble(sr.ReadLine());
            category = new Category(ParseChar(sr.ReadLine()));
            return new Car(numbercar, carbrand, carmodel, run, carrying, consumption, category);
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
        private static DateTime ParseDate(string date)
        {
            date = date.Remove(0, date.IndexOf(':') + 1);
            date = date.Remove(date.LastIndexOf(' '), 8);
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
