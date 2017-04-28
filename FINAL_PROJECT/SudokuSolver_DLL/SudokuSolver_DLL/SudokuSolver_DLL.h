// SudokuSolver_DLL.h - Exported DLL Interface
#pragma once

#ifdef SUDOKUSOLVER_DLL_EXPORTS
#define SUDOKUSOLVER_DLL_API __declspec(dllexport)
#else
#define SUDOKUSOLVER_DLL_API __declspec(dllimport)
#endif

namespace Sudoku
{
	class Solver
	{
	public:
		static SUDOKUSOLVER_DLL_API void __stdcall Initialize(void);
		static SUDOKUSOLVER_DLL_API void __stdcall SetCellValue(int _row, int _col, int _value);
		static SUDOKUSOLVER_DLL_API int __stdcall GetCellValue(int _row, int _col);
		static SUDOKUSOLVER_DLL_API int __stdcall Solve(void);
		static SUDOKUSOLVER_DLL_API int __stdcall IsSolved(void);

	private:
		static bool iInitialized;
	};
}