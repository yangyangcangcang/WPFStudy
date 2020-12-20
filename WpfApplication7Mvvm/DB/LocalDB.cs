using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication7Mvvm.Model;

namespace WpfApplication7Mvvm.DB
{

    public class LocalDB
    {
        private List<Person> mList = new List<Person>();

        public LocalDB()
        {
            for (int i = 0; i < 20; i++)
            {
                mList.Add(new Person() { ID = i, Name = $"张三_{i}" });
            }
        }

        public void Add(Person p)
        {
            this.mList.Add(p);
        }

        public Person DeletePerson(int id)
        {
            Person p = this.FindById(id);
            if(p!=null)
            {
                this.mList.Remove(p);
                return p;
            }
            return null;
        }

        public Person FindById(int id)
        {
            Person person = mList.Find(p => p.ID == id);
            if (person != null)
            {
                return person;
            }
            return null;
        }

        public List<Person> FindAll()
        {
            return mList;
        }

        public void UpdatePerson(int id)
        {
            //mList.
        }


    }
}
