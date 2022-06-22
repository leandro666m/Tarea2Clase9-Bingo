namespace Tarea2Clase9_Bingo {
    internal class Program {
        static void Main(string[] args) {

            //-------------------------------generamos los numeros del carton
            var genRandom = new Random();
            var carton = new int[3, 9];
            for (int c = 0; c < 9; c++) {
                for (int f = 0; f < 3; f++) {

                    int nuevoNumero = 0;
                    bool encontreUnoNuevo = false;
                    while (!encontreUnoNuevo) {
                        if (c == 0) { //columna 0
                            nuevoNumero = genRandom.Next(1, 10); //1 al 9
                        } else { //todas las demas columnas
                            nuevoNumero = genRandom.Next(c * 10, c * 10 + 10);
                        }
                        //buscamos si el nuevoNumero existe en la columna
                        encontreUnoNuevo = true;
                        for (int f2 = 0; f2 < 3; f2++) {
                            if (carton[f2, c] == nuevoNumero) {
                                encontreUnoNuevo = false;
                                break;
                            }
                        }//si salio del bucle y no encontro repetidos, encontreUnoNuevo=true y sale del bucle
                    }//while
                    carton[f, c] = nuevoNumero;
                }
            }

            //-------------------------------ordenamos las columnas de menor a mayor
            for (int c = 0; c < 9; c++) {
                for (int f = 0; f < 3; f++) {
                    for (int k = f + 1; k < 3; k++) {

                        if (carton[f, c] > carton[k, c]) {
                            int aux = carton[f, c];
                            carton[f, c] = carton[k, c];
                            carton[k, c] = aux;
                        }

                    }
                }
            }

            //-------------------------------borramos celdas
            var borrados = 0;
            while (borrados < 12) {

                var filaABorrar = genRandom.Next(0, 3);
                var columnaABorrar = genRandom.Next(0, 9);

                //si ya tiene cero, no borrar (ya esta borrado!)
                if (carton[filaABorrar, columnaABorrar] == 0) { continue; }

                //contamos cuantos ceros hay en esta fila
                var cerosEnFila = 0;
                for (int c = 0; c < 9; c++) {
                    if (carton[filaABorrar, c] == 0) cerosEnFila++;
                }

                //contamos cuantos ceros hay en esta columna
                var cerosEnColumna = 0;
                for (int f = 0; f < 3; f++) {
                    if (carton[f, columnaABorrar] == 0) cerosEnColumna++;
                }

                //contamos cuantos items tenemos en cada columna
                var itemsPorColuma = new int[9];
                for (int c = 0; c < 9; c++) {
                    for (int f = 0; f < 3; f++) {
                        if (carton[f, c] != 0) itemsPorColuma[c]++;
                    }
                }

                //contamos cuantas columnas hay con un solo numero
                var columnasConUnSoloNumero = 0;
                for (int c = 0; c < 9; c++) {
                    if (itemsPorColuma[c] == 1) columnasConUnSoloNumero++;
                }

                // si ya hay 4 ceros en la fila o si ya hay 2 ceros en la columna => no hago nada
                if (cerosEnFila == 4 || cerosEnColumna == 2) { continue; }//no hace nada

                //si hay 3 columnas con 1 solo numero, a partir de ahora debo borrar solo las columnas que tienen 3 items
                if (columnasConUnSoloNumero == 3 && itemsPorColuma[columnaABorrar] != 3) { continue; }

                //si no se cumplieron las opciones anteriores, BORRAR EL NUMERO
                carton[filaABorrar, columnaABorrar] = 00;
                borrados++;

            }//while

            //-------------------------------mostramos el carton
            Console.WriteLine("\n\n\n\n--------------------------------------------------");
            for (int f = 0; f < 3; f++) {
                for (int c = 0; c < 9; c++) {
                    if (c == 0) {
                        Console.Write("  |");
                    }
                    if (carton[f, c] == 0) { //si es cero, mostramos espacios
                        Console.Write("    |");
                    } else {
                        Console.Write($" {carton[f, c]:00} |");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("--------------------------------------------------\n\n\n\n");
    }//main

}//class
}//namespace