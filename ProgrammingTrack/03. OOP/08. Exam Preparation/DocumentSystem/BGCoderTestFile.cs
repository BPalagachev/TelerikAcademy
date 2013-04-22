//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//public class AudioDocument : MultimediaDocument
//{
//    public long? SampleRate { get; protected set; }

//    public override void LoadProperty(string key, string value)
//    {
//        if (key == "samplerate")
//        {
//            this.SampleRate = long.Parse(value);
//        }
//        else
//        {
//            base.LoadProperty(key, value);
//        }
//    }

//    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
//    {
//        output.Add(new KeyValuePair<string, object>("samplerate", this.SampleRate));
//        base.SaveAllProperties(output);
//    }
//}

//public abstract class BinaryDocument : Document
//{
//    public long? Size { get; protected set; }

//    public override void LoadProperty(string key, string value)
//    {
//        if (key == "size")
//        {
//            this.Size = long.Parse(value);
//        }
//        else
//        {
//            base.LoadProperty(key, value);
//        }
//    }

//    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
//    {
//        output.Add(new KeyValuePair<string, object>("size", this.Size));
//        base.SaveAllProperties(output);
//    }
//}

//public abstract class Document : IDocument
//{
//    public string Name { get; protected set; }

//    public string Content { get; protected set; }

//    public virtual void LoadProperty(string key, string value)
//    {
//        if (key == "name")
//        {
//            this.Name = value;
//        }
//        else if (key == "content")
//        {
//            this.Content = value;
//        }
//        else
//        {
//            throw new ArgumentException(key + " is unknow key.");
//        }
//    }

//    public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
//    {
//        output.Add(new KeyValuePair<string, object>("name", this.Name));
//        output.Add(new KeyValuePair<string, object>("content", this.Content));
//    }

//    public override string ToString()
//    {
//        StringBuilder info = new StringBuilder();
//        List<KeyValuePair<string, object>> properties = new List<KeyValuePair<string, object>>();
//        var sortedProperties = properties.OrderBy(prop => prop.Key);

//        this.SaveAllProperties(properties);

//        info.Append(this.GetType().Name);
//        info.Append('[');

//        foreach (var prop in sortedProperties)
//        {
//            if (prop.Value != null)
//            {
//                info.Append(prop.Key);
//                info.Append('=');
//                info.Append(prop.Value);
//                info.Append(';');
//            }
//        }
//        info.Length--;
//        info.Append(']');

//        return info.ToString();
//    }
//}

//public abstract class EncryptableBinaryDocument : BinaryDocument, IEncryptable
//{
//    protected bool isEncrypted = false;

//    public virtual bool IsEncrypted
//    {
//        get
//        {
//            return this.isEncrypted;
//        }
//    }

//    public virtual void Encrypt()
//    {
//        this.isEncrypted = true;
//    }

//    public virtual void Decrypt()
//    {
//        this.isEncrypted = false;
//    }

//    public override string ToString()
//    {
//        if (this.IsEncrypted == true)
//        {
//            return this.GetType().Name + "[encrypted]";
//        }
//        else
//        {
//            return base.ToString();
//        }
//    }
//}

//public class ExcelDocument : OfficeDocument
//{
//    public long? Rows { get; protected set; }
//    public long? Cols { get; protected set; }

//    public override void LoadProperty(string key, string value)
//    {
//        if (key == "rows")
//        {
//            this.Rows = long.Parse(value);
//        }
//        else if (key == "cols")
//        {
//            this.Cols = long.Parse(value);
//        }
//        else
//        {
//            base.LoadProperty(key, value);
//        }
//    }

//    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
//    {
//        output.Add(new KeyValuePair<string, object>("rows", this.Rows));
//        output.Add(new KeyValuePair<string, object>("cols", this.Cols));

//        base.SaveAllProperties(output);
//    }
//}

//public abstract class OfficeDocument : EncryptableBinaryDocument
//{
//    public string Version { get; protected set; }

//    public override void LoadProperty(string key, string value)
//    {
//        if (key == "version")
//        {
//            this.Version = value;
//        }
//        else
//        {
//            base.LoadProperty(key, value);
//        }
//    }

//    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
//    {
//        output.Add(new KeyValuePair<string, object>("version", this.Version));
//        base.SaveAllProperties(output);
//    }
//}

//public interface IDocument
//{
//    string Name { get; }
//    string Content { get; }
//    void LoadProperty(string key, string value);
//    void SaveAllProperties(IList<KeyValuePair<string, object>> output);
//    string ToString();
//}

//public interface IEditable
//{
//    void ChangeContent(string newContent);
//}

//public interface IEncryptable
//{
//    bool IsEncrypted { get; }
//    void Encrypt();
//    void Decrypt();
//}

