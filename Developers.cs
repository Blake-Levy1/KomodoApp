
  // POCO
public class Developers
{
  public string Name { get; set; }
  public int IdNumber { get; set; }
  public bool PluralSight { get; set; }


  public Developers () {}
  public Developers (string name, int idNumber, bool pluralSight)
  {
    Name = name;
    IdNumber = idNumber;
    PluralSight = pluralSight;
  }
}