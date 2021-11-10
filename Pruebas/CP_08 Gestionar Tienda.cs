using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;
using System.Threading;
using Sistema_TuTienda_Lizarraga_Belizario_Loja.Pruebas;
using TuTiendaTest_Selenium.Pruebas;
using System.Linq;
using OpenQA.Selenium.Interactions;

namespace TuTiendaTest_Selenium.Pruebas
{
    public class CP_08_Gestionar_Tienda : IDisposable
    {
        public static IWebDriver _driver = Principal._driver;
        private static Random random = new Random();

        public string Generador(int tamaño)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, tamaño).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [Fact]
        public void RegistrarTienda()
        {
            CP_05_Cerrar_Sesion.Logout();
            Thread.Sleep(2000);

            CP_04_Iniciar_Sesion.LoginAdmin();
            Thread.Sleep(2000);

            _driver.Navigate().GoToUrl("http://localhost:50928/Tienda/AgregarEditar/");
            Thread.Sleep(2000);

            TuTienda_RegistrarTienda registro = new TuTienda_RegistrarTienda(_driver);
            Thread.Sleep(2000);

            registro.IngresarDatosRequeridos(Generador(10), Generador(15), "999888222", Generador(20));
            registro.Registrar();

            Console.WriteLine("Prueba de registro de tienda correcto \n");
        }

        [Fact]
        public void ListarTienda()
        {
            Thread.Sleep(2000);
            _driver.Navigate().GoToUrl("http://localhost:50928/Default/Index");
            Console.WriteLine("Prueba de listar tienda correcto \n");
            Thread.Sleep(5000);
        }

        [Fact]
        public void EditarTienda()
        {
            Random rnd = new Random();

            _driver.Navigate().GoToUrl("http://localhost:50928/Tienda/AgregarEditar/" + rnd.Next(1, 3));
            Thread.Sleep(2000);

            TuTienda_EditarTienda editar = new TuTienda_EditarTienda(_driver);
            Thread.Sleep(2000);

            editar.IngresarDatosRequeridos(Generador(15), "952878521");
            editar.Registrar();

            Console.WriteLine("Prueba de editar tienda correcto \n");
            Thread.Sleep(5000);
        }

        [Fact]
        public void BorrarTienda()
        {
            _driver.Navigate().GoToUrl("http://localhost:50928/Login/Index");
        }

        public void Dispose()
        {
            _driver.Close();
        }
    }
}
