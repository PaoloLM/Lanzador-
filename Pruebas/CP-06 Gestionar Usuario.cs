using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;
using System.Threading;
using Sistema_TuTienda_Lizarraga_Belizario_Loja.Pruebas;
using TuTiendaTest_Selenium.Pruebas;
using System.Linq;

namespace TuTiendaTest_Selenium.Pruebas
{
    public class CP_06_Gestionar_Usuario : IDisposable
    {
        public static IWebDriver _driver = Principal._driver;
        private static Random random = new Random();

        public string Generador(int tamaño)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, tamaño).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [Fact]
        public void RegistrarUsuario()
        {
            _driver.Navigate().GoToUrl("http://localhost:50928/Login/Registro");

            TuTienda_RegistrarUsuario registro = new TuTienda_RegistrarUsuario(_driver);
            Thread.Sleep(2000);
            registro.IngresarDatosRequeridos(Generador(6), Generador(10), "999555666", Generador(6) + "@upt.pe"
                , "Peru", "Tacna", "12345", "Calle " + Generador(3) + " 123");

            registro.Registrar();
            Console.WriteLine("Prueba de registro de usuario correcto \n");
        }

        [Fact]
        public void ListarUsuario()
        {
            CP_05_Cerrar_Sesion.Logout();
            CP_04_Iniciar_Sesion.LoginAdmin();
            Thread.Sleep(2000);
            _driver.Navigate().GoToUrl("http://localhost:50928/Usuario/Index");
            Console.WriteLine("Prueba de listar usuarios correcto \n");
            Thread.Sleep(5000);
        }

        [Fact]
        public void EditarUsuario()
        {
            CP_05_Cerrar_Sesion.Logout();
            CP_04_Iniciar_Sesion.Login();

            _driver.Navigate().GoToUrl("http://localhost:50928/DefaultUser/VerPerfil");
            Thread.Sleep(2000);

            _driver.FindElement(By.Id("editar")).Click();
            TuTienda_EditarUsuario editar = new TuTienda_EditarUsuario(_driver);
            editar.IngresarDatosRequeridos("Rene", Generador(10), "999555666", "Peru", "Tacna", "12345");
            editar.Editar();

            Console.WriteLine("Prueba de editar usuario correcto \n");            
            Thread.Sleep(5000);
        }

        [Fact]
        public void BorrarUsuario()
        {
            _driver.Navigate().GoToUrl("http://localhost:50928/Login/Index");
        }

        public void Dispose()
        {
            _driver.Close();
        }
    }
}
