﻿using SudokuSolver.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Web;
using System.Web.Management;

namespace SudokuSolver.Logics
{
    public class Solver
    {

        int numberlistcounter = 0;
        public int[][] Solve(int[][] sudoku)
        {
            bool placed = false;
            do
            {
                placed = false;
                for (int a = 0; a < 9; a++)
                {
                    for (int b = 0; b < 9; b++)
                    {
                        if (sudoku[a][b] == 0)
                        {
                            numberlistcounter++;
                            //var numberlist = Enumerable.Range(1, 9).ToList();
                            var numberlist = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                            numberlist = numberchecker(sudoku, a, b, numberlist);

                            if (numberlist.Count == 1)
                            {
                                sudoku[a][b] = numberlist[0];
                                a = -1;
                                placed = true;
                                break;
                            }
                        }
                    }
                }
                if (!SudokuSolver(sudoku))
                {
                    break;
                }
            } while (placed);
            return sudoku;
        }

        public int[][] SolveGuessing(int[][] sudoku)
        {
            sudoku = Guess(sudoku);
            return sudoku;
        }

        public int[][] Create(int[][] sudoku)
        {
            return sudoku;
        }
        public List<int> numberchecker(int[][] sudoku, int a, int b, List<int> numberlist)
        {
            int corda = a - a % 3;
            int cordb = b - b % 3;
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

        public bool SudokuSolver(int[][] sudoku)
        {
            for (int a = 0; a < 9; a++)
            {
                for (int b = 0; b < 9; b++)
                {
                    if (sudoku[a][b] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public int[][] Backup(int[][] sudoku)
        {
            int[][] backupsudoku = new int[9][];
            for (int i = 0; i < 9; i++)
            {
                backupsudoku[i] = new int[9];
                //for (int j = 0; j < 9; j++)
                //{
                backupsudoku[i] = (int[])sudoku[i].Clone();
                //}
            }
            return backupsudoku;
        }

        public int[][] Guess(int[][] sudoku, int a = 0, int b = 0)
        {

            Solve(sudoku);
            var numberlist = Enumerable.Range(1, 9).ToList();
            int[] coord = getcoordofleast(ref sudoku);
            for (int i = 0; i < numberlist.Count; i++)
            {
                int[][] sudokucopy = Backup(sudoku);

                if (SudokuSolver(sudokucopy))
                {
                    return sudokucopy;
                }
                sudokucopy[coord[0]][coord[1]] = numberlist[i];

                if (SudokuSolver(sudokucopy))
                {
                    return sudokucopy;
                }

                sudokucopy = Guess(sudokucopy);



                if (SudokuSolver(sudokucopy))
                {
                    return sudokucopy;
                }

            }
            return sudoku;
        }

        public int[][] test(int[][] sudoku)
        {

            int[][] startsudoku = Backup(sudoku);

            for (int a = 0; a < 9; a++)
            {
                for (int b = 0; b < 9; b++)
                {
                    if (sudoku[a][b] == 0)
                    {

                        var numberlist = Enumerable.Range(1, 9).ToList();

                        numberlist = numberchecker(sudoku, a, b, numberlist);

                        int numberlistcounter = 0;

                        while (numberlistcounter < numberlist.Count)
                        {
                            sudoku[a][b] = numberlist[numberlistcounter];
                            sudoku = Solve(sudoku);
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

        public int[] getcoordofleast(ref int[][] sudoku, int a = 0, int b = 0)
        {
            for (int least = 2; least < 10; least++)
            {
                for (int i = a; i < 9; i++)
                {
                    for (int j = b; j < 9; j++)
                    {
                        //numberlist = Enumerable.Range(1, 9).ToList();

                        var numberlist = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                        if (numberchecker(sudoku, i, j, numberlist).Count == least && sudoku[i][j] == 0)
                        {
                            return new int[2] { j, i };
                        }

                    }
                }
            }
            return new int[2] { 0, 0 };
        }

        public bool validationcheck(int[][] sudoku)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (numberchecker(sudoku, i, i, new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }).Count == 0)
                    {
                        return false;
                    }

                }
            }

            return true;
        }


        public void junk(int[][] sudoku)
        {
            int[][] grid = new int[81][];
            bool listflag = false;
            int lowestlist = 10;
            for (int c = 0; c < 81; c++)
            {
                grid[c] = new int[2];
            }


            int counter = 0;
            while (listflag == false)
            {
                if (lowestlist != 10)
                {
                    listflag = true;
                }
                for (int a = 0; a < 9; a++)
                {
                    for (int b = 0; b < 9; b++)
                    {
                        if (sudoku[a][b] == 0)
                        {

                            var numberlist = Enumerable.Range(1, 9).ToList();

                            numberlist = numberchecker(sudoku, a, b, numberlist);
                            if (numberlist.Count < lowestlist)
                            {
                                lowestlist = numberlist.Count;
                            }


                            if (numberlist.Count == lowestlist && listflag == true)
                            {
                                grid[counter][0] = a;
                                grid[counter][1] = b;
                                counter++;
                            }




                            //int numberlistcounter = 0;

                            //while (numberlistcounter < numberlist.Count)
                            //{
                            //    sudoku[a][b] = numberlist[numberlistcounter];

                            //    sudoku = Solve(sudoku);
                            //    if (!SudokuSolver(sudoku))
                            //    {
                            //        sudoku = test(sudoku);




                            //        numberlistcounter++;
                            //        for (int i = 0; i < 9; i++)
                            //        {
                            //            for (int j = 0; j < 9; j++)
                            //            {
                            //                sudoku[i][j] = startsudoku[i][j];
                            //            }
                            //        }
                            //    }
                            //    else
                            //    {
                            //        return sudoku;
                            //    }

                            //}




                            //if (numberlist.Count == 3)
                            //{
                            //    sudoku[a][b] = numberlist[0];
                            //    sudoku = test(sudoku);
                            //    if (SudokuSolver(sudoku))
                            //    {
                            //        return sudoku;
                            //    }
                            //    else
                            //    {
                            //        sudoku[a][b] = numberlist[1];
                            //        sudoku = test(sudoku);
                            //        if (SudokuSolver(sudoku))
                            //        {
                            //            return sudoku;
                            //        }
                            //        else
                            //        {
                            //            sudoku[a][b] = numberlist[2];
                            //            sudoku = test(sudoku);
                            //            if (SudokuSolver(sudoku))
                            //            {
                            //                return sudoku;
                            //            }
                            //            else
                            //            {
                            //                for (int i = 0; i < 9; i++)
                            //                {
                            //                    for (int j = 0; j < 9; j++)
                            //                    {
                            //                        sudoku[i][j] = startsudoku[i][j];
                            //                    }
                            //                }
                            //            }
                            //        }
                            //    }
                            //}   
                        }
                    }
                }
            }
        }
    }
}


