// SudokuSolver_DLL.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "SudokuSolver_DLL.h"
#include "Grid.h"

namespace Sudoku
{
	Grid gGrid;

	bool Solver::iInitialized = false;

	void Solver::Initialize(void)
	{
		if (!iInitialized)
		{
			iInitialized = true;
		}
	}

	void  Solver::SetCellValue(int _row, int _col, int _value)
	{
		try
		{
			gGrid.SetCellValue(_row, _col, _value);
		}
		catch (exception e)
		{
		}
	}

	int Solver::GetCellValue(int _row, int _col)
	{
		return(gGrid.GetCellValue(_row, _col));
	}

	int Solver::Solve(void)
	{
		return((int)gGrid.Solve());
	}
	int Solver::IsSolved(void)
	{
		return((int)gGrid.IsSolved());
	}	
}

