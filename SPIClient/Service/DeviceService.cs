using System.Threading.Tasks;
using RestSharp;
using RestSharp.Deserializers;

namespace SPIClient.Service
{
    public class DeviceAddressStatus
    {
        [DeserializeAs(Name = "ip")]
        public string Address { get; set; }

        [DeserializeAs(Name = "last_udpated")]
        public string LastUpdated { get; set; }
    }

    public class DeviceAddressService
    {
        private const string ApiKeyHeader = "ASM-MSP-DEVICE-ADDRESS-API-KEY";
        private const string 

        public async Task<DeviceAddressStatus> RetrieveService(string serialNumber, string apiKey, bool isTestMode)
        {
            var deviceAddressUri = isTestMode ? $"https://device-address-api-sb.wbc.msp.assemblypayments.com/v1/{serialNumber}/ip" : $"https://device-address-api.wbc.msp.assemblypayments.com/v1/{serialNumber}/ip";

            var addressService = new HttpBaseService(deviceAddressUri);
            var request = new RestRequest(Method.GET);
            request.AddHeader(ApiKeyHeader, apiKey);

            var response = await addressService.SendRequest<DeviceAddressStatus>(request);
            return response;
        }
    }
}