using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;  
using Music.Models;

namespace Music.Controllers
{
  public class RecordController : Controller
  {
      [HttpGet("/record/new")]//First main user page;
      public ActionResult Template() { return View(); }

     [HttpPost("/record")]//
      public ActionResult Second(string title) 
      {
      Record myRecord = new Record(title);
      System.Console.WriteLine(myRecord.Title);
      List<Record> allRecords = Record.GetAll();
      System.Console.WriteLine(allRecords.Count);
      foreach(Record record in allRecords)
      {
        System.Console.WriteLine(record.Title);
      }
      return View("Second",allRecords);
      }

      [HttpGet("/record/{id}")]
      public ActionResult Show(int id)
      {
      Dictionary<string, object> model = new Dictionary<string, object>(); //new dic

      Record selectedRecord = Record.Find(id);

      List<Artist> recordArtists = selectedRecord.Artists;

      model.Add("category", selectedRecord);

      model.Add("items", recordArtists);

      return View(model);
      }
    }
  }
