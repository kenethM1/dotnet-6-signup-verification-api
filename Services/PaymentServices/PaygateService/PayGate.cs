using WebApi.Helpers;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using System.Text;
using Newtonsoft.Json.Serialization;

public class PayGate : IPayGate{

    private readonly AppSettings _appSettings;

    public PayGate(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }
    public PayGateResponse Pay(PayGatePaymentRequest request)
    {
        var payGateUrl = _appSettings.PaygateInfo.PayGateUrl;
        var requestString = JsonConvert.SerializeObject(request, new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        });
        var paymentRequest = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(payGateUrl+"/payments"),                    
            Content = new StringContent(requestString, Encoding.UTF8, "application/json"),                  
            };
        var restClient = new HttpClient();
        restClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _appSettings.PaygateInfo.PayGateToken);    
        var response = JsonConvert.DeserializeObject<PayGateResponse>(restClient.SendAsync(paymentRequest).Result.Content.ReadAsStringAsync().Result);
        return response;
    }
}