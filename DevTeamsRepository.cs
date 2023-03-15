using System.Collections.Generic;

public class DevTeamsRepository
{
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
}