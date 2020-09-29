using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejExpendedora
{
    class Program
    {
        
        static void Main(string[] args)
        {
            const string _menu = "************ EXPENDEDORA MENU ************ \nCaso de uso 0: Encender maquina" +
            "\nCaso de uso 1: Listado de latas disponibles" +
            "\nCaso de uso 2: Insertar lata" +
            "\nCaso de uso 3: Elegir lata" +
            "\nCaso de uso 4: Consultar balance" +
            "\nCaso de uso 5: Consultar Stock" +
            "\nCaso de uso 6: Salir";
            const int _opMenuMin = 0;
            const int _opMenuMax = 6;
            int _opcionMenu=0;

            Expendedora exp = new Expendedora();

            do
            {
                Console.Clear();
                Console.WriteLine(_menu);
                _opcionMenu = Validaciones.Numero("el numero de caso", _opMenuMin, _opMenuMax);
                switch (_opcionMenu)
                {
                    case 0:
                        exp.EncenderMaquina();
                        Console.WriteLine("Maquina encendida...");
                        break;
                    case 1:
                        Console.WriteLine(exp.Listado());
                        break;
                    case 2:
                        IngresarLata(exp);
                        break;
                    case 3:
                        ExtraerLata(exp);
                        break;
                    case 4:
                        ObtenerBalance(exp);
                        break;
                    case 5:
                        MostrarStock(exp);
                        break;
                    case 6:
                        Console.WriteLine("Cerrando el programa....");
                        break;
                    default:
                        break;
                }
                Console.ReadKey();
                
            } while (_opcionMenu != 6);
            
        }

        static void IngresarLata(Expendedora exp)
        {
            Lata lata;
            if (!exp.Encendida)
                Console.WriteLine("Debe encender la maquina para hacer esta operacion.");
            else
            {
                try
                {
                    Console.WriteLine(exp.Listado());
                    lata = exp.BuscarLata(Validaciones.Texto("codigo").ToUpper());
                    if (lata == null)
                        throw new CodigoInvalidoException();
                    else
                    {

                        double precio = Validaciones.Importe("precio");
                        double volumen = Validaciones.Importe("volumen en cc");
                        Lata auxLata = new Lata(lata.Codigo, lata.Nombre, lata.Sabor, precio, volumen);
                        exp.AgregarLata(auxLata);

                        Console.WriteLine("Lata agregada ok.");
                    }
                }
                catch (CodigoInvalidoException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (CapacidadInsuficienteException)
                {
                    Console.WriteLine("La capacidad esta llena. No se agrega producto.");
                }                
            }
        }
        static void ExtraerLata(Expendedora exp)
        {
            Lata lata;
            try
            {
                if (!exp.Encendida)
                    Console.WriteLine("Debe encender la maquina para hacer esta operacion.");
                else
                {
                    if (exp.EstaVacia())
                        throw new SinStockException();
                    else
                    {
                        lata = exp.BuscarLata(Validaciones.Texto("codigo").ToUpper());
                        if (lata == null)
                            throw new CodigoInvalidoException();
                        else
                        {
                            double precio = Validaciones.Importe("pago");
                            if (lata.Precio > precio)
                                throw new DineroInsuficienteException();
                            else
                            {
                                exp.ExtraerLata(lata.Codigo, lata.Precio);
                                Console.WriteLine("Extraccion exitosa.");
                                //Falta alternativo 3: No hay stock de esa lata
                            }
                        }
                    }
                }
            }
            catch (SinStockException)
            {
                Console.WriteLine("No hay stock. Se cancela operacion.");
            }
            catch (CodigoInvalidoException)
            {
                Console.WriteLine("El codigo ingresado es invalido. Se cancela operacion.");
            }
            catch (DineroInsuficienteException)
            {
                Console.WriteLine("El dinero ingresado no alcanza. Se cancela operacion.");
            }

            }
        static void ObtenerBalance(Expendedora exp)
        {
            if (!exp.Encendida)
                Console.WriteLine("Debe encender la maquina para hacer esta operacion.");
            else
            {
                Console.WriteLine(exp.GetBalance());
                Console.WriteLine(exp.Listado());
            }

        }
        static void MostrarStock(Expendedora exp)
        {
            if (!exp.Encendida)
                Console.WriteLine("Debe encender la maquina para hacer esta operacion.");
            else
            {
                Console.WriteLine(exp.ListadoStock());
            }
         }
    }
}
