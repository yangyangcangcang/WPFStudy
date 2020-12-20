using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication6.Models;

namespace WpfApplication6.DB
{
    public class LoacalDb
    {
        private List<Person> list = new List<Person>();
        public LoacalDb()
        {
            Init();
        }

        private void Init()
        {
            // throw new NotImplementedException();
            list.Clear();
            for (int i = 0; i < 30; i++)
            {
                list.Add(new Person() { ID = i, Name = $"张三_{i}" });
            }
        }

        public void AddPerson(Person person)
        {
            list.Add(person);
        }

        public List<Person> GetAllPerson()
        {
            return list;
        }
        
        public bool DeleteStudent(int id)
        {
            return list.Remove(list.FirstOrDefault(p => p.ID == id));
        }

        public List<Person> GetPersonByName(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                return null;
            }
            return list.Where(p => p.Name.Contains(name)).ToList();
        }

    }


}
