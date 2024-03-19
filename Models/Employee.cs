public class Employee{
    public int Id {get; set;}
    public string? Fname { get; set; } 
    public string? Minit { get; set; }
    public string Lname { get; set; }
    public int Ssn { get; set; }
    public DateTime Bdate { get; set; }
    public string? Address { get; set; }    
    public char Sex { get; set; }
    public double Salary { get; set; }

    public Employee(int id, string fname, string minit, string lname, int ssn,
     DateTime bdate, string address, char sex,double salary ){
        this.Id = id;
        this.Fname = fname;
        this.Minit = minit;
        this.Lname = lname;
        this.Ssn = ssn;
        this.Bdate = bdate;
        this.Address = address;
        this.Sex = sex;
        this.Salary = salary;
     }
}