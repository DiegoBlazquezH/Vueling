namespace Redis.Common.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }


        public Student(int iD, string name, string surname)
        {
            ID = iD;
            Name = name;
            Surname = surname;
        }

        public override string ToString()
        {
            return string.Concat(ID, ",", Name, ",", Surname);
        }
    }
}