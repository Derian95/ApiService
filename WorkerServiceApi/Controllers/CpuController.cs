using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Management;

namespace WorkerServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CpuController : ControllerBase
    {

        [HttpPost]
        public async Task<dynamic> CpuPorcentaje()
        {
            dynamic estadoCpu = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT LoadPercentage FROM Win32_Processor");
            ManagementObjectCollection results = searcher.Get();
            foreach (ManagementObject obj in results)
            {
                int usage = Convert.ToInt32(obj["LoadPercentage"]);
                estadoCpu = usage;
            }
            return estadoCpu;

        }
    }
}