//public abstract class MultimediaDocument : BinaryDocument
//{
//    public long? Length { get; protected set; }

//    public override void LoadProperty(string key, string value)
//    {
//        if (key == "length")
//        {
//            this.Length = long.Parse(value);
//        }
//        else
//        {
//            base.LoadProperty(key, value);
//        }
//    }

//    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
//    {
//        output.Add(new KeyValuePair<string, object>("length", this.Length));
//        base.SaveAllProperties(output);
//    }
//}

//public class PDFDocument : EncryptableBinaryDocument
//{
//    public long? Pages { get; protected set; }

//    public override void LoadProperty(string key, string value)
//    {
//        if (key == "pages")
//        {
//            this.Pages = long.Parse(value);
//        }
//        else
//        {
//            base.LoadProperty(key, value);
//        }
//    }

//    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
//    {
//        output.Add(new KeyValuePair<string, object>("pages", this.Pages));
//        base.SaveAllProperties(output);
//    }
//}

//public class TextDocument : Document, IEditable
//{
//    public string Charset { get; protected set; }

//    public override void LoadProperty(string key, string value)
//    {
//        if (key == "charset")
//        {
//            this.Charset = value;
//        }
//        else
//        {
//            base.LoadProperty(key, value);
//        }
//    }

//    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
//    {
//        output.Add(new KeyValuePair<string, object>("charset", this.Charset));
//        base.SaveAllProperties(output);
//    }

//    public void ChangeContent(string newContent)
//    {
//        this.Content = newContent;
//    }
//}

//public class VideoDocument : MultimediaDocument
//{
//    public long? FrameRate { get; protected set; }

//    public override void LoadProperty(string key, string value)
//    {
//        if (key == "framerate")
//        {
//            this.FrameRate = long.Parse(value);
//        }
//        else
//        {
//            base.LoadProperty(key, value);
//        }
//    }

//    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
//    {
//        output.Add(new KeyValuePair<string, object>("framerate", this.FrameRate));
//        base.SaveAllProperties(output);
//    }
//}

//public class WordDocument : OfficeDocument, IEditable
//{
//    public long? Chars { get; protected set; }

//    public override void LoadProperty(string key, string value)
//    {
//        if (key == "chars")
//        {
//            this.Chars = long.Parse(value);
//        }
//        else
//        {
//            base.LoadProperty(key, value);
//        }
//    }

//    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
//    {
//        output.Add(new KeyValuePair<string, object>("chars", this.Chars));
//        base.SaveAllProperties(output);
//    }

//    public void ChangeContent(string newContent)
//    {
//        this.Content = newContent;
//    }
//}

//public class DocumentSystem
//{
//    static public IList<IDocument> documentCollection = new List<IDocument>();

//    static void Main()
//    {
//        IList<string> allCommands = ReadAllCommands();
//        ExecuteCommands(allCommands);
//    }

//    private static IList<string> ReadAllCommands()
//    {
//        List<string> commands = new List<string>();
//        while (true)
//        {
//            string commandLine = Console.ReadLine();
//            if (commandLine == "")
//            {
//                // End of commands
//                break;
//            }
//            commands.Add(commandLine);
//        }
//        return commands;
//    }

//    private static void ExecuteCommands(IList<string> commands)
//    {
//        foreach (var commandLine in commands)
//        {
//            int paramsStartIndex = commandLine.IndexOf("[");
//            string cmd = commandLine.Substring(0, paramsStartIndex);
//            int paramsEndIndex = commandLine.IndexOf("]");
//            string parameters = commandLine.Substring(
//                paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
//            ExecuteCommand(cmd, parameters);
//        }
//    }

//    private static void ExecuteCommand(string cmd, string parameters)
//    {
//        string[] cmdAttributes = parameters.Split(
//            new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
//        if (cmd == "AddTextDocument")
//        {
//            AddTextDocument(cmdAttributes);
//        }
//        else if (cmd == "AddPDFDocument")
//        {
//            AddPdfDocument(cmdAttributes);
//        }
//        else if (cmd == "AddWordDocument")
//        {
//            AddWordDocument(cmdAttributes);
//        }
//        else if (cmd == "AddExcelDocument")
//        {
//            AddExcelDocument(cmdAttributes);
//        }
//        else if (cmd == "AddAudioDocument")
//        {
//            AddAudioDocument(cmdAttributes);
//        }
//        else if (cmd == "AddVideoDocument")
//        {
//            AddVideoDocument(cmdAttributes);
//        }
//        else if (cmd == "ListDocuments")
//        {
//            ListDocuments();
//        }
//        else if (cmd == "EncryptDocument")
//        {
//            EncryptDocument(parameters);
//        }
//        else if (cmd == "DecryptDocument")
//        {
//            DecryptDocument(parameters);
//        }
//        else if (cmd == "EncryptAllDocuments")
//        {
//            EncryptAllDocuments();
//        }
//        else if (cmd == "ChangeContent")
//        {
//            ChangeContent(cmdAttributes[0], cmdAttributes[1]);
//        }
//        else
//        {
//            throw new InvalidOperationException("Invalid command: " + cmd);
//        }
//    }

