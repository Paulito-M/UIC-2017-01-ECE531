//==============================================================================
// GridSet.cpp
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
#include "stdafx.h"
#include <math.h>
#include "GridSet.h"


//------------------------------------------------------------------------------
// GridSet::GridSet()
//------------------------------------------------------------------------------
GridSet::GridSet()
{
}


//------------------------------------------------------------------------------
// GridSet::~GridSet()
//------------------------------------------------------------------------------
GridSet::~GridSet()
{
}


//------------------------------------------------------------------------------
// GridSet::AddCell()
//------------------------------------------------------------------------------
void GridSet::AddCell( Cell *_Cell )
{
  mCells.push_back( _Cell );
}


//------------------------------------------------------------------------------
// GridSet::IsValuePresent()
//------------------------------------------------------------------------------
bool GridSet::IsValuePresent( int _Value )
{
  for ( int index = 0 ; index < mCells.size() ; index++ )
    if ( mCells[ index ]->GetValue() == _Value )
      return( true );

  return( false );
}


//------------------------------------------------------------------------------
// GridSet::IsPossibleValuePresent()
//------------------------------------------------------------------------------
bool GridSet::IsPossibleValuePresent( Cell *_Cell, int _Value )
{
  //
  // Walk through each Cell in the GridSet...
  //
  for ( int index = 0 ; index < mCells.size() ; index++ )
  {
    // 
    // If the Cell is not the specified parameter cell, determine if
    // the specified value is possible.
    //
    if ( ( mCells[ index ] != _Cell ) &&
         ( mCells[ index ]->IsValuePossible( _Value ) ) )
      return( true );
  }

  return( false );  
}


//------------------------------------------------------------------------------
// GridSet::FindUniquePossibleValue()
//------------------------------------------------------------------------------
bool GridSet::FindUniquePossibleValue( Cell **_Cell, int *_Value )
{
  //
  // Walk through each Cell in the GridSet...
  //
  for ( int index = 0 ; index < mCells.size() ; index++ )
  {
    //
    // ...for each cell, determine if it contains a possible value that
    // is unique within the GridSet...
    //
    int UniqueValue =  mCells[ index ]->
      FindUniquePossibleValueFromGridSet( this );

    if ( UniqueValue != 0 )
    {
      // 
      // FOUND!
      //
      // Return the cell, and the value.
      //
      *_Cell = mCells[ index ];
      *_Value = UniqueValue;      

      return( true );
    }
  }

  return( false );
}


//------------------------------------------------------------------------------
// GridSet::IsSolved()
//------------------------------------------------------------------------------
bool GridSet::IsSolved()
{
  bool result = true;

  // 
  // The GridSet is solved if all of the cells in the grid are populated
  // with the positive integers from 1 to N, where N is the number of
  // cells in the GridSet.
  //
  // We simply search for the presence of each integer, terminating if
  // the first integer is not found.
  //
  for ( int searchValue = 1 ; 
        searchValue <= mCells.size() && result ;
        searchValue++ )
  {
    int index;
    for ( index = 0 ; index < mCells.size() ; index++ )
      if ( mCells[index]->GetValue() == searchValue )
        break;

    if ( index == mCells.size() )
      result = false;
  }

  return( result );
}


