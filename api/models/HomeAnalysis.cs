namespace home.api.models;

public class HomeAnalysis {
    public string DeviceId { get; set; }
    public DateTime Timestamp { get; set; }
    public double? Temperature { get; set; }
    public double? Humidity { get; set; }
    public double? HeatIndex { get; set; }

    public bool? ACPower { get; set; }
    public double? ACTemp { get; set; }
    public string ACMode { get; set; }
    public int? ACFan { get; set; }

    public int TargetHumidity { get; set; }
    public int TargetTemperature { get; set; }
    public int TargetHeatIndex { get; set; }
}