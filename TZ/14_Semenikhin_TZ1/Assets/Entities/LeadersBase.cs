using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

public class LeadersBase
{
    private readonly string xmlFolderPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/Cube Clicker";
    private readonly string xmlFileName = $"leaders.xml";

    public List<LeaderType> Leaders;

    private LeadersBase()
    {
        Leaders = new List<LeaderType>();

        LoadData();
    }

    private static LeadersBase _context;

    public static LeadersBase GetContext()
    {
        if (_context == null)
        {
            _context = new LeadersBase();
        }

        return _context;
    }

    private void CheckBase()
    {
        if (!Directory.Exists(xmlFolderPath))
        {
            Directory.CreateDirectory(xmlFolderPath);
        }

        if (!File.Exists($"{xmlFolderPath}/{xmlFileName}"))
        {
            XDocument xDoc = new XDocument(new XElement("leaders"));

            xDoc.Save($"{xmlFolderPath}/{xmlFileName}");
        }
    }

    private void LoadData()
    {
        CheckBase();

        XDocument xDoc = XDocument.Load($"{xmlFolderPath}/{xmlFileName}");

        foreach (var leader in xDoc.Root.Elements())
        {
            Leaders.Add(new LeaderType()
            {
                Id = int.Parse(leader.Attribute("id").Value),
                Nickname = leader.Element("nickname").Value,
                CubeCount = int.Parse(leader.Element("cubecount").Value)
            });
        }

        Leaders = Leaders.OrderByDescending(x => x.CubeCount).ToList();
    }

    public void SaveData()
    {
        XDocument xDoc = new XDocument();
        XElement root = new XElement("leaders");

        foreach (var leader in Leaders.OrderByDescending(x => x.CubeCount).ToList())
        {
            root.Add(new XElement("leader",
                new XAttribute("id", leader.Id),
                new XElement("nickname", leader.Nickname),
                new XElement("cubecount", leader.CubeCount)));
        }

        xDoc.Add(root);
        xDoc.Save($"{xmlFolderPath}/{xmlFileName}");
    }
}
