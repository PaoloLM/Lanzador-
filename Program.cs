using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TuTiendaTest_Selenium.Pruebas;

namespace TuTiendaTest_Selenium
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {

                try
                {
                    Console.WriteLine("Despliegue de las pruebas funcionales");
                    Console.WriteLine("===================================== \n");

                    Console.WriteLine("1. Iniciar Sesion");
                    Console.WriteLine("2. Cerrar Sesion");
                    Console.WriteLine("3. Gestion de usuarios");
                    Console.WriteLine("4. Gestion de productos");
                    Console.WriteLine("5. Gestion de la tienda");
                    Console.WriteLine("6. Busquedas");
                    Console.WriteLine("7. Quitar producto del carrito");
                    Console.WriteLine("8. Gestion de pedido");
                    Console.WriteLine("9. Salir");
                    Console.WriteLine("Elige una de las opciones");

                    int opcion = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();
                    switch (opcion)
                    {
                        case 1:
                            ////Iniciar Sesion
                            var Lanzador = new CP_04_Iniciar_Sesion();
                            CP_04_Iniciar_Sesion.Login();
                            break;

                        case 2:
                            //Cerrar Sesion
                            CP_05_Cerrar_Sesion.Logout();
                            break;

                        case 3:
                            //Gestion de usuarios
                            var CP_06 = new CP_06_Gestionar_Usuario();

                                //Registrar usuario
                                CP_06.RegistrarUsuario();

                                //Listar usuario
                                CP_06.ListarUsuario();

                                //Editar usuario
                                CP_06.EditarUsuario();

                                //Borrar usuario
                                //CP_06.BorrarUsuario();
                            break;

                        case 4:
                            //Gestion de productos
                            var CP_07 = new CP_07_Gestionar_Productos();

                                //Registrar productos
                                CP_07.RegistrarProducto();

                                //Listar productos
                                CP_07.ListarProducto();

                                //Editar productos
                                CP_07.EditarProducto();

                                //Borrar productos
                                //CP_07.Borrarproductos();
                            break;

                        case 5:
                            //Gestion de tienda
                            var CP_08 = new CP_08_Gestionar_Tienda();

                                //Registrar tienda
                                CP_08.RegistrarTienda();

                                //Listar tienda
                                CP_08.ListarTienda();

                                //Editar tienda
                                CP_08.EditarTienda();

                                //Borrar tienda
                                //CP_07.BorrarTienda();
                            break;

                        case 6:
                            //Busquedas
                            var CP_09 = new CP_09_Busquedas();

                                //Buscar usuario
                                CP_09.BuscarUsuario();

                                //Buscar producto
                                CP_09.BuscarProducto();

                                //Buscar tienda
                                CP_09.BuscarTienda();

                                //Buscar pedido
                                CP_09.BuscarPedido();

                                //Buscar Categoria
                                CP_09.BuscarCategoria();
                            break;

                        case 7:
                            //Quitar Producto del carrito
                            var CP_10 = new CP_10_Quitar_Carrito();
                            CP_10.Quitar();
                            break;

                        case 8:
                            //Gestionar Pedido
                            var CP_11 = new CP_11_Gestionar_Pedido();

                                //Agregar Producto al Carrito
                                CP_11_Gestionar_Pedido.AgregarProductoCarrito();

                                //Guardar Pedido
                                CP_11.GuardarPedido();

                                //Listar Pedido
                                CP_11.ListarPedido();
                            break;

                        case 9:
                            Console.WriteLine("Opcion para terminar las pruebas");
                            salir = true;
                            break;

                        default:
                            Console.WriteLine("Elige una opcion entre 1 y 9");
                            break;
                    }

                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.ReadLine();





            

            

            

            

            

            

            

        }
    }

}
