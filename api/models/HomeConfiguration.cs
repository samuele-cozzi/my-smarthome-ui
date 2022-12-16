namespace home.api.models;

public class HomeConfiguration {
    public double TargetHumidity { get; set; }
    public double TargetTemperature { get; set; }
    public double TemperatureTolerance { get; set; }
    public double IntervalThermostat { get; set; }
    public bool Enabled { get; set; }
    public string Mode { get; set; }
    public DateTime LastUpdateDate { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public string AirMode { get; set; }
    public int AirFan { get; set; }
    public int AirTemperature { get; set; }
    public List<HomeRoom> Rooms { get; set; }
}
