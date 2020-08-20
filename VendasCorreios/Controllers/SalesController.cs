using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VendasCorreios.ServiceReferenceCorreios;

namespace VendasCorreios.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult CorreiosCalc(string cep)
        {
            //"19940000"
            string nCdEmpresa = string.Empty;
            string sDsSenha = string.Empty;
            string nCdServico = "41106";
            string sCepOrigem = "34710325";
            string sCepDestino = cep;
            string nVlPeso = Convert.ToString(1);
            int nCdFormato = 1;
            decimal nVlComprimento = 20;
            decimal nVlAltura = 20;
            decimal nVlLargura = 20;
            decimal nVlDiametro = 0;
            string sCdMaoPropria = "N";
            decimal nVlValorDeclarado = 0;
            string sCdAvisoRecebimento = "N";

            // Instanciando o web service dos correios
            CalcPrecoPrazoWSSoapClient wsCorreios2 = new CalcPrecoPrazoWSSoapClient();
            cResultado retornoCorreios = wsCorreios2.CalcPrecoPrazo(nCdEmpresa, sDsSenha, nCdServico,
            sCepOrigem, sCepDestino, nVlPeso, nCdFormato, nVlComprimento, nVlAltura, nVlLargura, nVlDiametro,
            sCdMaoPropria, nVlValorDeclarado, sCdAvisoRecebimento);

            string[] result = new string[2];
            result[1] = retornoCorreios.Servicos[0].PrazoEntrega;
            result[0] = retornoCorreios.Servicos[0].Valor;

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}