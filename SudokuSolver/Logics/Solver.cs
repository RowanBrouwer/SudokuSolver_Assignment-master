using SudokuSolver.Models;
using System;
using System.Collections;
using System.Collections.Generic;
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

        public int[][] Solve(int[][] sudoku)
        {







            for( int a = 0; a < 9;a++ )
            {
                for(int b = 0; b < 9; b++)
                {
                    if(sudoku[a][b] == 0)
                    {
                        int solution = 0;
                        while (testx == false || testy == false || testcube ==false )
                        {
                            testx = false;
                            testy = false;
                            testcube = false;
                            solution++;
                            checkerx(sudoku,a,solution);
                            checkery(sudoku, b, solution);
                            checkercube(sudoku,a, b, solution);
                            //breakmark
                        }
                        testx = false;
                        testy = false;
                        testcube = false;
                        sudoku[a][b] = solution;
                    }
                    //sudoku[a][b] = 3;
                }
            }



           
           //sudoku[1] = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            return sudoku;
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
                    testcube = true;
                    return;
                }
                else if (b >= 3 && b <= 5)
                {
                    testcube = true;
                    return;

                }
                else
                {
                    testcube = true;
                    return;
                }
            }
        }

    }
}