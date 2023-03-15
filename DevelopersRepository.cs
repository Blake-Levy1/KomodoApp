using System.Diagnostics;
using System.ComponentModel;

public class DevelopersRepository
{
  //                            LIST
  private List<Developers> _ListOfDevs = new List<Developers>();

  //                            CREATE
  public void AddDevelopers(Developers dev)
  {
    _ListOfDevs.Add(dev);
  }

  //                            READ
  public List<Developers> GetDevList()
  {
    return _ListOfDevs;
  }

  //                            UPDATE
  public bool UpdateExistingDevs(int origionalId, Developers newDevInfo)
  {
    Developers origionalDevInfo = GetDevById(origionalId);

    if (origionalDevInfo != null)
    {
      origionalDevInfo.Name = newDevInfo.Name;
      origionalDevInfo.IdNumber = newDevInfo.IdNumber;
      origionalDevInfo.PluralSight = newDevInfo.PluralSight;
      return true;
    }
    return false;
  }

  //                            DELETE
  public bool DeleteExistingDevs(int id)
  {
    Developers dev = GetDevById(id);
    
    if (dev == null)
    {
      return false;
    } 
    int initialCount = _ListOfDevs.Count();
    _ListOfDevs.Remove(dev);
    int lastCount = _ListOfDevs.Count();
    if (initialCount > lastCount)
    {
      return true;
    } else 
    {
    return false;
    }
  }

  //                            HELPER METHODS
  public Developers GetDevById(int id)
  {
    foreach (Developers dev in _ListOfDevs)
    {
      if (dev.IdNumber == id)
      {
        return dev;
      }
    }
    return null;
  }
}