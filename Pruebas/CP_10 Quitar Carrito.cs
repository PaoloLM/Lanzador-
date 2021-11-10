using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;
using System.Threading;
using Sistema_TuTienda_Lizarraga_Belizario_Loja.Pruebas;
using TuTiendaTest_Selenium.Pruebas;
using System.Linq;
using OpenQA.Selenium.Interactions;
using Sistema_TuTienda_Lizarraga_Belizario_Loja.Models;

namespace TuTiendaTest_Selenium.Pruebas
{   
    class CP_10_Quitar_Carrito : IDisposable
    {
        public static IWebDriver _driver = Principal._driver;
        Random rnd = new Random();

        public void Quitar()
        {
            CP_11_Gestionar_Pedido.AgregarProductoCarrito();

            _driver.Navigate().GoToUrl("http://localhost:50928/DefaultUser/ListarCarrito");
            Thread.Sleep(2000);

            var quitarElement = _driver.FindElements(By.ClassName("btn-danger"));
            if (quitarElement.Count == 0)
            {
                quitarElement[0].Click();
            }
            else if (quitarElement.Count == 1)
            {
                quitarElement[rnd.Next(0, 1)].Click();
            }
            else
            {
                for (int i = 0; i < quitarElement.Count - 1; i++)
                {
                    quitarElement[i].Click();
                }
            }

            Console.WriteLine("Prueba de quitar producto del carrito correcto \n");
            Thread.Sleep(2000);
        }

        public void Dispose()
        {
            _driver.Close();
        }
    }
}
