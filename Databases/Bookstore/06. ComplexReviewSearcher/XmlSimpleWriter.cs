using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

public class XmlSimpleWriter
{
    public XmlTextWriter Writer { get; private set; }

    public XmlSimpleWriter(string filename, Encoding encoding)
    {
        this.FileName = filename;
        this.Encoding = encoding;
    }

    public string FileName { get; set; }

    public Encoding Encoding { get; set; }

    public void InitializeReader(string rootElement)
    {
        this.Writer = new XmlTextWriter(this.FileName, this.Encoding);
        Writer.Formatting = Formatting.Indented;
        Writer.IndentChar = '\t';
        Writer.Indentation = 1;
        Writer.WriteStartDocument();
        Writer.WriteStartElement(rootElement);
    }

    public void CloseReader()
    {
        Writer.WriteEndDocument();
        Writer.Dispose();
    }

    public void OpenTag(string name, IEnumerable<KeyValuePair<string, string>> innerElements = null)
    {
        Writer.WriteStartElement(name);
        if (innerElements != null)
        {
            foreach (var inner in innerElements)
            {
                this.AddSimpleTag(inner.Key, inner.Value);
            }
        }
    }

    public void CloseTag()
    {
        Writer.WriteEndElement();
    }

    public void AddSimpleTag(string name, string value)
    {
        Writer.WriteElementString(name, value);
    }

    public void AddAttributes(IEnumerable<KeyValuePair<string, string>> attbibutesPairs)
    {
        foreach (var attr in attbibutesPairs)
        {
            Writer.WriteAttributeString(attr.Key, attr.Value);
        }
    }

}