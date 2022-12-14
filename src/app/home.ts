export interface Device {
    Id: string;
    Name: string;
    Type: string;
}

export interface Room {
    Name: string;
    Devices: Device[];
}

export interface Configuration {
    TargetHumidity: number;
    TargetTemperature: number;
    TemperatureTolerance: number;
    IntervalThermostat: number;
    Enabled: boolean;
    LastUpdateDate: string,
    StartTime: string;
    EndTime: string;
    Mode: string;
    AirMode: string;
    AirFan: number;
    AirTemperature: number;
    Rooms: Room[];
}

export interface AirConditioner {
    DeviceId: string;
    Power: boolean;
    Temp: number;
    Mode: string;
    Fan: number;
}

export interface Thermostat {
    deviceId: string;
    temperature: number;
    humidity: number;
    heatIndex: number;
}

export interface Home {
    Configuration: Configuration;
    AirConditioners: AirConditioner[];
    Thermostats: Thermostat[];
}


