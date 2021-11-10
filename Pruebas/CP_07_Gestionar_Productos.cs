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
    public class CP_07_Gestionar_Productos : IDisposable
    {
        public static IWebDriver _driver = Principal._driver;
        private static Random random = new Random();

        public string Generador(int tamaño)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, tamaño).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [Fact]
        public void RegistrarProducto()
        {
            CP_05_Cerrar_Sesion.Logout();
            Thread.Sleep(2000);

            CP_04_Iniciar_Sesion.LoginAdmin();            
            Thread.Sleep(2000);

            _driver.Navigate().GoToUrl("http://localhost:50928/Producto/AgregarEditar");
            Thread.Sleep(2000);

            TuTienda_RegistrarProducto registro = new TuTienda_RegistrarProducto(_driver);
            Thread.Sleep(2000);

            registro.IngresarDatosRequeridos("https://rockcontent.com/es/wp-content/uploads/sites/3/2019/02/o-que-e-produto-no-mix-de-marketing.png"
                , "PRO-" + random.Next(30,100), Generador(6), Generador(15)
                , "20", random.Next(1,12).ToString(), "12");
            registro.Registrar();

            Console.WriteLine("Prueba de registro de producto correcto \n");
        }

        [Fact]
        public void ListarProducto()
        {
            Thread.Sleep(2000);
            _driver.Navigate().GoToUrl("http://localhost:50928/Producto");
            Console.WriteLine("Prueba de listar productos correcto \n");
            Thread.Sleep(5000);
        }

        [Fact]
        public void EditarProducto()
        {
            Random rnd = new Random();

            _driver.Navigate().GoToUrl("http://localhost:50928/Producto/AgregarEditar/" + rnd.Next(24,26));
            Thread.Sleep(2000);

            TuTienda_EditarProducto editar = new TuTienda_EditarProducto(_driver);
            editar.IngresarDatosRequeridos("https://rockcontent.com/es/wp-content/uploads/sites/3/2019/02/o-que-e-produto-no-mix-de-marketing.png"
                , "PRO-" + random.Next(30, 100), Generador(6), Generador(15)
                , "20", "12");
            editar.Editar();

            Console.WriteLine("Prueba de editar producto correcto \n");
            Thread.Sleep(5000);
        }

        [Fact]
        public void BorrarProducto()
        {
            _driver.Navigate().GoToUrl("http://localhost:50928/Login/Index");
        }

        public void Dispose()
        {
            _driver.Close();
        }
    }
}
