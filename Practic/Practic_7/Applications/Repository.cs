using Practic_7.Item;
using System;
using System.Collections.Generic;
using System.IO;

namespace Practic_7.Applications
{
    public class Repository
    {
        private Worker[] _workers = null;
        private string _way = null;
        public Repository(string way) 
        {
            _way = way;
            using (StreamReader read = new StreamReader(way))
            {
                List<Worker> workers = new List<Worker>();
                string line;
                while ((line = read.ReadLine()) != null)
                {
                    Worker worker = new Worker();
                    var input = line.Split('#');
                    worker.Id = uint.Parse(input[0]);
                    worker.CreateTime = DateTime.Parse(input[1]);
                    FullName fullName = new FullName();
                    var tempName = input[2].Split(' ');
                    fullName.FirstName = tempName[0];
                    fullName.LastName = tempName[1];
                    fullName.Surname = tempName[2];
                    worker.FullName = fullName;
                    worker.Age = uint.Parse(input[3]);
                    worker.Height = uint.Parse(input[4]);
                    worker.BurnTime = DateTime.Parse(input[5]);
                    worker.BurnPlace = input[6];
                    workers.Add(worker);
                }
                _workers = workers.ToArray();
            }
        }
        ~Repository() 
        {
            using (StreamWriter write = new StreamWriter(_way))
            {
                foreach (Worker worker in _workers)
                {
                    write.WriteLine(string.Join("#",
                        worker.Id.ToString(),
                        worker.CreateTime.ToString(),
                        string.Join(" ", worker.FullName.FirstName, 
                                         worker.FullName.LastName,
                                         worker.FullName.Surname),
                        worker.Age.ToString(),
                        worker.Height.ToString(),
                        worker.BurnTime.ToString(),
                        worker.BurnPlace.ToString()));
                }
            }
        }
        public Worker[] GetAllWorkers()
        {
            return _workers;
        }
        public Worker GetWorkerById(uint id)
        {
            foreach (Worker worker in _workers)
            {
                if (worker.Id == id)
                    return worker;
            }
            return new Worker();
        }
        public bool DeleteWorker(uint id)
        {
            var tempList = new List<Worker>(_workers);
            int counter = 0;
            foreach (Worker worker in tempList)
            {
                if (worker.Id != id)
                    counter++;
                else
                {
                    tempList.RemoveAt(counter);
                    _workers = tempList.ToArray();
                    return true;
                }
            }
            return false;
        }
        public void AddWorker(Worker worker)
        {
            Worker[] workers = new Worker[_workers.Length+1];
            for (int i = 0; i < _workers.Length;i++)
            {
                workers[i] = _workers[i];
            }
            workers[_workers.Length] = worker;
            _workers = workers;
        }
        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            var output = new List<Worker>();
            foreach(Worker worker in _workers)
            {
                if (worker.BurnTime >= dateFrom && worker.BurnTime <= dateTo)
                {
                    output.Add(worker);
                }
            }
            return output.ToArray();
        }
    }
}
