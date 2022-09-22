global using System;
global using System.Collections.Generic;
global using System.Text;
global using System.IO;
global using System.Net;
global using System.Threading.Tasks;

global using Microsoft.Extensions.Logging;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.Azure.WebJobs;
global using Microsoft.Azure.WebJobs.Extensions.Http;
global using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
global using Microsoft.OpenApi.Models;
global using Microsoft.Azure.Devices;
global using Newtonsoft.Json;

global using home.api.models;