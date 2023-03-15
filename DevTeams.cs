
public class DevTeams
{
  public List<Developers> DevsList { get; set; }
  public string TeamName { get; set; }
  public int TeamId { get; set; }

  public DevTeams () {}

  public DevTeams (List<Developers> devsList, string teamName, int teamId)
  {
    DevsList = devsList;
    TeamName = teamName;
    TeamId = teamId;
  }
}