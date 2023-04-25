using System;

namespace game
{
    class Program
    {

        static byte language;
        
        //dictionary for two  languages
        static Dictionary<int, string[]> texts = new Dictionary<int, string[]>()
        {
            { 1, new string[] 
            {
                "Hello!!! It's Sea Battle Ship Game. \n ~  sea\n ■  ship\n X  the wrecked ship\n O  the sea where shot\n" +
                "At the stage of placing ships, you will first need to choose the direction of the ship (vertical | horizontal), when " +
                "installing the ship, the coordinate of the left square is always indicated if the ship is horizontal and the upper one " +
                "if the ship is vertical, the coordinates are indicated as a1 or e5, etc.\nFor countinue press Enter:",

                "Привет!!! Это игра морской бой. \n ~  море\n ■  корабль\n X  поврежденная часть корабля\n O  море, в которое уже стреляли\n" +
                "На этапе расстановки кораблей, сначала нужно будет выбрать направление корабля (вертикальное | горизонтальное), когда устанавливаете " +
                "корабль, нужно указывать самую левую координату корабля, если корабль горизонтальный, и самую верхнюю кординату корабля, если корабль вертикальный. " +
                "Координаты указываются как a1, b2, c5 и так далее от a1 до j10 (первая буква английская)\nДля продолжения нажмите Enter: "
            } 
            },
            { 2, new string[] { "!!!Player 1's Ship Placement Stage!!!", "!!!Этап расстановки кораблей игрока 1!!!" } },
            { 3, new string[] { "!!!Player 2's Ship Placement Stage!!!", "!!!Этап расстановки кораблей игрока 2!!!" } },
            { 4, new string[] { "four-deck ship: ", "четырехпалубный корабль: "} },
            { 5, new string[] { "It is impossible to place a four-deck ship here, try again", "Здесь невозможно разместить четырехпалубный корабль, попробуйте еще раз" } },
            { 6, new string[] { "Enter vector(1 - vertical, 2 - horizontal)", "Введите вектор(1 - вертикальный, 2 - горизонтальный)" } },
            { 7, new string[] { "Something wrong!!! Enter 1 or 2!", "Что-то пошло не так!!! Введите 1 или 2!" } },
            { 8, new string[] { "Enter coord(a1 - j10): ", "Введите координаты(a1 - j10): "} },
            { 9, new string[] { "Something wrong!!! Enter coord from a1 to j10: ", "Что-то пошло не так!!! Введите координаты от a1 до j10: " } },
            { 11, new string[] { "three-deck ship №", "трехпалубный корабль №" } },
            { 12, new string[] { "It is impossible to place a three-deck ship here, try again", "Разместить здесь трехпалубный корабль невозможно, попробуйте еще раз" } },
            { 13, new string[] { "two-deck ship №", "двухпалубный корабль №" } },
            { 14, new string[] { "It is impossible to place a two-deck ship here, try again", "Разместить здесь двухпалубный корабль невозможно, попробуйте еще раз" } },
            { 15, new string[] { "one-deck ship №", "однопалубный корабль №" } },
            { 16, new string[] { "It is impossible to place a one-deck ship here, try again", "Разместить здесь однопалубный корабль невозможно, попробуйте еще раз" } },
            { 17, new string[] { "\nDone!!!", "\nОтлично!!!" } },
            { 18, new string[] { "player 1, move №", "игрок 1, ход №" } },
            { 19, new string[] { "player 2, move №", "игрок 2, ход №" } },
            { 20, new string[] { "you cannot select this coordinate since it has already been attacked before", "вы не можете выбрать эту координату, так как она уже была атакована прежде" } },
            { 21, new string[] { "Miss! For contimue press Enter: ", "Промах! Для продолжения нажмите Enter: "} },
            { 22, new string[] { "Good! You hit ship, for continue press Enter: ", "Хорошо! Ты попал по кораблю, для продолжения нажми Enter: "} },
            { 23, new string[] { "Your battlefield: ", "Твое поле боя: "} },
            { 24, new string[] { "Opponent 's field: ", "Поле противника: " } },
            { 25, new string[] { "Player 1 win!!!" , "Игрок 1 выиграл!!!"} },
            { 26, new string[] { "Player 2 win!!!" , "Игрок 2 выиграл!!!"} },
            { 27, new string[] { "\nPlayer 1 battlefield\n", "\nПоле игрока 1\n" } },
            { 28, new string[] { "\nPlayer 2 battlefield\n", "\nПоле игрока 2\n" } },
            { 29, new string[] { "\nWrong string, enter from 1 to 10\n", "\nНеверно указана строка, введите от 1 до 10\n"} },

        };

