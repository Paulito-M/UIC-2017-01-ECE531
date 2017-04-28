#ifndef __GRID_H__
#define __GRID_H__
//==============================================================================
// Grid.h
//
// DESCRIPTION:
//   The Grid object represents the Sudoku grid, which is a two-dimensional
//   array of N x N cells each holding an integer value.
//
// &HISTORY.  
//   2006-08-28 PNM - Created.
//   2008-05-30 PNM - Updated comments.
// &EHISTORY.
//==============================================================================


//------------------------------------------------------------------------------
// HEADER FILES
//------------------------------------------------------------------------------
#include <vector>
#include <stdexcept>
#include "Cell.h"
#include "GridSet.h"
using namespace std;


//------------------------------------------------------------------------------
// CLASS: Grid
//
// DESCRIPTION:
//   This class represents a Sudoku grid of N x N cells.
//------------------------------------------------------------------------------
class Grid
{
  public:

  //----------------------------------------------------------------------------
  // Structors
  //----------------------------------------------------------------------------
  Grid();
  Grid( int _NValue );
  Grid( const Grid& _src );  // copy constructor; needed due to dynamic memory
  ~Grid();

  const Grid& operator=( const Grid& _rhs );   // assignment operator

  //----------------------------------------------------------------------------
  // DESCRIPTION:
  //   Get the N-Value of the grid.
  //
  // PARAMETERS:
  //   N/A
  //
  // RETURNS: 
  //   N-value of the grid
  //
  // Note that if we do not declare the member function 'const', below, 
  // then a const object of this type is not allowed to invoke this
  // function!
  //----------------------------------------------------------------------------
  int GetNValue( ) const      { return( mNValue );      };


  //----------------------------------------------------------------------------
  // DESCRIPTION:
  //   Set the value of a specific cell in the grid.
  //
  // PARAMETERS:
  //   _Row - 0 to N-1
  //   _Column - 0 to N-1
  //   _Value - 1 to N
  //
  // RETURNS: 
  //   N/A
  //----------------------------------------------------------------------------
  void SetCellValue( int _Row,
                     int _Column,
                     int _Value )
    throw( out_of_range );


  //----------------------------------------------------------------------------
  // DESCRIPTION:
  //   Get the value of a specific cell in the grid.
  //
  // PARAMETERS:
  //   _Row - 0 to N-1
  //   _Column - 0 to N-1
  // 
  // RETURNS:
  //   Value of cell in grid (1 to N), or 0 if no value is present.
  //----------------------------------------------------------------------------
  int GetCellValue( int _Row,
                    int _Column )
    throw( out_of_range );


  //----------------------------------------------------------------------------
  // DESCRIPTION:
  //   Solve the grid, if possible.
  //
  // PARAMETERS:
  //   N/A
  //
  // RETURNS:
  //   true - grid has been solved; cell values have been updated
  //   false - grid is not solvable  
  //----------------------------------------------------------------------------
  bool Solve();

  //----------------------------------------------------------------------------
  // DESCRIPTION:
  //   Returns whether the grid is solved.
  //
  // PARAMETERS:
  //   N/A
  //
  // RETURNS:
  //   true - grid is solved
  //   false - grid is not solved
  //----------------------------------------------------------------------------
  bool IsSolved();


  private:

  static const int DEFAULT_SIZE = 9;

  void i_Grid( int _NValue );                   // initialization function

  int mNValue;                                 // N-value
  std::vector< std::vector<Cell *> > mCells;   // array of pointers to cells 
  std::vector<GridSet *> mRows;                // array of pointers to rows
  std::vector<GridSet *> mCols;                // array of pointers to columns
  std::vector<GridSet *> mSquares;             // array of pointers to squares 
};


#endif // __GRID_H__
