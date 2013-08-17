using StudentsDb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDb.Client
{
    internal class Client
    {
        private static void Main()
        {
            using (var context = new StudentsDbContext())
            {
                Console.WriteLine(context.Marks.Count());
            }
        }
    }
}
