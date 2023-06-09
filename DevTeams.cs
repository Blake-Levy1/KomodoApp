
public class DevTeams
{
  public List<Developers> DevsList = new List<Developers>();
  public string TeamName { get; set; }
  public int TeamId { get; set; }

  public DevTeams () {}

  public DevTeams (string teamName, int teamId)
  {
    TeamName = teamName;
    TeamId = teamId;
  }

  public DevTeams (List<Developers> devsList, string teamName, int teamId)
  {
    DevsList = devsList;
    TeamName = teamName;
    TeamId = teamId;
  }
}