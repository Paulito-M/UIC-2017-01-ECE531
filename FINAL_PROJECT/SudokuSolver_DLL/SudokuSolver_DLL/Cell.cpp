//==============================================================================
// Cell.cpp
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
#include "stdafx.h"
#include <stdio.h>
#include <stdexcept>
#include <math.h>
#include "Cell.h"
#include "GridSet.h"


//------------------------------------------------------------------------------
// Cell::Cell()
//------------------------------------------------------------------------------
Cell::Cell( int _NValue )
  : mValue( 0 ),
    mNValue( _NValue )  
{
  //
  // Initialize pointers to row, column, and square
  //
  mRow = mCol = mSquare = NULL;

//  mNext = NULL;
}

                
//------------------------------------------------------------------------------
// Cell::Cell()
//------------------------------------------------------------------------------
Cell::Cell( int _Value, int _NValue )
 : mValue( _Value ),
   mNValue( _NValue )
{
  //
  // Initialize pointers to row, column, and square
  // 
  mRow = mCol = mSquare = NULL;

//  mNext = NULL;
}


//------------------------------------------------------------------------------
// Cell::~Cell()
//------------------------------------------------------------------------------
Cell::~Cell()
{
}


//------------------------------------------------------------------------------
// Cell::SetValue()
//------------------------------------------------------------------------------
void Cell::SetValue( int _Value )
  throw( out_of_range )        
{
  //
  // Validate parameter.
  //
  if ( ( _Value < 0 ) || ( _Value > mNValue ) )
    throw out_of_range( "Value invalid" );

  mValue = _Value;

  //
  // If the value is non-zero (representing an actual value), clear all 
  // possible values.
  //
  if ( mValue > 0 )
    mPossibleValues.clear();
}


//------------------------------------------------------------------------------
// Cell::Set*()
//------------------------------------------------------------------------------
void Cell::SetRow( GridSet *_Row )
{
  mRow = _Row;
}


void Cell::SetCol( GridSet *_Col )
{
  mCol = _Col;
}


void Cell::SetSquare( GridSet *_Square )
{
  mSquare = _Square;
}


//------------------------------------------------------------------------------
// Cell::SetAllPossibleValues()
//------------------------------------------------------------------------------
void Cell::SetAllPossibleValues( void )
{
  //
  // Only set the possible values if this cell's current value has not
  // been defined. If the current value has been defined, it is presumed
  // that there is no need to determine possible values.
  //
  if ( mValue == 0 )
  {
    //
    // First, clear all possible values for this cell.
    //
    mPossibleValues.clear();

    //
    // For each possible value: if the value is not already present in
    // any of the cells in the row, column, or square to which this
    // cell belongs, then the value is a possible value that can be
    // assigned to this cell.
    //
    for ( int PossibleValue = 1 ; 
          PossibleValue <= mNValue ;          
          PossibleValue++ )
    {
      if ( ( ( mRow != NULL ) && 
             ( !mRow->IsValuePresent( PossibleValue ) ) ) &&
           ( ( mCol != NULL ) &&
             ( !mCol->IsValuePresent( PossibleValue ) ) ) &&
           ( ( mSquare != NULL ) &&
             ( !mSquare->IsValuePresent( PossibleValue ) ) ) ) 
      {
        // 
        // Insert value into list of possible values
        //
        mPossibleValues.insert( PossibleValue );
      }
    }            
  }
}


//------------------------------------------------------------------------------
// Cell::GetFirstPossibleValue()
//------------------------------------------------------------------------------
int Cell::GetFirstPossibleValue()
{
  //
  // If this cell's value is defined, or if there are no possible values,
  // return 0
  //
  if ( ( mValue != 0 ) || ( mPossibleValues.size() == 0 ) )
    return( 0 );

  //
  // Otherwise, return the first element of the possible values set, and 
  // initialize the possible value iterator 
  //
  mNext = mPossibleValues.begin();

  return( *mNext );
}


//------------------------------------------------------------------------------
// Cell::GetNextPossibleValue()
//------------------------------------------------------------------------------
int Cell::GetNextPossibleValue()
{
  // 
  // If thie cell's value is defined, or if there are no possible values, 
  // or if the iterator is NULL, or if we have exceeded all possible values,
  // return 0
  //
  if ( ( mValue != 0 ) || ( mPossibleValues.size() == 0 ) ||
//       ( mNext == NULL ) ||  ( mNext == mPossibleValues.end() ) )
 (mNext == mPossibleValues.end()))
    return( 0 );

  mNext++;

  return( *mNext );
}

//------------------------------------------------------------------------------
// Cell::IsValuePossible()
//------------------------------------------------------------------------------
bool Cell::IsValuePossible( int _PossibleValue )
{
  //
  // Return whether the value is in the list of possible values for
  // this cell.
  //
  if ( mPossibleValues.find( _PossibleValue ) == mPossibleValues.end() )
    return( false );

  return( true );  
}        


//------------------------------------------------------------------------------
// Cell::FindUniquePossibleValueFromGridSet()
//------------------------------------------------------------------------------
int Cell::FindUniquePossibleValueFromGridSet( GridSet *_GridSet )
{

  // 
  // If the indicated GridSet is not defined, or if this cell already has
  // a defined value, return 0.
  //
  if ( ( _GridSet == NULL ) || ( mValue != 0 ) )
    return( 0 );

  //
  // Iterate through the list of possible values for this cell.
  //
  for ( set<int>::iterator Value = mPossibleValues.begin() ; 
        Value != mPossibleValues.end() ; 
        Value++ )
  {
    //
    // If this possible value is not present in the other cells of the
    // specified GridSet, then it is unique.
    //
    if ( !_GridSet->IsPossibleValuePresent( this, *Value ) )
      return( *Value );
  }    

  //
  // If we got here, there were no unique possible values.
  //
  return( 0 );
}

