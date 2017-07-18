using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace FN.Store.Api.Infra
{
    public class AuthenticationMessageHandler : DelegatingHandler
    {
        public AuthenticationMessageHandler(HttpConfiguration httpConfig)
        {
            InnerHandler = new HttpControllerDispatcher(httpConfig);

        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage response;

            if (request.Headers.Authorization != null &&
                request.Headers.Authorization.Scheme == "Basic")
            {
                var encode = request.Headers.Authorization.Parameter.Trim();
                var user = Encoding.Default.GetString(Convert.FromBase64String(encode));
                var data = user.Split(":".ToCharArray());
                var username = data[0];
                var password = data[1];

                if (!(username == "admin" && password == "123456"))
                {
                    response = request.CreateResponse(HttpStatusCode.Unauthorized);
                    return response;
                }
            }
            else {
                response = request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                return response;
            }
            response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                response.Headers.Add("WWW-Authenticate", "Basic");
            }

            return response;
        }
    }
}