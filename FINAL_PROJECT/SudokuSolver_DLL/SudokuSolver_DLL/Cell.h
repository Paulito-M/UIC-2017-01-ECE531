#ifndef __CELL_H__
#define __CELL_H__
//==============================================================================
// Cell.h
//
// DESCRIPTION:
//   The Cell object represents the Sudoku grid element which contains
//   the integer value.
//
// &HISTORY.
//   2006-08-28 PNM - Created.
//   2008-05-29 PNM - Updated comments.
// &EHISTORY.
//==============================================================================


//------------------------------------------------------------------------------
// HEADER FILES
//------------------------------------------------------------------------------
#include <set>
#include <stdexcept>
using namespace std;


//------------------------------------------------------------------------------
// FORWARD DECLARATIONS
//------------------------------------------------------------------------------
class GridSet;


//------------------------------------------------------------------------------
// CLASS: Cell
//
// DESCRIPTION:
//   The Cell object represents the Sudoku grid element which contains
//   the integer value.
//
//   The Sudoku grid is composed of 'N' Cells; as well, each row, column,
//   and square of Cells in the Sudoku grid is encapsulated in the
//   GridSet object.
//
//   The Cell object not only contains its value, but also is cognizant
//   of the number of cells in its grid, and the row, column, and square
//   GridSets to which it belongs.
//------------------------------------------------------------------------------
class Cell
{
  public:
 
  //----------------------------------------------------------------------------
  // DESCRIPTION:
  //   Constructor
  //
  // PARAMETERS:
  //   int - Number of cells in grid
  //----------------------------------------------------------------------------
  Cell( int _NValue );


  //----------------------------------------------------------------------------
  // DESCRIPTION:
  //   Constructor
  //
  // PARAMETERS:
  //   int - initial value of cell
  //   int - Number of cells in grid
  //----------------------------------------------------------------------------
  Cell( int _Value, int _NValue );


  //----------------------------------------------------------------------------
  // DESCRIPTION:
  //   Destructor
  //----------------------------------------------------------------------------
  ~Cell();
  

  //----------------------------------------------------------------------------
  // DESCRIPTION:
  //   Assignment operator; copies the value of the cell
  //
  // PARAMETERS:
  //   Cell& - rhs
  //
  // RETURNS:
  //   Cell&
  //----------------------------------------------------------------------------
  const Cell& operator=( const Cell& _rhs ) 
  { mValue = _rhs.mValue ; return( *this ); }


  //----------------------------------------------------------------------------
  // DESCRIPTION:
  //   Get the value of the cell
  //
  // PARAMETERS:
  //   N/A
  //
  // RETURNS:
  //   Value of cell
  //----------------------------------------------------------------------------
  int GetValue()                { return( mValue );   }      


  //----------------------------------------------------------------------------
  // DESCRIPTION:
  //   Set the value of the cell
  //
  // PARAMETERS:
  //   int - value to set
  //
  // RETURNS:
  //   N/A
  //----------------------------------------------------------------------------
  void SetValue( int _Value )
    throw( out_of_range );          


  //----------------------------------------------------------------------------
  // DESCRIPTION:
  //   Initialize the cell's pointer to the indicated GridSet.
  //
  //   Associating the cell with the GridSet to which it belongs allows 
  //   the value of the cell to be examined in comparison with other cells 
  //   in the GridSet. This is used when determining if the cell's 
  //   value is unique.
  //
  // PARAMETERS:
  //   GridSet * - value to initialize
  //
  // RETURNS:
  //   N/A
  //----------------------------------------------------------------------------
  void SetRow( GridSet *_Row );
  void SetCol( GridSet *_Col );
  void SetSquare( GridSet *_Square );


  //----------------------------------------------------------------------------
  // DESCRIPTION:
  //   Initialize the cell's set of possible values, based on the values
  //   of other cells in this cell's row, column, and square GridSets.
  //
  //   Note that if this cell's value is set (i.e. is non-zero), it is
  //   assumed this value is valid, and the possible values are not 
  //   updated.
  //
  // PARAMETERS:
  //   N/A
  //
  // RETURNS:
  //   N/A
  //----------------------------------------------------------------------------
  void SetAllPossibleValues( void );


  //----------------------------------------------------------------------------
  // DESCRIPTION:
  //   Get the first possible value defined for the cell, or 0 if the
  //   cell has a value defined or does not have any possible values.
  //
  // PARAMETERS:
  //   N/A
  //
  // RETURNS:
  //   int - first possible value for cell, or 0 if cell has a defined
  //   value or does not have any possible values
  //----------------------------------------------------------------------------
  int GetFirstPossibleValue( void );


  //----------------------------------------------------------------------------
  // DESCRIPTION:
  //   Get the next possible value defined for the cell since the last
  //   time either GetFirstPossibleValue() or this function was called, or
  //   return 0 if the cell has a value defined or has no more possible
  //   values.
  //
  // PARAMETERS:
  //   N/A
  //
  // RETURNS:
  //   int = next possible value for cell, or 0 if cell has a defined 
  //   value or dooes not have any possible values or all possible
  //   values have been returned
  //----------------------------------------------------------------------------
  int GetNextPossibleValue( void );


  //----------------------------------------------------------------------------
  // DESCRIPTION:
  //   Determine if the given value is a possible value, i.e. if it is
  //   present in the list of possible values for this cell.
  //   Value should be from 1 to NValue.
  //
  // PARAMETERS:
  //   N/A
  //
  // RETURNS:
  //   bool
  //----------------------------------------------------------------------------
  bool IsValuePossible( int _PossibleValue );


  //----------------------------------------------------------------------------
  // DESCRIPTION:
  //   Determine if there is a possible value for this cell that is unique
  //   within the specified GridSet (to which the cell belongs).
  //
  //   If found, return the unique possible value.
  //
  // PARAMETERS:
  //   N/A
  //
  // RETURNS:
  //   int - a possible value
  //----------------------------------------------------------------------------
  int FindUniquePossibleValueFromGridSet( GridSet *_GridSet );


  private:

  Cell()  {};                   // disable default constructor invocation

  int mValue;                   // cell value
  GridSet *mRow;                // row to which this cell belongs
  GridSet *mCol;                // column to which this cell belongs
  GridSet *mSquare;             // square to which this cell belongs

  int mNValue;                  // number of cells in the grid
  set<int> mPossibleValues;     // set of possible cell values
  set<int>::iterator mNext;     // iterator for possible values set
};



#endif // __CELL_H__
