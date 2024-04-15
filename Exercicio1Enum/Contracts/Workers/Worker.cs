using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercicio1Enum.Contracts.Workers.WorkerLevel;
using Exercicio1Enum.Contracts.Workers.HourContracts;
using System.Diagnostics.Contracts;
using System.ComponentModel;
using Exercicio1Enum.Contracts.Workers.Departaments;
namespace Exercicio1Enum.Contracts.Workers
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLvl Level { get; set; }
        public double BaseSalary { get; set; }
        public Departament Departament { get; set; }
        public List<HourContract> Contracts { get; private set; } = new List<HourContract>();//instancia a classe em formato de lista
        public Worker() { }
        public Worker(string name, WorkerLvl level, double baseSalary, Departament departament) //não incluíremos os contratos, pois os valores serão dados ao decorrer da lista
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Departament = departament;
        }
        public void AddContract(HourContract contract) { Contracts.Add(contract); }
        public void RemoveContract(HourContract contract) { Contracts.Remove(contract); }
        public double Income(int year, int month)
        {
            double sum = BaseSalary;
            foreach (HourContract contract in Contracts)
            {
                if (contract.Date.Year == year && contract.Date.Month == month)
                {
                    sum += contract.TotalValue();
                }
            }
            return sum;
        }
    }
}