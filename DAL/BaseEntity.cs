using System.Collections.Generic;

namespace L2SInheritance.DAL
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Messages = new List<string>();
        }

        public void AddMessage(string message)
        {
            Messages.Add(message);
        }

        public ICollection<string> Messages { get; set; }
    }
}
