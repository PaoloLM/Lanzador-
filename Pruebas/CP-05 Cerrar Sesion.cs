using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;
using System.Threading;
using Sistema_TuTienda_Lizarraga_Belizario_Loja.Pruebas;

namespace TuTiendaTest_Selenium.Pruebas
{
    public class CP_05_Cerrar_Sesion : IDisposable
    {
        public static IWebDriver _driver = Principal._driver;

        public static void Logout()
        {
            _driver.Navigate().GoToUrl("http://localhost:50928/Login/Logout");
            Console.WriteLine("Prueba de cerrar sesion correcto \n");
        }

        public void Dispose()
        {
            _driver.Close();
        }
    }
}
