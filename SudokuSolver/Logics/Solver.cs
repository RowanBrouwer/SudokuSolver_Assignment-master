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

        public int[][] Solve(int[][] sudoku)
        {







            for( int a = 0; a < 9;a++ )
            {
                for(int b = 0; b < 9; b++)
                {
                    if(sudoku[a][b] == 0)
                    {
                        int solution = 0;
                        while (testx == false || testy == false)
                        {
                            testx = false;
                            testy = false;
                            solution++;
                            checkerx(sudoku,a,solution);
                            checkery(sudoku, b, solution);
                            //breakmark
                        }
                        testx = false;
                        testy = false;
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

    }
}