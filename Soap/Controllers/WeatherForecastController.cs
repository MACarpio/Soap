using Microsoft.AspNetCore.Mvc;
using ServiceReference1;
using ServiceReference2;

namespace Soap.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            WSIdValidatorEndpointClient endpoint = new WSIdValidatorEndpointClient();
            EstructuraListadoPreguntas listado = new EstructuraListadoPreguntas();
            listado.candidato = new Candidato()
            {
                nombres = "",
                apellidoMaterno = "",
                apellidoPaterno = "",
                codigoInterno = "",
                codigoInterno1 = "",
                codigoInterno2 = "",
                inicioValidacion = "E",
                numeroDocumento = "70290343",
                tipoDocumento = 1,
                digitoVerificador = "8",
            };
            listado.header = new Header()
            {
                canal = "AIX6",
                clave = "hNY8ZTvXXh6SwF7JbsbEvMcbGPAnvE56",
                modelo = "00103903",
                usuario = "WSUATIDVALWIN"
            };
            listadoPreguntasResponse res = await endpoint.listadoPreguntasAsync(listado);
            return Ok(res.result);
        }

        [HttpGet]
        [Route("Diego")]
        public async Task<IActionResult> GetValidadcionAsync()
        {
            EndpointClient client = new EndpointClient();
            QueryDataType query = new QueryDataType()
            {
                TipoPersona = "1",
                TipoDocumento = "1",
                NumeroDocumento = "03618234",
                CodigoReporte = "1028"
            };
            client.ClientCredentials.UserName.UserName = "WSCRUATWIN";
            client.ClientCredentials.UserName.Password = "E4aePvyhJr3VdLTAj2xWcAsK73pnxMgs";
            client.ClientCredentials.CreateSecurityTokenManager();

            GetReporteOnlineResponse1 result = await client.GetReporteOnlineAsync(query);

            return Ok(result.ReporteCrediticio);
        }
    }
}