//    private static void AddDocument(IDocument doc, string[] attributes)
//    {
//        foreach (var item in attributes)
//        {
//            string[] keysAndValues = item.Split('=');
//            doc.LoadProperty(keysAndValues[0], keysAndValues[1]);
//        }

//        if (doc.Name != null)
//        {
//            Console.WriteLine("Document added: " + doc.Name);
//            documentCollection.Add(doc);
//        }
//        else
//        {
//            Console.WriteLine("Document has no name");
//        }
//    }

//    private static void AddTextDocument(string[] attributes)
//    {
//        TextDocument newTextDocument = new TextDocument();
//        AddDocument(newTextDocument, attributes);
//    }

//    private static void AddPdfDocument(string[] attributes)
//    {
//        PDFDocument newPdfDocumment = new PDFDocument();
//        AddDocument(newPdfDocumment, attributes);
//    }

//    private static void AddWordDocument(string[] attributes)
//    {
//        WordDocument newWordDocument = new WordDocument();
//        AddDocument(newWordDocument, attributes);
//    }

//    private static void AddExcelDocument(string[] attributes)
//    {
//        ExcelDocument newExcelDocument = new ExcelDocument();
//        AddDocument(newExcelDocument, attributes);
//    }

//    private static void AddAudioDocument(string[] attributes)
//    {
//        AudioDocument newAudioDocument = new AudioDocument();
//        AddDocument(newAudioDocument, attributes);
//    }

//    private static void AddVideoDocument(string[] attributes)
//    {
//        VideoDocument newVideoDocument = new VideoDocument();
//        AddDocument(newVideoDocument, attributes);
//    }

//    private static void ListDocuments()
//    {
//        if (documentCollection.Count > 0)
//        {
//            foreach (var document in documentCollection)
//            {
//                Console.WriteLine(document);
//            }
//        }
//        else
//        {
//            Console.WriteLine("No documents found");
//        }
//    }

//    private static void EncryptDocument(string name)
//    {
//        bool found = false;
//        foreach (var document in documentCollection)
//        {
//            if (document.Name == name)
//            {
//                found = true;
//                if (document is IEncryptable)
//                {
//                    ((IEncryptable)document).Encrypt();
//                    Console.WriteLine("Document encrypted: {0}", document.Name);
//                }
//                else
//                {
//                    Console.WriteLine("Document does not support encryption: {0}", document.Name);
//                }
//            }
//        }
//        if (found == false)
//        {
//            Console.WriteLine("Document not found: {0}", name);
//        }
//    }

//    private static void DecryptDocument(string name)
//    {
//        bool found = false;
//        foreach (var document in documentCollection)
//        {
//            if (document.Name == name)
//            {
//                found = true;
//                if (document is IEncryptable)
//                {
//                    ((IEncryptable)document).Decrypt();
//                    Console.WriteLine("Document decrypted: {0}", document.Name);
//                }
//                else
//                {
//                    Console.WriteLine("Document does not support decryption: {0}", document.Name);
//                }
//            }
//        }
//        if (found == false)
//        {
//            Console.WriteLine("Document not found: {0}", name);
//        }
//    }

//    private static void EncryptAllDocuments()
//    {
//        bool encrypted = false;

//        foreach (var document in documentCollection)
//        {

//            if (document is IEncryptable)
//            {
//                encrypted = true;
//                ((IEncryptable)document).Encrypt();
//            }
//        }

//        if (encrypted == true)
//        {
//            Console.WriteLine("All documents encrypted");
//        }
//        else
//        {
//            Console.WriteLine("No encryptable documents found");
//        }
//    }

//    private static void ChangeContent(string name, string content)
//    {
//        bool found = false;
//        foreach (var document in documentCollection)
//        {
//            if (document.Name == name)
//            {
//                found = true;
//                if (document is IEditable)
//                {
//                    ((IEditable)document).ChangeContent(content);
//                    Console.WriteLine("Document content changed: {0}", document.Name);
//                }
//                else
//                {
//                    Console.WriteLine("Document is not editable: {0}", document.Name);
//                }
//            }
//        }
//        if (found == false)
//        {
//            Console.WriteLine("Document not found: {0}", name);
//        }
//    }
//}