        //legit letters for enter coords and letter-to-digit correspondence
        static Dictionary<char, byte> letters = new Dictionary<char, byte>()
        {
            { 'a', 0 },
            { 'b', 1 },
            { 'c', 2 },
            { 'd', 3 },
            { 'e', 4 },
            { 'f', 5 },
            { 'g', 6 },
            { 'h', 7 },
            { 'i', 8 },
            { 'j', 9 },
        };

        //escaped characters for my battlefield
        static Dictionary<int, string> symbols = new Dictionary<int, string>()
        {
            { 0, "~" },
            { 1, "■" },
            { 2, "X" },
            { 3, "O" }
        };

        //escaped characters for enemy battlefield
        static Dictionary<int, string> another_symbols = new Dictionary<int, string>()
        {
            { 0, "~" },
            { 1, "~" },
            { 2, "X" },
            { 3, "O" }
        };

        //colors for screening
        static Dictionary<string, ConsoleColor> colors = new Dictionary<string, ConsoleColor>()
        {
            { "~", ConsoleColor.Blue },
            { "■", ConsoleColor.White },
            { "X", ConsoleColor.Red },
            { "O", ConsoleColor.Green },
        };



        public static void Main (string[] args)
        {
            Console.WriteLine("Select a language | Выберите язык. 1 - eng, 2 - ru: ");
            while (true)
            {
                try
                {
                    language = (byte)(int.Parse(Console.ReadLine())-1);
                    if (language == 0 || language == 1)
                    {
                        Console.WriteLine("OK");
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine ("Enter 1 or 2: ");
                }
            }
            
            Console.WriteLine(texts[1][language]);
            wait_press_enter();

            // stage of create ships

            Console.WriteLine(texts[2][language]);
            int[][] matrix_1 = create_matrix();
            Console.WriteLine(texts[3][language]);
            int[][] matrix_2 = create_matrix();
            me_print_matrix(matrix_1);
            another_print_matrix(matrix_1);

            // stage of play 1 vs 1

            byte[] p1_coord;
            byte[] p2_coord;
            int counter1 = 1;
            int counter2 = 1;
            bool end = false;

            while (check_end(matrix_1) && check_end(matrix_2))
            {
                // player 1
                
                while (!end)
                {
                    Console.Clear();
                    Console.WriteLine(texts[18][language] + " " + counter1);
                    Console.WriteLine(texts[23][language]);
                    me_print_matrix(matrix_1);
                    Console.WriteLine(texts[24][language]);
                    another_print_matrix(matrix_2);
                    p1_coord = get_check_and_return_coords(matrix_2);
                    if (matrix_2[p1_coord[0]][p1_coord[1]] == 0)
                    {
                        matrix_2[p1_coord[0]][p1_coord[1]] = 3;
                        Console.WriteLine(texts[21][language]);
                        wait_press_enter();
                        counter1++;
                        break;
                    } else if (matrix_2[p1_coord[0]][p1_coord[1]] == 1)
                    {
                        matrix_2[p1_coord[0]][p1_coord[1]] = 2;
                        Console.WriteLine(texts[22][language]);
                        matrix_2 = outline_ship_if_destroyed(p1_coord, matrix_2);
                        wait_press_enter();
                        counter1++;
                        end = !(check_end(matrix_2));
                        continue;
                    }
                }


                if (end)
                    break;

                // player 2

                while (!end)
                {
                    Console.Clear();
                    Console.WriteLine(texts[19][language] + " " + counter2);
                    Console.WriteLine(texts[23][language]);
                    me_print_matrix(matrix_2);
                    Console.WriteLine(texts[24][language]);
                    another_print_matrix(matrix_1);
                    p2_coord = get_check_and_return_coords(matrix_1);
                    if (matrix_1[p2_coord[0]][p2_coord[1]] == 0)
                    {
                        matrix_1[p2_coord[0]][p2_coord[1]] = 3;
                        Console.WriteLine(texts[21][language]);
                        wait_press_enter();
                        counter2++;
                        break;
                    }
                    else if (matrix_1[p2_coord[0]][p2_coord[1]] == 1)
                    {
                        matrix_1[p2_coord[0]][p2_coord[1]] = 2;
                        Console.WriteLine(texts[22][language]);
                        wait_press_enter();
                        matrix_1 = outline_ship_if_destroyed(p2_coord, matrix_1);
                        counter2++;
                        end = !(check_end(matrix_1));
                        continue;
                    }
                }

            }

            if (check_end(matrix_1))
            {
                Console.WriteLine(texts[25][language]);
            }
            else
            {
                Console.WriteLine(texts[26][language]);
            }
            Console.WriteLine(texts[27][language]);
            me_print_matrix(matrix_1);
            Console.WriteLine(texts[28][language]);
            me_print_matrix(matrix_2);
        }

        public static void wait_press_enter ()
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                    break;
            }
            Console.Clear();
        }


