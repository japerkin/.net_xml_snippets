﻿

using System.Xml;
using System.Xml.Linq;

XElement notesFromFile = XElement.Load(@"data1.xml");

IEnumerable<XElement> notes = notesFromFile.Elements();

// Get all notes

foreach ( var note in notes )
{
  Console.WriteLine( note?.Element("heading")?.Value );
}


// Only get the archived notes.

IEnumerable<XElement> archivedNotes = from el in notesFromFile.Elements("note")
                                      where (string)el?.Attribute("archived") == "true"
                                      select el;
                    

Console.WriteLine(archivedNotes.Count());

foreach (XElement el in archivedNotes)
{
  Console.WriteLine(el);
}



/*******************************/

IEnumerable<XElement> notesFromJacob = from e in notesFromFile.Elements("note")
                                  where (string)e?.Element("from")?.Value.ToLower() == "jacob".ToLower()
                                  select e;

var messagesFromJacob = notesFromJacob?.ToList<XElement>();

Console.WriteLine(messagesFromJacob[0]);

Console.WriteLine(messagesFromJacob?.First().Element("heading").Value);