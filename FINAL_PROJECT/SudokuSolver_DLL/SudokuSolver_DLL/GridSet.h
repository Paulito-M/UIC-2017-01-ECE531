#ifndef __GRIDSET_H__
#define __GRIDSET_H__
//==============================================================================
// GridSet.h
//
// DESCRIPTION:
//   This class is a container for a set of cells. The set could represent
//   a row, a column, or a square of cells.
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
#include "Cell.h"
using namespace std;


//------------------------------------------------------------------------------
// CLASS: GridSet
//
// DESCRIPTION:
//   This class is a container for a set of cells. The set could represent
//   a row, a column, or a square of cells.
//------------------------------------------------------------------------------
class GridSet
{
  public:
 
  //----------------------------------------------------------------------------
  // DESCRIPTION:
  //   Constructor.
  //
  // PARAMETERS:
  //   N/A
  //----------------------------------------------------------------------------
  GridSet();


  //----------------------------------------------------------------------------
  // DESCRIPTION:
  //   Destructor.
  //----------------------------------------------------------------------------
  ~GridSet();

  
  //----------------------------------------------------------------------------
  // DESCRIPTION:
  //   Add the cell to the GridSet.
  //
  // PARAMETERS:
  //   _Cell - pointer to Cell
  //
  // RETURNS:
  //   N/A
  //----------------------------------------------------------------------------
  void AddCell( Cell *_Cell );

  
  //----------------------------------------------------------------------------
  // DESCRIPTION:
  //   Return whether the indicated value is present in a cell in the
  //   GridSet.
  //
  // PARAMETERS:
  //   _Value - integer to search for
  //
  // RETURNS:
  //   bool - true if a cell is found that contains the value
  //----------------------------------------------------------------------------
  bool IsValuePresent( int _Value );

  
  //----------------------------------------------------------------------------
  // DESCRIPTION:
  //   Determine if the indicated value is present as a possible value
  //   of the indicated cell. 
  //
  //   This function is intended to be used to determine if a 
  //   possible value found in another Cell of the GridSet is 
  //   NOT present as a possible value in a specific Cell.
  //
  // PARAMETERS:
  //   _Cell - Cell to search possible values
  //   _Value - integer to search for
  //
  // RETURNS:
  //   bool - true if the possible value is found
  //----------------------------------------------------------------------------
  bool IsPossibleValuePresent( Cell *_Cell, int _Value );

  
  //----------------------------------------------------------------------------
  // DESCRIPTION:
  //   Determine if there is a unique possible value present amongst
  //   all the cells in the GridSet.
  //
  //   If so, return the value, and a pointer to the cell.
  //
  // PARAMETERS:
  //   _Cell - returned pointer to Cell containing the unique value
  //   _Value - returned unique value
  //   
  // RETURNS:
  //   bool - true if a cell is found with a unique value
  //----------------------------------------------------------------------------
  bool FindUniquePossibleValue( Cell **_Cell, int *_Value );

  
  //----------------------------------------------------------------------------
  // DESCRIPTION:
  //   Determine if every cell has a defined, unique value. 
  //
  // PARAMETERS:
  //   N/A
  //
  // RETURNS:
  //   bool - true if every cell has a defined, unique value
  //----------------------------------------------------------------------------
  bool IsSolved();


  private:

  std::vector<Cell *> mCells;         // vector of cells 
};



#endif // __ROW_H__
