using SudokuSolver.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SudokuSolver.Logics
{
    public class Solver
    {

        Boolean testx = false;
        Boolean testy = false;
        Boolean testcube = false;
        Boolean trowback = false;
        int counter = 0;

        public int[][] Solve(int[][] sudoku)
        {
            while (counter < 100)
            {
                for (int a = 0; a < 9; a++)
                {
                    for (int b = 0; b < 9; b++)
                    {
                        if (sudoku[a][b] == 0)
                        {
                            counter = 0;
                            var numberlist = Enumerable.Range(0, 10).ToList();
                            for (int c = 0; c < 9; c++)
                            {
                                if (numberlist.Contains(sudoku[a][c]))
                                {
                                    numberlist.Remove(sudoku[a][c]);
                                }
                            }
                            for (int d = 0; d < 9; d++)
                            {
                                if (numberlist.Contains(sudoku[d][b]))
                                {
                                    numberlist.Remove(sudoku[d][b]);
                                }
                            }

                            numberlist = test(sudoku, a, b, numberlist);

                            if (numberlist.Count == 1)
                            {
                                sudoku[a][b] = numberlist[0];
                            }



                           
                        }
                        else
                        {
                            counter++;
                        }
                    }
                }
            }
            return sudoku;
        }

        public List<int> test(int[][] sudoku, int a, int b, List<int> numberlist)
        {
            if (a >= 0 && a <= 2)
            {
                if (b >= 0 && b <= 2)
                {
                    for (int c = 0; c <= 2; c++)
                    {
                        for (int d = 0; d <= 2; d++)
                        {
                            if (numberlist.Contains(sudoku[c][d]))
                            {
                                numberlist.Remove(sudoku[c][d]);
                            }
                        }
                    }
                }
                else if (b >= 3 && b <= 5)
                {
                    for (int c = 0; c <= 2; c++)
                    {
                        for (int d = 3; d <= 5; d++)
                        {
                            if (numberlist.Contains(sudoku[c][d]))
                            {
                                numberlist.Remove(sudoku[c][d]);
                            }
                        }
                    }
                }
                else
                {
                    for (int c = 0; c <= 2; c++)
                    {
                        for (int d = 6; d <= 8; d++)
                        {
                            if (numberlist.Contains(sudoku[c][d]))
                            {
                                numberlist.Remove(sudoku[c][d]);
                            }
                        }
                    }
                }
            }
            else if (a >= 3 && a <= 5)
            {
                if (b >= 0 && b <= 2)
                {
                    for (int c = 3; c <= 5; c++)
                    {
                        for (int d = 0; d <= 2; d++)
                        {
                            if (numberlist.Contains(sudoku[c][d]))
                            {
                                numberlist.Remove(sudoku[c][d]);
                            }
                        }
                    }
                }
                else if (b >= 3 && b <= 5)
                {
                    for (int c = 3; c <= 5; c++)
                    {
                        for (int d = 3; d <= 5; d++)
                        {
                            if (numberlist.Contains(sudoku[c][d]))
                            {
                                numberlist.Remove(sudoku[c][d]);
                            }
                        }
                    }
                }
                else
                {
                    for (int c = 3; c <= 5; c++)
                    {
                        for (int d = 6; d <= 8; d++)
                        {
                            if (numberlist.Contains(sudoku[c][d]))
                            {
                                numberlist.Remove(sudoku[c][d]);
                            }
                        }
                    }
                }

            }
            else
            {
                if (b >= 0 && b <= 2)
                {
                    for (int c = 6; c <= 8; c++)
                    {
                        for (int d = 0; d <= 2; d++)
                        {
                            if (numberlist.Contains(sudoku[c][d]))
                            {
                                numberlist.Remove(sudoku[c][d]);
                            }
                        }
                    }
                }
                else if (b >= 3 && b <= 5)
                {
                    for (int c = 6; c <= 8; c++)
                    {
                        for (int d = 3; d <= 5; d++)
                        {
                            if (numberlist.Contains(sudoku[c][d]))
                            {
                                numberlist.Remove(sudoku[c][d]);
                            }
                        }
                    }
                }
                else
                {
                    for (int c = 6; c <= 8; c++)
                    {
                        for (int d = 6; d <= 8; d++)
                        {
                            if (numberlist.Contains(sudoku[c][d]))
                            {
                                numberlist.Remove(sudoku[c][d]);
                            }
                        }
                    }
                }
            }
            return numberlist;
        }















        public int[][] SolveGuessing(int[][] sudoku)
        {
            return sudoku;
        }

        public int[][] Create(int[][] sudoku)
        {
            return sudoku;
        }

        public void checkerx(int[][] sudoku, int a, int sulotion)
        {
           
            if (sudoku[a][0] != sulotion && sudoku[a][1] != sulotion && sudoku[a][2] != sulotion && sudoku[a][3] != sulotion && sudoku[a][4] != sulotion && sudoku[a][5] != sulotion && sudoku[a][6] != sulotion && sudoku[a][7] != sulotion && sudoku[a][8] != sulotion)
            {
                testx = true;
            }
            

        }

        public void checkery(int[][] sudoku, int b, int sulotion)
        {
            if (sudoku[0][b] != sulotion && sudoku[1][b] != sulotion && sudoku[2][b] != sulotion && sudoku[3][b] != sulotion && sudoku[4][b] != sulotion && sudoku[5][b] != sulotion && sudoku[6][b] != sulotion && sudoku[7][b] != sulotion && sudoku[8][b] != sulotion)
            {
                testy = true;
            }
        }

        public void checkercube(int[][] sudoku, int a, int b, int sulotion)
        {
            if(a>=0 && a <= 2)
            {
                if (b >= 0 && b <= 2)
                {
                    if (sudoku[0][0] != sulotion && sudoku[0][1] != sulotion && sudoku[0][2] != sulotion && sudoku[1][0] != sulotion && sudoku[1][1] != sulotion && sudoku[1][2] != sulotion && sudoku[2][0] != sulotion && sudoku[2][1] != sulotion && sudoku[2][2] != sulotion)
                    {
                        testcube = true;
                        return;
                    }
                }
                else if (b >= 3 && b <= 5)
                {
                    if (sudoku[0][3] != sulotion && sudoku[0][4] != sulotion && sudoku[0][5] != sulotion && sudoku[1][3] != sulotion && sudoku[1][4] != sulotion && sudoku[1][5] != sulotion && sudoku[2][3] != sulotion && sudoku[2][4] != sulotion && sudoku[2][5] != sulotion)
                    {
                        testcube = true;
                        return;
                    }
                }
                else
                {
                    if (sudoku[0][6] != sulotion && sudoku[0][7] != sulotion && sudoku[0][8] != sulotion && sudoku[1][6] != sulotion && sudoku[1][7] != sulotion && sudoku[1][8] != sulotion && sudoku[2][6] != sulotion && sudoku[2][7] != sulotion && sudoku[2][8] != sulotion)
                    {
                        testcube = true;
                        return;
                    }
                }
            }
            else if(a>=3 && a <= 5)
            {
                if (b >= 0 && b <= 2)
                {
                    if (sudoku[3][0] != sulotion && sudoku[3][1] != sulotion && sudoku[3][2] != sulotion && sudoku[4][0] != sulotion && sudoku[4][1] != sulotion && sudoku[4][2] != sulotion && sudoku[5][0] != sulotion && sudoku[5][1] != sulotion && sudoku[5][2] != sulotion)
                    {
                        testcube = true;
                        return;
                    }
                }
                else if (b >= 3 && b <= 5)
                {
                    if (sudoku[3][3] != sulotion && sudoku[3][4] != sulotion && sudoku[3][5] != sulotion && sudoku[4][3] != sulotion && sudoku[4][4] != sulotion && sudoku[4][5] != sulotion && sudoku[5][3] != sulotion && sudoku[5][4] != sulotion && sudoku[5][5] != sulotion)
                    {
                        testcube = true;
                        return;
                    }
                }
                else
                {
                    if (sudoku[3][6] != sulotion && sudoku[3][7] != sulotion && sudoku[3][8] != sulotion && sudoku[4][6] != sulotion && sudoku[4][7] != sulotion && sudoku[4][8] != sulotion && sudoku[5][6] != sulotion && sudoku[5][7] != sulotion && sudoku[5][8] != sulotion)
                    {
                        testcube = true;
                        return;
                    }
                }

            }
            else
            {
                if (b >= 0 && b <= 2)
                {
                    if (sudoku[6][0] != sulotion && sudoku[6][1] != sulotion && sudoku[6][2] != sulotion && sudoku[7][0] != sulotion && sudoku[7][1] != sulotion && sudoku[7][2] != sulotion && sudoku[8][0] != sulotion && sudoku[8][1] != sulotion && sudoku[8][2] != sulotion)
                    {
                        testcube = true;
                        return;
                    }
                }
                else if (b >= 3 && b <= 5)
                {
                    if (sudoku[6][3] != sulotion && sudoku[6][4] != sulotion && sudoku[6][5] != sulotion && sudoku[7][3] != sulotion && sudoku[7][4] != sulotion && sudoku[7][5] != sulotion && sudoku[8][3] != sulotion && sudoku[8][4] != sulotion && sudoku[8][5] != sulotion)
                    {
                        testcube = true;
                        return;
                    }
                }
                else
                {
                    if (sudoku[6][6] != sulotion && sudoku[6][7] != sulotion && sudoku[6][8] != sulotion && sudoku[7][6] != sulotion && sudoku[7][7] != sulotion && sudoku[7][8] != sulotion && sudoku[8][6] != sulotion && sudoku[8][7] != sulotion && sudoku[8][8] != sulotion)
                    {
                        testcube = true;
                        return;
                    }
                }
            }
        }

    }
}








