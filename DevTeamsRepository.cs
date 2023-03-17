using System.Collections.Generic;

public class DevTeamsRepository
{

  private Developers _devRepo = new Developers();

  //                        LIST
  private List<DevTeams> _ListOfDevTeams = new List<DevTeams>();

  //                        CREATE
  public void CreateDevTeam(DevTeams team)
  {
    _ListOfDevTeams.Add(team);
  }

  //                        READ
  public List<DevTeams> ViewDevTeams()
  {
    return _ListOfDevTeams;
  }

  //                        UPDATE
  public bool UpdateExistingDevTeams(int origionalId, DevTeams newTeamInfo)
  {
    DevTeams origionalTeamInfo = GetDevTeamById(origionalId);

    if (origionalTeamInfo != null)
    {
      origionalTeamInfo.TeamName = newTeamInfo.TeamName;
      origionalTeamInfo.DevsList = newTeamInfo.DevsList;
      origionalTeamInfo.TeamId = newTeamInfo.TeamId;
      return true;
    }
    return false;
  }

  //                        DELETE
  public bool DeleteExistingDevTeams(int id)
  {
    DevTeams team = GetDevTeamById(id);

    if (team == null)
    {
      return false;
    }
    int preCount = _ListOfDevTeams.Count;
    _ListOfDevTeams.Remove(team);
    int postCount = _ListOfDevTeams.Count;
    if (preCount > postCount)
    {
      return true;
    } else 
    {
      return false;
    }
  }

  //                        HELPER METHODS
  public DevTeams GetDevTeamById(int id)
  {
    foreach (DevTeams team in _ListOfDevTeams)
    {
      if (team.TeamId == id)
      {
        return team;
      }
    }
    return null;
  }
    // foreach (DevTeams team in _ListOfDevTeams)
    // {
    //   if (team.TeamId == id)
    //   {
    //     return team;
    //   }
    // }
    // return null;

  public bool AddDevsToTeam(DevTeams team, List<Developers> devsToAdd)
  {
    if (devsToAdd.Count != 0)
    {
      foreach (Developers dev in devsToAdd)
      {
        team.DevsList.Add(dev);
      }
        return true;
    }
    return false;

  }
}