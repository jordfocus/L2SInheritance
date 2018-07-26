using L2SInheritance.DAL;
using System;

namespace L2SInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            // create zoo database context 
            var dbContext = new ZooDataContext();
            // create animals objects (records)
            var monkey = new Animal { Class = "Mammal", Name = "Monkey" };
            var elephant = new Animal { Class = "Mammal", Name = "Elephant" };
            var parrot = new Animal { Class = "Bird", Name = "Parrot" };

            monkey.AddMessage("This animal record was created by User 1");
            monkey.AddMessage($"This animal was created on { DateTime.Now }");
            parrot.AddMessage("This animal was created by User 2");

            // add animals to context 
            dbContext.Animals.InsertOnSubmit(monkey);
            dbContext.Animals.InsertOnSubmit(elephant);
            dbContext.Animals.InsertOnSubmit(parrot);
            // create employee objects (records)
            var employee = new Employee { Name = "Jordan", Lastname = "Atanasovski", Age = 34 };
            dbContext.Employees.InsertOnSubmit(employee);

            // save changes
            dbContext.SubmitChanges();
        }
    }
}
