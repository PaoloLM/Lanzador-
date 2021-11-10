using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;
using System.Threading;
using Sistema_TuTienda_Lizarraga_Belizario_Loja.Pruebas;
using TuTiendaTest_Selenium.Pruebas;

namespace TuTiendaTest_Selenium
{
    public class CP_04_Iniciar_Sesion : IDisposable
    {
        public static IWebDriver _driver = Principal._driver;

        public void Dispose()
        {
            _driver.Close();
        }

        [Fact]
        public static void Login()
        {
            _driver.Navigate().GoToUrl("http://localhost:50928/Login/Index");
            _driver.Manage().Window.Maximize();

            TuTienda_IniciarSesion login = new TuTienda_IniciarSesion(_driver);
            Thread.Sleep(2000);
            login.IngresarCorreoElectronico("rene@upt.pe");
            login.IngresarPassword("12345");
            login.IniciarSesion();
            Console.WriteLine("Prueba de iniciar sesion correcto \n");
            Thread.Sleep(5000);
        }

        [Fact]
        public static void LoginAdmin()
        {
            _driver.Navigate().GoToUrl("http://localhost:50928/Login/Index");
            _driver.Manage().Window.Maximize();

            TuTienda_IniciarSesion login = new TuTienda_IniciarSesion(_driver);
            Thread.Sleep(2000);
            login.IngresarCorreoElectronico("alonso@hotmail.com");
            login.IngresarPassword("12345");
            login.IniciarSesion();
        }

        //Caso si el primero es incorrecto

        [Theory]
        [InlineData("paololm@hotmail.com", "12345")]
        [InlineData("alongo@upt.pe", "12345")]
        public void FailedLogin(string usuario, string contraseña)
        {
            TuTienda_IniciarSesion login = new TuTienda_IniciarSesion(_driver);
            login.IngresarCorreoElectronico(usuario);
            login.IngresarPassword(contraseña);
            login.IniciarSesion();
        }
    }
}
