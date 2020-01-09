using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Music.Models
{
  public class Record
  {
    private static List<Record> _instances = new List<Record> { };
    public string Title { get; set; }
    public int Id { get; set; }
    public List<Artist> Artists { get; set; }

    public Record(string title)
    {
      Title = title;
      _instances.Add(this);
      Id = _instances.Count;
      Artists = new List<Artist> { };
    }

    public static List<Record> GetAll()
    {
      return _instances;
    }
    
      public static Record Find(int searchId)
    {
      return _instances[searchId - 1];
    }

    public void AddArtist(Artist artist)
    {
    Artists.Add(artist);
    }
  }
}