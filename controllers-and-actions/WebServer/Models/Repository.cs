using System.Collections.Generic;
using System.Linq;

namespace WebServer.Models
{
    public class Repository
    {
        private static int counter = 0;
        public static IList<Person> People{get;} = new List<Person>();

        public static Person GetPersonByID(int id)
        {
            var target = People.SingleOrDefault(p => p.ID == id);
            return target;
        }

        public static void RemovePersonByID(int id)
        {
            var target = People.SingleOrDefault(p => p.ID == id);
            if (target != null) {
                People.Remove(target);
            }
        }

        public static void ReplacePersonByID(int id, Person person)
        {
            var target = People.SingleOrDefault(p => p.ID == id);
            if (target != null) {
                People.Remove(target);
                People.Add(person);
            }
        }

        public static void AddPerson(Person person) {
            person.ID = counter++;
            People.Add(person);
        }
        
    }
}