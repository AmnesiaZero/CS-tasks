using System;
enum car_brand { Lada, Aurus, Nissan };
enum car_type { Classic, SUV, Sport };

abstract class AbstractCarFactory
{
    public abstract AbstractCar CraetClassicCar();
    public abstract AbstractCar CraetSUVCar();
    public abstract AbstractCar CraetSportCar();
}
class LadaCarFactory : AbstractCarFactory
{
    public override AbstractCar CraetClassicCar() { return new LadaCar(car_type.Classic); }
    public override AbstractCar CraetSUVCar() { return new LadaCar(car_type.SUV); }
    public override AbstractCar CraetSportCar() { return new LadaCar(car_type.Sport); }
}
class AurusCarFactory : AbstractCarFactory
{
    public override AbstractCar CraetClassicCar() { return new AurusCar(car_type.Classic); }
    public override AbstractCar CraetSUVCar() { return new AurusCar(car_type.SUV); }
    public override AbstractCar CraetSportCar() { return new AurusCar(car_type.Sport); }
}
class NissanCarFactory : AbstractCarFactory
{
    public override AbstractCar CraetClassicCar() { return new NissanCar(car_type.Classic); }
    public override AbstractCar CraetSUVCar() { return new NissanCar(car_type.SUV); }
    public override AbstractCar CraetSportCar() { return new NissanCar(car_type.Sport); }
}

abstract class AbstractCar
{
    car_brand car_brand;
    car_type car_type;
    DateTime car_release_date;
    int car_number;
    string car_owner_initials = "";
    public abstract car_brand Car_brand { get; }
    public abstract car_type Car_type { get; }
    public abstract DateTime Car_release_date { get; }
    public abstract int Car_number { get; set; }
    public abstract string Car_owner_initials { get; set; }
    public abstract void Move();
}
class LadaCar : AbstractCar
{
    car_brand car_brand = car_brand.Lada;
    car_type car_type;
    DateTime car_release_date = new DateTime(1900, 1, 1);
    int car_number;
    string car_owner_initials = "";

    public LadaCar(car_type car_type) { this.car_type = car_type; }
    public override car_brand Car_brand { get { return car_brand; } }
    public override car_type Car_type { get { return car_type; } }
    public override DateTime Car_release_date { get { return car_release_date; } }
    public override int Car_number { get { return car_number; } set { car_number = value; } }
    public override string Car_owner_initials { get { return car_owner_initials; } set { car_owner_initials = value; } }
    public override void Move()
    {
        Console.WriteLine(this.car_type == car_type.Classic ? "Еду - 100км/ч\n" : (this.car_type == car_type.SUV ? "Тащусь - 60км/ч\n" : "Лечу - 300км/ч\n"));
    }
}
class AurusCar : AbstractCar
{
    car_brand car_brand = car_brand.Aurus;
    car_type car_type;
    DateTime car_release_date = new DateTime(2000, 1, 1);
    int car_number;
    string car_owner_initials = "";

    public AurusCar(car_type car_type) { this.car_type = car_type; }
    public override car_brand Car_brand { get { return car_brand; } }
    public override car_type Car_type { get { return car_type; } }
    public override DateTime Car_release_date { get { return car_release_date; } }
    public override int Car_number { get { return car_number; } set { car_number = value; } }
    public override string Car_owner_initials { get { return car_owner_initials; } set { car_owner_initials = value; } }
    public override void Move()
    {
        Console.WriteLine(this.car_type == car_type.Classic ? "Еду - 100км/ч\n" : (this.car_type == car_type.SUV ? "Тащусь - 60км/ч\n" : "Лечу - 300км/ч\n"));
    }
}
class NissanCar : AbstractCar
{
    car_brand car_brand = car_brand.Nissan;
    car_type car_type;
    DateTime car_release_date = new DateTime(2100, 1, 1);
    int car_number;
    string car_owner_initials = "";

    public NissanCar(car_type car_type) { this.car_type = car_type; }
    public override car_brand Car_brand { get { return car_brand; } }
    public override car_type Car_type { get { return car_type; } }
    public override DateTime Car_release_date { get { return car_release_date; } }
    public override int Car_number { get { return car_number; } set { car_number = value; } }
    public override string Car_owner_initials { get { return car_owner_initials; } set { car_owner_initials = value; } }
    public override void Move()
    {
        Console.WriteLine(this.car_type == car_type.Classic ? "Еду - 100км/ч\n" : (this.car_type == car_type.SUV ? "Тащусь - 60км/ч\n" : "Лечу - 300км/ч\n"));
    }
}

class Client
{
    private AbstractCar car;

    public Client(AbstractCarFactory factory, car_type car_type)
    {
        car = car_type == car_type.Classic ? factory.CraetClassicCar() : (car_type == car_type.SUV ? factory.CraetSUVCar() : factory.CraetSportCar());
        Buy();
        DpsControl();
    }
    public void Buy()
    {
        Console.WriteLine("Введите имя покупателя: ");
        var initials = Console.ReadLine();
        car.Car_owner_initials = initials ?? "Null";
        Console.WriteLine("Вы купили машину!\n");
    }
    public void DpsControl()
    {
        Console.WriteLine("Постановка на учёт дпс.");
        int num = new Random().Next(1, 10000); ;
        car.Car_number = num;
        Console.WriteLine($"Вы поставили машину на учёт! Ваш номер {num}\n");
    }

    public void StartCar() { car.Move(); }
}

public class task9AltClass
{
    public static void task9Alt()
    {
        //Дополнительное задание
        Client car_1 = new Client(new LadaCarFactory(), car_type.Classic);
        car_1.StartCar();

        Client car_2 = new Client(new AurusCarFactory(), car_type.SUV);
        car_2.StartCar();

        Client car_3 = new Client(new NissanCarFactory(), car_type.Sport);
        car_3.StartCar();

        Console.ReadKey();
    }
}