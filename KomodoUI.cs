
public class KomodoUI
{
  private DevTeamsRepository _devTeamsRepo = new DevTeamsRepository();
  private DevelopersRepository _developersRepo = new DevelopersRepository();

  public void Run()
  {
    Menu();
  }

  private void Menu()
  {
    bool keepRunning = true;
    while (keepRunning)
    {
      System.Console.WriteLine("Select a menu option:\n" +
      "1. View list of develpers\n" +
      "2. Add new developer to directory\n" +
      "3. Identify developer by ID\n" +
      "4. Find out if dev has access to PluralSight\n" +
      "5. View list of dev teams\n" +
      "6. Create new dev team\n" +
      "7. Add dev to team by ID\n" +
      "8. Remove dev from team by ID\n" +
      "9. Exit");

      string inputAsString = Console.ReadLine();
      int inputAsInt = int.Parse(inputAsString);

      switch (inputAsInt)
      {
        case 1:
      // view list of developers
          ViewListOfDevs();
          break;
        case 2:
      // add new developer to directory
          AddNewDevToDirectory();
          break;
        case 3:
      // identify developer
          IdentifyDevById();
          break;
        case 4:
      // find out if dev has access to pluralsight

          break;
        case 5:
      // view list of teams

          break;
        case 6:
      // create new team

          break;
        case 7:
      // add dev to team by id

          break;
        case 8:
      // remove dev from team by id

          break;
        case 9:
      // exit

        break;
      }

      System.Console.WriteLine("Press any key to continue...");
      Console.ReadKey();
      Console.Clear();
    }
  }

      // view list of developers
  public void ViewListOfDevs()
  {
    Console.Clear();
    List<Developers> listOfDevelopers = _developersRepo.GetDevList();

    foreach (Developers devs in listOfDevelopers)
    {
      System.Console.WriteLine($"Name:{devs.Name}\nID:{devs.IdNumber}");
    }
  }

      // add new developer to directory
  public void AddNewDevToDirectory()
  {
    Developers newDev = new Developers();
    // TITLE
    System.Console.WriteLine("Enter the Name of the new developer");
    newDev.Name = Console.ReadLine();
    // ID NUMBER
    System.Console.WriteLine("Enter the ID number for the new developer");
    string idAsString = Console.ReadLine();
    newDev.IdNumber = int.Parse(idAsString);
    // PluralSight
    System.Console.WriteLine("Does this dev have access to PluralSight? (y/n)");
    string pluralSight = Console.ReadLine().ToLower();
    if (pluralSight == "y")
    {
      newDev.PluralSight = true;
    } else if ( pluralSight == "n")
    {
      newDev.PluralSight = false;
    }
    else 
    {
      System.Console.WriteLine("Please enter a valid answer");
    }
    _developersRepo.AddDevelopers(newDev);
  }

      // identify developer
  public void IdentifyDevById()
  {
    System.Console.WriteLine("Enter the ID number of the developer you would like to find");

    string idAsString = Console.ReadLine();
    int idNumber = int.Parse(idAsString);

    Developers dev = _developersRepo.GetDevById(idNumber);

    if (dev != null)
    {
      System.Console.WriteLine($"Developer Name: {dev.Name}\n" +
      $"Developer ID Number: {dev.IdNumber}\n" +
      $"Developer has access to PluralSight: {dev.PluralSight}");
    } else 
    {
      System.Console.WriteLine("No developer exists with that ID number");
    }
  }

      // find out if dev has access to pluralsight
  

      // view list of teams


      // create new team


      // add dev to team by id


      // remove dev from team by id


      // exit

}