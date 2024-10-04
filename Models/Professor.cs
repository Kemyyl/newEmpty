using System;
using System.ComponentModel.DataAnnotations;

namespace newEmpty.Models;

//public enum Rank { Professor, ViceDirector, Director  }

public class Professor
{
    public int ProfessorId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Matiere { get; set; }
    public List<Student> Students { get; set; } = new();
}
