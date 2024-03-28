using MVVM_DataBinding.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_DataBinding.ViewModel
{
    public class AutoGeneratePeople
    {
        public People? person { get; set; }

       

        public List<People> GeneratePeople(People people)
        {
            Random rnd = new Random();
            List<People> result = new List<People>();

            for (int i = 0; i < 10; i++)
            {
                result.Add(people = new People
                {
                    Name = $"Name{i}",
                    ID = i,
                    PhoneNumber = rnd.Next(1000, 100000).ToString()
                });
            }

            return result;

        }
    }
}
