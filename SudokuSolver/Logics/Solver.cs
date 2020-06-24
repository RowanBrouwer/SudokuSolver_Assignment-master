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

                            var numberlist = Enumerable.Range(0, 10).ToList();

                            numberlist = horizontalchecker(sudoku, a, b, numberlist);

                            numberlist = verticalchecker(sudoku, a, b, numberlist);

                            numberlist = boxchecker(sudoku, a, b, numberlist);

                            if (numberlist.Count == 1)
                            {
                                sudoku[a][b] = numberlist[0];
                                counter = 0;
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


        public int[][] SolveGuessing(int[][] sudoku)
        {
            int[][] startsudoku = new int[9][];
            for (int i = 0; i < 9; i++)
            {
                startsudoku[i] = new int[9];
                for (int j = 0; j < 9; j++)
                {
                    startsudoku[i][j] = sudoku[i][j];
                }
            }

            
            for (int a = 0; a < 9; a++)
            {
                for (int b = 0; b < 9; b++)
                {
                    if (sudoku[a][b] == 0)
                    {

                        var numberlist = Enumerable.Range(0, 10).ToList();

                        numberlist = horizontalchecker(sudoku, a, b, numberlist);

                        numberlist = verticalchecker(sudoku, a, b, numberlist);

                        numberlist = boxchecker(sudoku, a, b, numberlist);

                        int numberlistcounter = 0;
                        while (numberlistcounter < numberlist.Count)
                        {
                            sudoku[a][b] = numberlist[numberlistcounter];
                            Solve(sudoku);
                            if (!SudokuSolver(sudoku))
                            {
                                numberlistcounter++;
                                for (int i = 0; i < 9; i++)
                                { 
                                    for (int j = 0; j < 9; j++)
                                    {                                        
                                        sudoku[i][j] = startsudoku[i][j];
                                    }
                                }
                            }
                            else
                            {
                                return sudoku;
                            }
                        }
                    }
                }
            }
        return sudoku;
        }

        public int[][] Create(int[][] sudoku)
        {
            return sudoku;
        }




        public List<int> boxchecker(int[][] sudoku, int a, int b, List<int> numberlist)
        {
            int corda = a - a % 3;
            int cordb = b - b % 3;
            for (int i = corda; i < corda + 3; i++)
            {
                for (int j = cordb; j < cordb + 3; j++)
                {
                    if (numberlist.Contains(sudoku[i][j]))
                    {
                        numberlist.Remove(sudoku[i][j]);
                    }
                }
            }
            return numberlist;
        }

        public List<int> horizontalchecker(int[][] sudoku, int a, int b, List<int> numberlist)
        {
            for (int c = 0; c < 9; c++)
            {
                if (numberlist.Contains(sudoku[a][c]))
                {
                    numberlist.Remove(sudoku[a][c]);
                }
            }
            return numberlist;
        }

        public List<int> verticalchecker(int[][] sudoku, int a, int b, List<int> numberlist)
        {
            for (int d = 0; d < 9; d++)
            {
                if (numberlist.Contains(sudoku[d][b]))
                {
                    numberlist.Remove(sudoku[d][b]);
                }
            }
            return numberlist;
        }

        public bool SudokuSolver(int[][] sudoku)
        {
            for (int a = 0; a < 9; a++)
            {
                for (int b = 0; b < 9; b++)
                {
                    if(sudoku[a][b] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}





//Boolean solved = false;
//int numberlistID = 0;

//                            while (solved == false && counter<100)
//                            {
//                                if (numberlist.Count <= 9 && numberlist.Count<=numberlistID)
//                                {
//                                    sudoku[a][b] = numberlist[numberlistID];
//                                    sudoku = Solve(sudoku);
//                                    for (int i = 0; i< 9; i++)
//                                    {
//                                        for (int j = 0; j< 9; j++)
//                                        {
//                                            if (sudoku[i][j] == 0)
//                                            {
//                                                sudoku = startsudoku;
//                                                numberlistID++;
                                                
//                                            }
//                                            else
//                                            {
//                                                solved = true;
//                                            }
//                                        }
//                                    }
//                                }
//                                else
//                                {
//                                    counter++;
//                                }
//                            }