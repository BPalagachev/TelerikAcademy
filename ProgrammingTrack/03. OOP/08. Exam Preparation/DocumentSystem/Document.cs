using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public abstract class Document : IDocument
{
    public string Name { get; protected set; }

    public string Content { get; protected set; }

    public virtual void LoadProperty(string key, string value)
    {
        if (key == "name")
        {
            this.Name = value;
        }
        else if (key == "content")
        {
            this.Content = value;
        }
        else
        {
            throw new ArgumentException(key + " is unknow key.");
        }
    }

    public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("name", this.Name));
        output.Add(new KeyValuePair<string, object>("content", this.Content));
    }

    public override string ToString()
    {
        StringBuilder info = new StringBuilder();
        List<KeyValuePair<string, object>> properties = new List<KeyValuePair<string, object>>();
        var sortedProperties = properties.OrderBy(prop => prop.Key);

        this.SaveAllProperties(properties);

        info.Append(this.GetType().Name);
        info.Append('[');

        foreach (var prop in sortedProperties)
        {
            if (prop.Value != null)
            {
                info.Append(prop.Key);
                info.Append('=');
                info.Append(prop.Value);
                info.Append(';'); 
            }
        }
        info.Length--;
        info.Append(']');

        return info.ToString();
    }
}
