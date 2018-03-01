using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    class Program
    {
        static void Main(string[] args)
        {
            //---------------------------------------------------Part1--------------------------------------------------------------------
            var car1 = new CarModel
            {
                LicencePlate = "NF123456",
                EnginePower = 147,
                MaximalSpeed = 200,
                Colour = "green",
                VehicleType = "personal"
            };

            Console.WriteLine("car1: licence plate {0}, {1} kW engine power, maximal speed of {2} km/h,{3} colour and type of {4} vehicle",
                car1.LicencePlate,
                car1.EnginePower,
                car1.MaximalSpeed,
                car1.Colour,
                car1.VehicleType);

            var car2 = new CarModel
            {
                LicencePlate = "NF654321",
                EnginePower = 150,
                MaximalSpeed = 195,
                Colour = "blue",
                VehicleType = "personal"
            };

            Console.WriteLine("car2: licence plate {0}, {1} kW engine power, maximal speed of {2} km/h,{3} colour and type of {4} vehicle",
                car2.LicencePlate,
                car2.EnginePower,
                car2.MaximalSpeed,
                car2.Colour,
                car2.VehicleType);

            Type t1 = car1.GetType();
            Type t2 = car2.GetType();

            PropertyInfo[] property1 = t1.GetProperties();

            var isEqual = true;

            foreach (PropertyInfo p in property1)
            {
                string value1 = p.GetValue(car1, null)?.ToString();
                string value2 = t2.GetProperty(p.Name)?.GetValue(car2, null)?.ToString();

                if (value1 == value2)
                {
                    Console.WriteLine("{0} equal", p.Name);
                }
                else
                {
                    isEqual = false;
                    Console.WriteLine("{0} not equal", p.Name);
                }
            }

            Console.WriteLine("Compare these two cars to check if this is the same vehicle,{0}", isEqual);

            //--------------------------------------------------Part2----------------------------------------------------------------------

            var plane = new PlaneModel
            {
                Registration = "LN1234",
                EnginePower = 1000,
                wingspan = 30,
                Capacity = 2,
                Weight = 10,
                PlaneType = "jet plane"
            };

            Console.WriteLine("plane: registration {0}, {1} kW engine power, {2}m wingspan, {3}t load capacity and {4}t net weight, flying class of {5}",
                plane.Registration,
                plane.EnginePower,
                plane.wingspan,
                plane.Capacity,
                plane.Weight,
                plane.Weight);

            Start flyPlaneFactory = new FlyPlane();
            Start driveCarFactory = new DriveCar();

            Vehicle flyPlane = flyPlaneFactory.VehicleStartFactory();
            flyPlane.Print();

            car1.Print();

            //--------------------------------------------------Part3----------------------------------------------------------------------

            var boat = new BoatModel
            {
                Registration = "ABC123",
                EnginePower = 100,
                MaximalSpeed = 30,
                GrossTonnage = 500
            };

            Console.WriteLine("boat: registration {0}, {1} kW engine power, maximal speed of {2} knot per hour and {3} kg gross tonnage",
             boat.Registration,
             boat.EnginePower,
             boat.MaximalSpeed,
             boat.GrossTonnage);

            Console.Read();
        }
    }

    /// <summary>
    /// 抽象交通工具
    /// </summary>
    public abstract class Vehicle
    {
        public abstract void Print();
    }

    /// <summary>
    /// 汽车类
    /// </summary>
    class CarModel : Vehicle
    {
        /// <summary>
        /// 车牌号
        /// </summary>
        public string LicencePlate { set; get; }

        /// <summary>
        /// 功率,单位（kw）
        /// </summary>
        public int EnginePower { set; get; }

        /// <summary>
        /// 最高时速,单位（km/h）
        /// </summary>
        public int MaximalSpeed { set; get; }

        /// <summary>
        /// 颜色
        /// </summary>
        public string Colour { set; get; }

        /// <summary>
        /// 交通工具类型
        /// </summary>
        public string VehicleType { set; get; }

        public override void Print()
        {
            Console.WriteLine("ask the car to drive ");
        }
    }

    /// <summary>
    /// 飞机类
    /// </summary>
    class PlaneModel : Vehicle
    {
        /// <summary>
        /// 注册号
        /// </summary>
        public string Registration { set; get; }

        /// <summary>
        /// 功率,单位（kw）
        /// </summary>
        public int EnginePower { set; get; }

        /// <summary>
        /// 翼展
        /// </summary>
        public int wingspan { set; get; }

        /// <summary>
        /// 容量
        /// </summary>
        public int Capacity { set; get; }

        /// <summary>
        /// 重量
        /// </summary>
        public int Weight { set; get; }

        /// <summary>
        /// 飞机类型
        /// </summary>
        public string PlaneType { set; get; }

        public override void Print()
        {
            Console.WriteLine("ask the plane to fly ");
        }
    }

    /// <summary>
    /// 船类
    /// </summary>
    class BoatModel : Vehicle
    {
        /// <summary>
        /// 注册号
        /// </summary>
        public string Registration { set; get; }

        /// <summary>
        /// 功率,单位（kw）
        /// </summary>
        public int EnginePower { set; get; }

        /// <summary>
        /// 最高时速,单位（knot per hour）
        /// </summary>
        public int MaximalSpeed { set; get; }

        /// <summary>
        /// 总吨位
        /// </summary>
        public int GrossTonnage { set; get; }

        public override void Print()
        {
            Console.WriteLine("ask the plane to fly ");
        }
    }

    /// <summary>
    /// 抽象工厂类
    /// </summary>
    public abstract class Start
    {
        // 工厂方法
        public abstract Vehicle VehicleStartFactory();
    }

    /// <summary>
    /// 飞机起飞类
    /// </summary>
    public class FlyPlane : Start
    {
        /// <summary>
        /// 飞机起飞
        /// </summary>
        /// <returns></returns>
        public override Vehicle VehicleStartFactory()
        {
            return new PlaneModel();
        }
    }

    /// <summary>
    /// 汽车开车类
    /// </summary>
    public class DriveCar : Start
    {
        /// <summary>
        /// 汽车开车
        /// </summary>
        /// <returns></returns>
        public override Vehicle VehicleStartFactory()
        {
            return new CarModel();
        }
    }
}
