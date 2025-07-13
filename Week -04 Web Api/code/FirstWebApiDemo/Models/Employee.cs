namespace FirstWebApi.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int salary {  get; set; }
        public bool permanent { get; set; }
        //public  Department department{ get; set; }
        public Department Department { get;  set; }
        public List<Skill> Skills { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
