using Exercicio1Enum.Contracts.Workers;
using Exercicio1Enum.Contracts.Workers.Departaments;
using Exercicio1Enum.Contracts.Workers.WorkerLevel;
using System.Reflection.Emit;
using System.Xml.Linq;
using Exercicio1Enum.Contracts.Workers.HourContracts;

Console.Write($"Enter departament's name: ");
string deptName = Console.ReadLine();
Console.WriteLine($"Enter worker data:");
Console.Write($"Name: ");
string name = Console.ReadLine();
Console.Write($"Level (Junior/MidLevel/Senior): ");
WorkerLvl workerLvl = Enum.Parse<WorkerLvl>(Console.ReadLine());
Console.Write($"Base salary: ");
double baseSalary = double.Parse(Console.ReadLine());
Departament dept = new Departament(deptName);
Worker worker = new Worker(name, workerLvl, baseSalary, dept);
Console.Write($"How many contracts to this worker? ");
int rep = int.Parse(Console.ReadLine());
for (int i = 1; i <= rep; i++)
{
    Console.WriteLine($"Enter #{i} contract data:");
    Console.Write($"Date (DD/MM/YYYY): ");
    DateTime date = DateTime.Parse(Console.ReadLine());
    Console.WriteLine($"Value per hour: ");
    double valuePerHour = double.Parse(Console.ReadLine());
    Console.WriteLine($"Duration (hours): ");
    int hours = int.Parse(Console.ReadLine());
    HourContract contracts = new HourContract(date, valuePerHour, hours);
    worker.AddContract(contracts);
}
Console.WriteLine($"Enter month and year to calculate income (MM/YYYY): ");
string monthAndYear = Console.ReadLine();
int month = int.Parse(monthAndYear.Substring(0, 2));
int year = int.Parse(monthAndYear.Substring(3));
Console.WriteLine($"Name = {worker.Name}");
Console.WriteLine($"Departament = {worker.Departament.Name}");
Console.WriteLine($"Income for {monthAndYear}: {worker.Income(year, month):f2}");