        // methods for play


        public static byte[] get_check_and_return_coords (int[][] mat)
        {
            byte[] cor;
            while (true)
            {
                cor = get_coord();
                if (check_correct_coords(cor, mat))
                {
                    Console.WriteLine("OK");
                    return cor;
                }
                else
                {
                    Console.WriteLine(texts[20][language]);
                }
            }
        }

        //check matrix and if all ships destroyed return false
        public static bool check_end (int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i].Contains(1))
                    return true;
            }
            return false;
        }

        public static bool check_correct_coords (byte[] c, int[][] matrix)
        {
            if (matrix[c[0]][c[1]] == 2 || matrix[c[0]][c[1]] == 3)
            {
                return false;
            }
            return true;
        }

        public static int[][] outline_ship_if_destroyed(byte[] coordinats, int[][] matrix)
        {
            List<int[]> coords = new List<int[]>();  // array for coords around if one-deck ships destroyed
            int[] int_coord_of_shot = new int[] { coordinats[0], coordinats[1] }; // translating from byte to int to perform arithmetic operations
            // one-deck outline
            int need = 4;
            int have = 0;
            int[][] sides = new int[][] { new int[] {1, 0}, new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 }, };

            // check one-deck or not
            foreach (int[] side in sides)
            {
                try
                {
                    if (matrix[int_coord_of_shot[0] + side[0]][int_coord_of_shot[1] + side[1]] == 1)
                        return matrix;
                }
                catch { continue; }
            }

            foreach (int[] side in sides)
            {
                try
                {
                    if (matrix[int_coord_of_shot[0] + side[0]][int_coord_of_shot[1] + side[1]] != 2)
                        have++;
                }
                catch { need--; }
            }

            // if one-desk
            if (have == need)
            {
                // add coords around one-deck ship
                coords.Add(new int[] { int_coord_of_shot[0] - 1, int_coord_of_shot[1] - 1});
                coords.Add(new int[] { int_coord_of_shot[0] - 1, int_coord_of_shot[1] });
                coords.Add(new int[] { int_coord_of_shot[0] - 1, int_coord_of_shot[1] + 1 });
                coords.Add(new int[] { int_coord_of_shot[0], int_coord_of_shot[1] - 1 });
                coords.Add(new int[] { int_coord_of_shot[0], int_coord_of_shot[1] + 1 });
                coords.Add(new int[] { int_coord_of_shot[0] + 1, int_coord_of_shot[1] - 1 });
                coords.Add(new int[] { int_coord_of_shot[0] + 1, int_coord_of_shot[1]});
                coords.Add(new int[] { int_coord_of_shot[0] + 1, int_coord_of_shot[1] + 1 });

                // fill around one-deck ship
                foreach (int[] ar in coords)
                {
                    try
                    {
                        matrix[ar[0]][ar[1]] = 3;
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
                return matrix;
            }

            // two-three-four-deck outline

            // chech what vector have ship, 1-vertical or 2-horizontal
            int vec = 0;
            try
            {
                if (matrix[int_coord_of_shot[0] + 1][int_coord_of_shot[1]] == 2)
                    vec = 1;
            }
            catch { }
            try
            {
                if (matrix[int_coord_of_shot[0] - 1][int_coord_of_shot[1]] == 2)
                    vec = 1;
            }
            catch { }
            try
            {
                if (matrix[int_coord_of_shot[0]][int_coord_of_shot[1] + 1] == 2)
                    vec = 2;
            }
            catch { }
            try
            {
                if (matrix[int_coord_of_shot[0]][int_coord_of_shot[1] - 1] == 2)
                    vec = 2;
            }
            catch { }


            // try outline verical ships
            if (vec == 1)
            {
                int min = int_coord_of_shot[0]; // for the upmost coord 
                int max = int_coord_of_shot[0]; // for the downmost coord

                // determine the length of the ship (down and up)
                for (int i = 1; i < 4; i++)
                {
                    try
                    {
                        if (matrix[int_coord_of_shot[0] + i][int_coord_of_shot[1]] == 2)
                        {
                            max = int_coord_of_shot[0] + i;
                        }
                        if (matrix[int_coord_of_shot[0] + i][int_coord_of_shot[1]] == 1)
                            return matrix;
                        if (matrix[int_coord_of_shot[0] + i][int_coord_of_shot[1]] == 0 || matrix[int_coord_of_shot[0] + i][int_coord_of_shot[1]] == 3)
                            break;
                    }
                    catch { }
                }
                for (int i = 1; i < 4; i++)
                {
                    try
                    {
                        if (matrix[int_coord_of_shot[0] - i][int_coord_of_shot[1]] == 2)
                        {
                            min = int_coord_of_shot[0] - i;
                        }
                        if (matrix[int_coord_of_shot[0] - i][int_coord_of_shot[1]] == 1)
                            return matrix;
                        if (matrix[int_coord_of_shot[0] - i][int_coord_of_shot[1]] == 0 || matrix[int_coord_of_shot[0] - i][int_coord_of_shot[1]] == 3)
                            break;
                    }
                    catch { }
                }
                // fill coords, that we get upper
                try
                {
                    matrix[min - 1][int_coord_of_shot[1]] = 3;
                } catch { }
                try
                {
                    matrix[max + 1][int_coord_of_shot[1]] = 3;
                } catch { }
                for (int i = min-1; i <= max+1; i++)
                {
                    try
                    {
                        matrix[i][int_coord_of_shot[1] - 1] = 3;
                    }
                    catch { }
                    try
                    {
                        matrix[i][int_coord_of_shot[1] + 1] = 3;
                    }
                    catch { }
                }
            }
            // try outline horizontal ships
            else
            {
                int min = int_coord_of_shot[1]; // for the leftmost coord
                int max = int_coord_of_shot[1]; // for the rightmost coord
                // get left and right coord
                for (int i = 1; i < 4; i++)
                {
                    try
                    {
                        if (matrix[int_coord_of_shot[0]][int_coord_of_shot[1] + i] == 2)
                        {
                            max = int_coord_of_shot[1] + i;
                        }
                        if (matrix[int_coord_of_shot[0]][int_coord_of_shot[1] + i] == 1)
                            return matrix;
                        if (matrix[int_coord_of_shot[0]][int_coord_of_shot[1] + i] == 0 || matrix[int_coord_of_shot[0]][int_coord_of_shot[1] + i] == 3)
                            break;
                    }
                    catch { }
                }
                for (int i = 1; i < 4; i++)
                {
                    try
                    {
                        if (matrix[int_coord_of_shot[0]][int_coord_of_shot[1] - i] == 2)
                        {
                            min = int_coord_of_shot[1] - i;
                        }
                        if (matrix[int_coord_of_shot[0]][int_coord_of_shot[1] - i] == 1)
                            return matrix;
                        if (matrix[int_coord_of_shot[0]][int_coord_of_shot[1] - i] == 0 || matrix[int_coord_of_shot[0]][int_coord_of_shot[1] - i] == 3)
                            break;
                    }
                    catch { }
                }
                
                // fiil coords, that we get upper
                try
                {
                    matrix[int_coord_of_shot[0]][min-1] = 3;
                }
                catch { }
                try
                {
                    matrix[int_coord_of_shot[0]][max + 1] = 3;
                }
                catch { }
                for (int i = min - 1; i <= max + 1; i++)
                {
                    try
                    {
                        matrix[int_coord_of_shot[0] - 1][i] = 3;
                    }
                    catch { }
                    try
                    {
                        matrix[int_coord_of_shot[0] + 1][i] = 3;
                    }
                    catch { }
                }
            }
            // return matrix with fill around ship
            return matrix;
        }

        // methods for create battlefields


        public static int[][] create_matrix ()
        {
            // create clear matrix 10x10
            int[][] matrix = new int[10][];
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int[10];
            }
            byte vector;
            byte[] coords;
            List<int[]> coords_for_check = new List<int[]>(); // list for coords for transfer in method, where check can we put ship there or not 

            me_print_matrix(matrix);

            // one 4-deck
            Console.WriteLine(texts[4][language]);
            while (true)
            {
                vector = get_vector(); 
                coords = get_coord();
                // if vector = 1 (vertical)
                if (vector == 1)
                {
                    // check on legit string coord
                    if (coords[0] == 7 || coords[0] == 8 || coords[0] == 9)
                    {
                        Console.WriteLine(texts[5][language]);
                        continue;
                    }
                    // if coord is normal - put ship in battlefield
                    for (int i = 0; i < 4; i++)
                    {
                        matrix[coords[0] + i][coords[1]] = 1;
                    }
                    break;
                }
                // if vector = 2 (horizontal)
                else if (vector == 2)
                {
                    // check on legit column coord
                    if (coords[1] == 7 || coords[1] == 8 || coords[1] == 9)
                    {
                        Console.WriteLine(texts[5][language]);
                        continue;
                    }
                    // if coord is normal - put ship in battlefield
                    for (int i = 0; i < 4; i++)
                    {
                        matrix[coords[0]][coords[1]+i] = 1;
                    }
                    break;
                }
            }

            // two 3-deck
            for (int j = 0; j < 2; j++)
            {
                Console.Clear();
                me_print_matrix(matrix);        
                Console.WriteLine(texts[11][language] + " " + (j + 1) + ":");
                while (true)
                {
                    coords_for_check.Clear();
                    vector = get_vector();
                    coords = get_coord();
                    if (vector == 1)
                    {
                        // check on legit string coord
                        if (coords[0] == 8 || coords[0] == 9)
                        {
                            Console.WriteLine(texts[12][language]);
                            continue;
                        }
                        // if coord is normal take all coords where will ship
                        for (int i = -1; i < 4; i++)
                        {
                            coords_for_check.Add(new int[] { coords[0] + i, coords[1] });
                        }
                        // check can we put ship on place with choosed player or not
                        if (!check_create_ship(vector, coords_for_check, matrix))
                        {
                            Console.WriteLine(texts[12][language]);
                            continue;
                        }
                        // if can
                        for (int i = 0; i < 3; i++)
                        {
                            matrix[coords[0] + i][coords[1]] = 1;
                        }
                        break;
                    }
                    else if (vector == 2)
                    {
                        // check on legit column coord
                        if (coords[1] == 8 || coords[1] == 9)
                        {
                            Console.WriteLine(texts[12][language]);
                            continue;
                        }
                        // if coord is normal take all coords where will ship
                        for (int i = -1; i < 4; i++)
                        {
                            coords_for_check.Add(new int[] { coords[0], coords[1] + i });
                        }
                        // check can we put ship on place with choosed player or not
                        if (!check_create_ship(vector, coords_for_check, matrix))
                        {
                            Console.WriteLine(texts[12][language]);
                            continue;
                        }
                        // if can
                        for (int i = 0; i < 3; i++)
                        {
                            matrix[coords[0]][coords[1] + i] = 1;
                        }
                        break;
                    }
                }
            }
            
            // three 2-deck
            for (int j = 0; j < 3; j++)
            {
                Console.Clear();
                me_print_matrix(matrix);
                Console.WriteLine(texts[13][language] + " " + (j + 1) + ":");
                while (true)
                {
                    coords_for_check.Clear();
                    vector = get_vector();
                    coords = get_coord();
                    if (vector == 1)
                    {
                        if (coords[0] == 9)
                        {
                            Console.WriteLine(texts[14][language]);
                            continue;
                        }

                        for (int i = -1; i < 3; i++)
                        {
                            coords_for_check.Add(new int[] { coords[0] + i, coords[1] });
                        }

                        if (!check_create_ship(vector, coords_for_check, matrix))
                        {
                            Console.WriteLine(texts[14][language]);
                            continue;
                        }
                        for (int i = 0; i < 2; i++)
                        {
                            matrix[coords[0] + i][coords[1]] = 1;
                        }
                        break;
                    }
                    else if (vector == 2)
                    {
                        if (coords[1] == 9)
                        {
                            Console.WriteLine(texts[14][language]);
                            continue;
                        }

                        for (int i = -1; i < 3; i++)
                        {
                            coords_for_check.Add(new int[] { coords[0], coords[1] + i });
                        }

                        if (!check_create_ship(vector, coords_for_check, matrix))
                        {
                            Console.WriteLine(texts[14][language]);
                            continue;
                        }

                        for (int i = 0; i < 2; i++)
                        {
                            matrix[coords[0]][coords[1] + i] = 1;
                        }
                        break;
                    }
                }
            }

            // four 1-deck
            for (int j = 0; j < 4; j++)
            {
                Console.Clear();
                me_print_matrix(matrix);
                Console.WriteLine(texts[15][language] + " " + (j + 1) + ":");
                while (true)
                {
                    coords_for_check.Clear();
                    coords = get_coord();

                    for (int i = -1; i < 2; i++)
                    {
                        coords_for_check.Add(new int[] { coords[0] + i, coords[1] });
                    }

                    if (!check_create_ship(1, coords_for_check, matrix))
                    {
                        Console.WriteLine(texts[16][language]);
                        continue;
                    }
                    matrix[coords[0]][coords[1]] = 1;
                    break;
                }
            }
            Console.Clear();
            me_print_matrix(matrix);
            Console.WriteLine(texts[17][language]);
            Thread.Sleep(3000);
            Console.Clear();
            return matrix;
        }

        public static bool check_create_ship (byte vec, List<int[]> coords, int[][] matrix)
        {
            int ln = coords.Count;
            // take coords where will ship, and around ship too
            if (vec == 1)
            {
                for (int i = 0; i < ln; i++)
                {
                    coords.Add(new int[] { coords[i][0], coords[i][1] - 1 });
                    coords.Add(new int[] { coords[i][0], coords[i][1] + 1 });
                }
            }
            else
            {
                for (int i = 0; i < ln; i++)
                {
                    coords.Add(new int[] { coords[i][0] - 1, coords[i][1] });
                    coords.Add(new int[] { coords[i][0] + 1, coords[i][1] });
                }
            }
            // check on another ship around ship
            for (int i = 0; i < coords.Count; i++)
            {
                try
                {
                    if (matrix[coords[i][0]][coords[i][1]] == 1)
                    {
                        return false;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    continue;
                }
            }
            
            return true;
        }

        public static byte get_vector ()
        {
            byte vec;
            while (true)
            {
                try
                {
                    Console.WriteLine(texts[6][language]);
                    vec = byte.Parse(Console.ReadLine());
                    if (vec == 1 || vec == 2)
                    {
                        return vec;
                    }
                    else
                    {
                        Console.WriteLine(texts[7][language]);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(texts[7][language]);
                }
            }
            
        }

        public static byte[] get_coord ()
        {
            string coord;
            byte str;
            byte col;
            while (true)
            {
                try
                {
                    Console.WriteLine(texts[8][language]);
                    coord = Console.ReadLine().ToLower();
                    col = letters[coord[0]];
                    str = (byte)(int.Parse(coord[1..])-1);
                    if (str < 0 || str > 9)
                    {
                        Console.WriteLine(texts[29][language]);
                        continue;
                    }
                    return new byte[] { str, col };
                }
                catch (Exception)
                { 
                    Console.WriteLine(texts[9][language]);
                }

            }
        }
        
        public static void me_print_matrix (int[][] matrix)
        {
            Console.WriteLine();
            Console.WriteLine("  | A B C D E F G H I J");
            Console.WriteLine("--|--------------------");
            for (int i = 0; i < matrix.Length-1; i++)
            {
                Console.Write((i + 1) + " | ");
                for (int j = 0; j < matrix.Length; j++)
                {
                    Console.ForegroundColor = colors[symbols[matrix[i][j]]];
                    Console.Write(symbols[matrix[i][j]] + " ");
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
            
            Console.Write("10| ");
            for ( int i = 0; i < matrix.Length; i++)
            {
                Console.ForegroundColor = colors[symbols[matrix[9][i]]];
                Console.Write(symbols[matrix[9][i]] + " ");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        public static void another_print_matrix (int[][] matrix)
        {
            Console.WriteLine();
            Console.WriteLine("  | A B C D E F G H I J");
            Console.WriteLine("--|--------------------");
            for (int i = 0; i < matrix.Length - 1; i++)
            {
                Console.Write((i + 1) + " | ");
                for (int j = 0; j < matrix.Length; j++)
                {
                    Console.ForegroundColor = colors[another_symbols[matrix[i][j]]];
                    Console.Write(another_symbols[matrix[i][j]] + " ");
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }
            Console.Write("10| ");
            for (int i = 0; i < matrix.Length; i++)
            {
                Console.ForegroundColor = colors[another_symbols[matrix[9][i]]];
                Console.Write(another_symbols[matrix[9][i]] + " ");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
    
    }
}