using static autotest.Models.FuelTable;
using System.Xml.Serialization;

namespace autotest.Models;

[XmlRoot(ElementName = "GENERATION_BY_FUEL_TYPE_TABLE")]
public class FuelTable
{
    public FuelTable()
    {
        InstFuels = new InstFuels();
        HhFuels = new HhFuels();
        Last24Fuels = new Last24Fuels();
        Updated = new LastUpdated();
    }

    [XmlElement(ElementName = "INST")]
    public InstFuels InstFuels { get; set; }

    [XmlElement(ElementName = "HH")]
    public HhFuels HhFuels { get; set; }

    [XmlElement(ElementName = "LAST24H")]
    public Last24Fuels Last24Fuels { get; set; }

    [XmlElement("LAST_UPDATED")]
    public LastUpdated Updated { get; set; }

}

public class InstFuels
{
    [XmlAttribute("AT")]
    public string? At { get; set; }
    [XmlAttribute("TOTAL")]
    public string? Total { get; set; }
    [XmlElement(ElementName = "FUEL")]
    public List<Fuel> Fuels { get; set; }
}

public class HhFuels
{
    [XmlAttribute("SD")]
    public string? Sp { get; set; }
    [XmlAttribute("SP")]
    public string? Sd { get; set; }
    [XmlAttribute("AT")]
    public string? At { get; set; }
    [XmlAttribute("TOTAL")]
    public string? Total { get; set; }
    [XmlElement(ElementName = "FUEL")]
    public List<Fuel> Fuels { get; set; }
}

public class Last24Fuels
{
    [XmlAttribute("FROM_SD")]
    public string? FromSd { get; set; }
    [XmlAttribute("FROM_SP")]
    public string? FromSp { get; set; }
    [XmlAttribute("AT")]
    public string? At { get; set; }
    [XmlAttribute("TOTAL")]
    public string? Total { get; set; }
    [XmlElement(ElementName = "FUEL")]
    public List<Fuel> Fuels { get; set; }
}

public class LastUpdated
{
    [XmlAttribute("AT")]
    public string? At { get; set; }
}


public class InstFuel
{
    public List<Fuel>? Fuels { get; set; }
}

public class Fuel
    {
        [XmlAttribute("TYPE")]
        public string Type { get; set; }

        [XmlAttribute("IC")]
        public string Ic { get; set; }

        [XmlAttribute("VAL")]
        public string Val { get; set; }

        [XmlAttribute("PCT")]
        public string Pct { get; set; }
    }
