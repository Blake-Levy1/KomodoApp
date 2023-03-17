
public class KomodoUI
{
  private DevTeamsRepository _devTeamsRepo = new DevTeamsRepository();
  private DevelopersRepository _developersRepo = new DevelopersRepository();

  public void Run()
  {
    SeedDevList();
    SeedTeamList();
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
      "4. List of developers who do not have access to PluralSight\n" +
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
          ListOfDevsWhoDoNotHaveAccessToPluralSight();
          break;
        case 5:
      // view list of teams
          ViewAllDevTeams();
          break;
        case 6:
      // create new team
          CreateNewDevTeam();
          break;
        case 7:
      // add dev to team by id
          AddDevToTeam();
          break;
        case 8:
      // remove dev from team by id
          RemoveDevFromTeam();
          break;
        case 9:
      // exit
        System.Console.WriteLine("Goodbye");
        keepRunning = false;
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
  public void ListOfDevsWhoDoNotHaveAccessToPluralSight()
  {
    List<Developers> listOfDevs = new List<Developers>();
    listOfDevs = _developersRepo.GetDevList();

    foreach (Developers dev in listOfDevs)
    {
      if (dev.PluralSight == false)
      {
        System.Console.WriteLine($"{dev.Name}\n ID: {dev.IdNumber}\n");
      }
    }

    // System.Console.WriteLine("Please enter the ID number of the developer you would like to check");
    // string idAsString = Console.ReadLine();
    // int id = int.Parse(idAsString);

    // Developers dev = _developersRepo.GetDevById(id);
    // if (dev.PluralSight == true)
    // {
    //   System.Console.WriteLine($"{dev.Name} has access to PluralSight");
    // } else if (dev.PluralSight == false)
    // {
    //   System.Console.WriteLine($"{dev.Name} does not have access to PluralSight");
    // } else 
    // {
    //   System.Console.WriteLine("This information was not found");
    // }
  }

      // view list of teams
  public void ViewAllDevTeams()
  {
    List<DevTeams> listOfDevTeams = new List<DevTeams>();
    listOfDevTeams = _devTeamsRepo.ViewDevTeams();
    foreach (DevTeams team in listOfDevTeams)
    {
      System.Console.WriteLine($"Team Name: {team.TeamName}\n Team ID: {team.TeamId}");
      foreach (Developers dev in team.DevsList)
      {
        System.Console.Write($"{dev.Name}\t");
      }
      System.Console.WriteLine("");
    }
    // System.Console.WriteLine("Enter the ID team would you like to look at?");
    // string teamIdAsString = Console.ReadLine();
    // int teamIdAsInt = int.Parse(teamIdAsString);
    // DevTeams specificTeam = _devTeamsRepo.GetDevTeamById(teamIdAsInt);

    // System.Console.WriteLine(specificTeam.DevsList);

    // List<Developers> listOfDevs = specificTeam.DevsList;
    // foreach (Developers dev in listOfDevs)
    // {
    //   System.Console.WriteLine($"{dev.Name}\n {dev.IdNumber}");
    // }
    // need to figure out how to do something along the lines of 
    // foreach (Developers dev in team.DevsList)
    // {cw($"{dev.Name})}
    
  }

      // create new team
  public void CreateNewDevTeam()
  {
    DevTeams devTeam = new DevTeams();

    System.Console.WriteLine("Enter the name of the new developer team");
    devTeam.TeamName = Console.ReadLine();

    System.Console.WriteLine("Enter the developer team ID");
    string teamIdAsString = Console.ReadLine();
    devTeam.TeamId = int.Parse(teamIdAsString);
    _devTeamsRepo.CreateDevTeam(devTeam);
  }

      // add dev to team by id
  public void AddDevToTeam()
  {
    System.Console.WriteLine("Enter the ID of the team you would like to add developers to");
    string teamIdAsString = Console.ReadLine();
    int teamIdAsInt = int.Parse(teamIdAsString);
    DevTeams team = _devTeamsRepo.GetDevTeamById(teamIdAsInt);

    List<Developers> _devsToAdd = new List<Developers>();
    string moreDevs = "";
    while (moreDevs != "n")
    {

      System.Console.WriteLine(team.TeamName);
      System.Console.WriteLine(_devsToAdd.Count);
      System.Console.WriteLine("Enter the ID of the dev you would like to add to the team");
      string devIdAsString = Console.ReadLine();
      int devIdAsInt = int.Parse(devIdAsString);
      Developers dev = _developersRepo.GetDevById(devIdAsInt);
      System.Console.WriteLine(dev.Name);
      _devsToAdd.Add(dev);
      System.Console.WriteLine("Would you like to add another developer? (y/n)");
      moreDevs = Console.ReadLine().ToLower();
    }
    _devTeamsRepo.AddDevsToTeam(team, _devsToAdd);
  }

      // remove dev from team by id
  public bool RemoveDevFromTeam()
  {
    System.Console.WriteLine("Enter the ID number of the team you would like to remove a developer from");
    string teamIdAsString = Console.ReadLine();
    int teamIdAsInt = int.Parse(teamIdAsString);
    DevTeams newTeam = _devTeamsRepo.GetDevTeamById(teamIdAsInt);
    System.Console.WriteLine("Enter the ID number of the developer you would like to remove");
    string devIdAsString = Console.ReadLine();
    int devIdAsInt = int.Parse(devIdAsString);
    Developers dev = _developersRepo.GetDevById(devIdAsInt);

    if (dev == null || newTeam == null)
    {
      return false;
    }

    int initialCount = newTeam.DevsList.Count();
    newTeam.DevsList.Remove(dev);
    int postCount = newTeam.DevsList.Count();

    if (initialCount > postCount)
    {
      return true;
    } else 
    {
      return false;
    }
  }

      // exit


  private void SeedDevList()
  {
    Developers blake = new Developers("Blake", 6, true);
    Developers mallory = new Developers("Mallory", 7, false);
    Developers keaton = new Developers("Keaton", 8, false);

    _developersRepo.AddDevelopers(blake);
    _developersRepo.AddDevelopers(mallory);
    _developersRepo.AddDevelopers(keaton);
  }

  private void SeedTeamList()
  {
    DevTeams teamOne = new DevTeams("TeamOne", 111);
    DevTeams teamTwo = new DevTeams("TeamTwo", 222);
    DevTeams teamThree = new DevTeams("TeamThree", 333);

    _devTeamsRepo.CreateDevTeam(teamOne);
    _devTeamsRepo.CreateDevTeam(teamTwo);
    _devTeamsRepo.CreateDevTeam(teamThree);
  }
}