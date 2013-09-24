using System;
using System.Collections.Generic;
using System.Linq;

public class QueryResult
{
    public DateTime Date { get; set; }

    public string Content { get; set; }

    public string BookTitle { get; set; }

    public string BookUrl { get; set; }

    public IEnumerable<string> BookAuthors { get; set; }
}
    
