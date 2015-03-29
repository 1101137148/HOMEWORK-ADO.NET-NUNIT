using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Age
{
    public class Calculate
    {
        public int getAge(DateTime birthday)
        {
            DateTime today = DateTime.Today;
            int age = -1;
            if (DateTime.Today >= birthday)
            {
                age = today.Year - birthday.Year;

                if (today.Month < birthday.Month)
                {
                    age--;
                }
                else if (today.Month == birthday.Month)
                {
                    if (today.Day < birthday.Day)
                    {
                        age--;
                    }
                }
            }
            return age;
        }
    }
}