//for( int a = 0; a < 9;a++ )
//{
//    for(int b = 0; b < 9; b++)
//    {
//        if(sudoku[a][b] == 0 || trowback == true)
//        {
//            int solution = 0;
//            if (trowback == true)
//            {
//                solution = sudoku[a][b];
//            }
//            while (testx == false || testy == false || testcube ==false )
//            {
//                testx = false;
//                testy = false;
//                testcube = false;
//                solution++;
//                checkerx(sudoku,a,solution);
//                checkery(sudoku, b, solution);
//                checkercube(sudoku,a, b, solution);
//                //breakmark
//                if (solution > 9)
//                {
//                    testx = true;
//                    testy = true;
//                    testcube = true;
//                    b = b - 2;
//                    //if (b < 0)
//                    //{
//                    //    // b = 8;
//                    //    // a = a - 2;
//                    //    solution = 99;
//                    //    b = 0;
//                    //}
//                    //else
//                    //{
//                        solution = 0;
//                    //}
//                    trowback = true;
//                }
//            }
//            testx = false;
//            testy = false;
//            testcube = false;
//            if(solution != 0)
//            {
//                trowback = false;
//            }

//            sudoku[a][b] = solution;
//        }
//        counter++;
//        if (counter > 600)
//        {
//            return sudoku;
//        }
//    }
//    counter = 0;
//}


//sudoku[1] = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };