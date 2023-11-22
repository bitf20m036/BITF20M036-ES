//File Format Adapter
using System;
public interface IDataProcessor
{
    void ProcessData(string data);
}

public class XmlDataProcessor : IDataProcessor
{
    public void ProcessData(string data)
    {
        Console.WriteLine("Processing XML data: " + data);
    }
}
public interface IJsonDataComponent
{
    void ProcessJsonData(string jsonData);
}

public class JsonDataComponent : IJsonDataComponent
{
    public void ProcessJsonData(string jsonData)
    {
        Console.WriteLine("Processing JSON data: " + jsonData);
    }
}
public class JsonDataAdapter : IDataProcessor
{
    private readonly IJsonDataComponent jsonDataComponent;

    public JsonDataAdapter(IJsonDataComponent jsonDataComponent)
    {
        this.jsonDataComponent = jsonDataComponent;
    }

    public void ProcessData(string data)
    {
        string jsonData = ConvertXmlToJson(data);
        jsonDataComponent.ProcessJsonData(jsonData);
    }

    private string ConvertXmlToJson(string xmlData)
    {
        Console.WriteLine("Converting XML to JSON");
        return "{ \"convertedData\": \"JSON data\" }";
    }
}
class Program
{
    static void Main()
    {
        var jsonDataAdapter = new JsonDataAdapter(new JsonDataComponent());
        jsonDataAdapter.ProcessData("<xml>Data</xml>");
    }
}
