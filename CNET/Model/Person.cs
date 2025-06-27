namespace Model;

/// <summary>
/// Osoba v systému
/// </summary>
public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    
    /// <summary>
    /// Datum narození
    /// </summary>
    public DateTime DateOfBirth { get; set; }
    public Address? Address { get; set; }
    public ICollection<Contract> Contracts { get; set; }
}

