using System;
using System.Collections.Generic;

public class DocumentSystem
{
    static public IList<IDocument> documentCollection = new List<IDocument>();

    static void Main()
    {
        IList<string> allCommands = ReadAllCommands();
        ExecuteCommands(allCommands);
    }

    private static IList<string> ReadAllCommands()
    {
        List<string> commands = new List<string>();
        while (true)
        {
            string commandLine = Console.ReadLine();
            if (commandLine == "")
            {
                // End of commands
                break;
            }
            commands.Add(commandLine);
        }
        return commands;
    }

    private static void ExecuteCommands(IList<string> commands)
    {
        foreach (var commandLine in commands)
        {
            int paramsStartIndex = commandLine.IndexOf("[");
            string cmd = commandLine.Substring(0, paramsStartIndex);
            int paramsEndIndex = commandLine.IndexOf("]");
            string parameters = commandLine.Substring(
                paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
            ExecuteCommand(cmd, parameters);
        }
    }

    private static void ExecuteCommand(string cmd, string parameters)
    {
        string[] cmdAttributes = parameters.Split(
            new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        if (cmd == "AddTextDocument")
        {
            AddTextDocument(cmdAttributes);
        }
        else if (cmd == "AddPDFDocument")
        {
            AddPdfDocument(cmdAttributes);
        }
        else if (cmd == "AddWordDocument")
        {
            AddWordDocument(cmdAttributes);
        }
        else if (cmd == "AddExcelDocument")
        {
            AddExcelDocument(cmdAttributes);
        }
        else if (cmd == "AddAudioDocument")
        {
            AddAudioDocument(cmdAttributes);
        }
        else if (cmd == "AddVideoDocument")
        {
            AddVideoDocument(cmdAttributes);
        }
        else if (cmd == "ListDocuments")
        {
            ListDocuments();
        }
        else if (cmd == "EncryptDocument")
        {
            EncryptDocument(parameters);
        }
        else if (cmd == "DecryptDocument")
        {
            DecryptDocument(parameters);
        }
        else if (cmd == "EncryptAllDocuments")
        {
            EncryptAllDocuments();
        }
        else if (cmd == "ChangeContent")
        {
            ChangeContent(cmdAttributes[0], cmdAttributes[1]);
        }
        else
        {
            throw new InvalidOperationException("Invalid command: " + cmd);
        }
    }

    private static void AddDocument(IDocument doc, string[] attributes)
    {
        foreach (var item in attributes)
        {
            string[] keysAndValues = item.Split('=');
            doc.LoadProperty(keysAndValues[0], keysAndValues[1]);
        }

        if (doc.Name != null)
        {
            Console.WriteLine("Document Added: " + doc.Name);
            documentCollection.Add(doc);
        }
        else
        {
            Console.WriteLine("Document has no name");
        }
    }

    private static void AddTextDocument(string[] attributes)
    {
        TextDocument newTextDocument = new TextDocument();
        AddDocument(newTextDocument, attributes);
    }

    private static void AddPdfDocument(string[] attributes)
    {
        PDFDocument newPdfDocumment = new PDFDocument();
        AddDocument(newPdfDocumment, attributes);
    }

    private static void AddWordDocument(string[] attributes)
    {
        WordDocument newWordDocument = new WordDocument();
        AddDocument(newWordDocument, attributes);
    }

    private static void AddExcelDocument(string[] attributes)
    {
        ExcelDocument newExcelDocument = new ExcelDocument();
        AddDocument(newExcelDocument, attributes);
    }

    private static void AddAudioDocument(string[] attributes)
    {
        AudioDocument newAudioDocument = new AudioDocument();
        AddDocument(newAudioDocument, attributes);
    }

    private static void AddVideoDocument(string[] attributes)
    {
        VideoDocument newVideoDocument = new VideoDocument();
        AddDocument(newVideoDocument, attributes);
    }

    private static void ListDocuments()
    {
        if (documentCollection.Count > 0)
        {
            foreach (var document in documentCollection)
            {
                Console.WriteLine(document);
            }
        }
        else
        {
            Console.WriteLine("No documents found");
        }
    }

    private static void EncryptDocument(string name)
    {
        bool found = false;
        foreach (var document in documentCollection)
        {
            if (document.Name == name)
            {
                found = true;
                if (document is IEncryptable)
                {
                    ((IEncryptable)document).Encrypt();
                    Console.WriteLine("Document encrypted: {0}", document.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support encryption: {0}", document.Name);
                }
            }
        }
        if (found == false)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void DecryptDocument(string name)
    {
        bool found = false;
        foreach (var document in documentCollection)
        {
            if (document.Name == name)
            {
                found = true;
                if (document is IEncryptable)
                {
                    ((IEncryptable)document).Decrypt();
                    Console.WriteLine("Document decrypted: {0}", document.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support decryption: {0}", document.Name);
                }
            }
        }
        if (found == false)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void EncryptAllDocuments()
    {
        bool encrypted = false;

        foreach (var document in documentCollection)
        {

            if (document is IEncryptable)
            {
                encrypted = true;
                ((IEncryptable)document).Encrypt();
            }
        }

        if (encrypted == true)
        {
            Console.WriteLine("All documents encrypted");
        }
        else
        {
            Console.WriteLine("No encryptable documents found");
        }
    }

    private static void ChangeContent(string name, string content)
    {
        bool found = false;
        foreach (var document in documentCollection)
        {
            if (document.Name == name)
            {
                found = true;
                if (document is IEditable)
                {
                    ((IEditable)document).ChangeContent(content);
                    Console.WriteLine("Document content changed: {0}", document.Name);
                }
                else
                {
                    Console.WriteLine("Document is not editable: {0}", document.Name);
                }
            }
        }
        if (found == false)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }
}
