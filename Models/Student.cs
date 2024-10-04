using System;

namespace newEmpty.Models;

public enum Major { CS, IT, MATH, OTHER }

public class Student
{
    public int StudentId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime  BirthDate { get; set; }

    public List<Professor>   Professors { get; set; } = new();

}
