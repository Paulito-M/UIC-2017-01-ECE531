//==============================================================================
// Grid.cpp
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
#include "stdafx.h"
#include <iostream> // DBG
#include <math.h>
#include "Grid.h"
using namespace std; // DBG


//------------------------------------------------------------------------------
// Grid::Grid()
//------------------------------------------------------------------------------
Grid::Grid()
{
  // 
  // Invoke initialization function, specifying default value for N
  //
  i_Grid( DEFAULT_SIZE );
}


//------------------------------------------------------------------------------
// Grid::Grid()
//------------------------------------------------------------------------------
Grid::Grid( int _NValue )
{
  // 
  // Invoke initialization function
  //
  i_Grid( _NValue );
}


//------------------------------------------------------------------------------
// Grid::Grid()
//------------------------------------------------------------------------------
Grid::Grid( const Grid& _src )
{
  int nValue = _src.GetNValue();

  //
  // Invoke initialization function
  //
  i_Grid( nValue );

  //
  // Copy cell values.
  //
  // Note that it is not necessary to copy the possible values for those
  // cells without nonzero values, as the possible values will be 
  // defined when needed.
  //
  for ( int row = 0 ; row < nValue ; row++ )
    for ( int col = 0 ; col < nValue ; col++ )
      *mCells[ row ][ col ] = *_src.mCells[ row ][ col ];
}


//------------------------------------------------------------------------------
// Grid::~Grid()
//------------------------------------------------------------------------------
Grid::~Grid()
{
  //
  // Free the cells. The vectors automatically take care of freeing their
  // memory resources; and as the vectors themselves are member variables,
  // they are automatically freed.
  //
  for ( int row = 0 ; row < mNValue ; row++ )
    for ( int col = 0 ; col < mNValue ; col++ )
      delete( mCells[ row ][ col ] );
}


//------------------------------------------------------------------------------
// Grid::operator=()
//------------------------------------------------------------------------------
const Grid& Grid::operator=( const Grid& _rhs )
{
  if ( this != &_rhs )
  {
    for ( int row = 0 ; row < mNValue ; row++ )
      for ( int col = 0 ; col < mNValue ; col++ )
        *mCells[ row ][ col ] = *_rhs.mCells[ row ][ col ];
  }        

  return( *this );      // return self-reference so cascaded assignment works
}


//------------------------------------------------------------------------------
// Grid::SetCellValue()
//------------------------------------------------------------------------------
void Grid::SetCellValue( int _Row,
                         int _Column,
                         int _Value )
  throw( out_of_range )
{
  //
  // Validate parameters
  //
  // Note that we allow a value of 0, since we can clear a cell.
  //
  if ( ( _Row < 0 ) || ( _Row > mNValue - 1 ) )
    throw out_of_range( "Row invalid" );

  if ( ( _Column < 0 ) || ( _Column > mNValue - 1 ) )
    throw out_of_range( "Column invalid" );

  if ( ( _Value < 0 ) || ( _Value > mNValue ) )
    throw out_of_range( "Value invalid" );

  //
  // Set value of specified cell
  //
  mCells[ _Row ][ _Column ]->SetValue( _Value );
}


//------------------------------------------------------------------------------
// Grid::GetCellValue()
//------------------------------------------------------------------------------
int Grid::GetCellValue( int _Row,
                        int _Column )
  throw( out_of_range )
{
  //
  // Validate parameters
  //
  if ( ( _Row < 0 ) || ( _Row > mNValue - 1 ) )
    throw out_of_range( "Row invalid" );

  if ( ( _Column < 0 ) || ( _Column > mNValue - 1 ) )
    throw out_of_range( "Column invalid" );

  // 
  // Return value of specified cell
  //
  return( mCells[ _Row ][ _Column ]->GetValue() );
}


//------------------------------------------------------------------------------
// Grid::Solve()
//------------------------------------------------------------------------------
bool Grid::Solve()
{
  // 
  // First check if the grid is already solved; if so, return true.
  //
  if ( IsSolved() )
    return( true );

  //
  // N-Value must be a perfect square; otherwise, we don't consider this
  // a proper Sudoku grid and it is thus unsolvable.
  //
  if ( sqrt( (float)mNValue ) != static_cast<int>( sqrt( (float)mNValue ) ) )
    return( false );

  //
  // SOLUTION ALGORITHM:
  // 
  // Iterate through this loop until either the grid is solved, or
  // the end of the loop is reached without having made any modifications
  // to the grid.
  //
  bool continueLoop;
  do
  { 
    cout << "========> ALGORITHM LOOP START" << endl; // DBG
    continueLoop = false;

    //
    // 1. UPDATE LIST OF POSSIBLE VALUES
    //
    //    Go through every cell that does not already have a value, and
    //    populate that cell's list of possible values.
    //
    for ( int row = 0 ; row < mNValue ; row++ )
      for ( int col = 0 ; col < mNValue ; col++ )
        if ( mCells[ row ][ col ]->GetValue() == 0 )
        {
          mCells[ row ][ col ]->SetAllPossibleValues();
          cout << "  CELL(" << row << "," << col << ") POSSIBLE VALUES SET" << endl; // DBG
        }

    //
    // 2. SEARCH FOR UNIQUE POSSIBLE VALUES AMONG GRIDSETS
    //
    //    For each GridSet (row, column, and square): find out if there
    //    is a cell with a unique possible value, that does not exist
    //    in the other cells for that GridSet.  
    //
    //    If so: assign that unique possible value to the cell, and 
    //    restart the algorithm loop.
    //
    for ( int index = 0 ; index < mNValue ; index++ )
    {
      Cell *searchCell;
      int NewValue;
  
      if ( mRows[ index ]->FindUniquePossibleValue( &searchCell, &NewValue ) )
      {
        searchCell->SetValue( NewValue );
        cout << "  CELL(row=" << index << ") VALUE SET TO " << NewValue << endl; // DBG
        continueLoop = true;
        break;
      }

      if ( mCols[ index ]->FindUniquePossibleValue( &searchCell, &NewValue ) )
      {
        searchCell->SetValue( NewValue );
        cout << "  CELL(col=" << index << ") VALUE SET TO " << NewValue << endl; // DBG
        continueLoop = true;
        break;
      }
 
      if ( mSquares[ index ]->FindUniquePossibleValue( &searchCell, &NewValue ) )
      {
        searchCell->SetValue( NewValue );
        cout << "  CELL(square=" << index << ") VALUE SET TO " << NewValue << endl; // DBG
        continueLoop = true;
        break;
      }
    }

    if ( continueLoop )
      continue;

    //
    // 3. ARBITRARILY CHOOSE A POSSIBLE VALUE 
    //
    //    If we got to this point, and the grid is not solved, there are no 
    //    more values that can deterministically be assigned to cells. 
    //    This means we have to choose from among the possible values to 
    //    assign to a cell.
    //
    //    We choose the first cell that does not have a defined value,
    //    and loop through each of its defined values. For each defined
    //    value, we create a duplicate grid, define the cell to contain
    //    that value, and attempt to solve the grid (i.e., we recursively
    //    call Solve() on the duplicate grid).
    //
    //    If successful, the duplicate grid will actually contain the
    //    solved cell values, so we copy it into our grid.
    //
    //    If we loop through all of the cell's possible values without
    //    successfully solving the temporary grid, we quit, and assume
    //    something is wrong with our algorithm.
    //

    if ( !IsSolved() )
    {
      cout << "******* DANGER DANGER DANGER: DECISION TIME!!!!!" << endl; // DBG
      
      bool quit = false;

      for ( int row = 0 ; row < mNValue && !quit ; row++ )
        for ( int col = 0 ; col < mNValue && !quit ; col++ )
          if ( mCells[ row ][ col ]->GetValue() == 0 )
          {
            for ( int tryValue = mCells[ row ][ col ]->GetFirstPossibleValue() ;
                  tryValue != 0 ;
                  tryValue = mCells[ row ][ col ]->GetNextPossibleValue() )
            {
              Grid newGrid = *this;

              cout << "   CELL(" << row << "," << col << "): TRYING VALUE << "<< tryValue << endl;
              newGrid.mCells[ row ][ col ]->SetValue( tryValue );
              if ( newGrid.Solve() )
              {
                //
                // SUCCESS, the grid is solved.
                //
                // Save the new grid value to the current grid, and break
                // out of this loop and quit.
                //
                cout << "    SUCCESS!!!! IT WORKED!" << endl;
                *this = newGrid;
                quit = true;
                break;
              }
              else
              {
                cout << "    FAILURE!!!!" << endl;
              }
            }
          }
    }    
    
  } while ( continueLoop );

  //
  // At this point, we have either solved the grid, or not. 
  //
  return( IsSolved() );
 
}


//------------------------------------------------------------------------------
// Grid::IsSolved()
//------------------------------------------------------------------------------
bool Grid::IsSolved()
{
  //
  // N-Value must be a perfect square; otherwise, we don't consider this
  // a proper Sudoku grid.
  //
  if ( sqrt( (float)mNValue ) != static_cast<int>( sqrt( (float)mNValue ) ) )
    return( false );

  //
  // Verify all rows
  //
  for ( int row = 0 ; row < mNValue ; row++ )
    if ( !mRows[ row ]->IsSolved() )
      return( false );

  // 
  // Verify all columns
  //
  for ( int col = 0 ; col < mNValue ; col++ )
    if ( !mCols[ col ]->IsSolved() )
      return( false );
  
  //
  // Verify all squares
  //
  for ( int square = 0 ; square < mNValue ; square++ )
    if ( !mSquares[ square ]->IsSolved() )
      return( false );   

  // 
  // If we got to this point, the grid is solved!
  //
  return( true );

}


//------------------------------------------------------------------------------
// Grid::i_Grid()
//------------------------------------------------------------------------------
void Grid::i_Grid( int _NValue )
{
  mNValue = _NValue;
  
  //
  // Allocate N x N pointers to cells, as well as the cells themselves
  //
  mCells.resize( mNValue );
  for ( int row = 0 ; row < mNValue ; row++ )
  {          
    mCells[ row ].resize( mNValue );

    for ( int col = 0 ; col < mNValue ; col++ )
      mCells[ row ][ col ] = new Cell( mNValue );
  }

  //
  // Create rows.
  //
  // Add cells to each row, and also configure each cell so it knows
  // what row it belongs to!
  //
  mRows.resize( mNValue );
  for ( int row = 0 ; row < mNValue ; row++ )
  {
    mRows[ row ] = new GridSet();
    for ( int col = 0 ; col < mNValue ; col++ )
    {
      mRows[ row ]->AddCell( mCells[ row ][ col ] );
      mCells[ row ][ col ]->SetRow( mRows[ row ] );
    }
  }

  //
  // Create columns.
  //
  // Add cells to each column, and also configure each cell so it knows
  // what row it belongs to!
  //
  mCols.resize( mNValue );
  for ( int col = 0 ; col < mNValue ; col++ )
  {
    mCols[ col ] = new GridSet();
    for ( int row = 0 ; row < mNValue ; row++ )
    {
      mCols[ col ]->AddCell( mCells[ row ][ col ] );
      mCells[ row ][ col ]->SetCol( mCols[ col ] );
    }
  }

  //
  // Create squares, BUT only if this mNValue is a perfect square!
  //
  // Add cells to each square, and also configure each cell so it 
  // knows which square it belongs to!
  //
  float mNValueRoot;
  if ( ( mNValueRoot = sqrt( (float)mNValue ) )  == 
    static_cast<int>( sqrt( (float)mNValue ) ) )
  {
    int squareCounter = 0;
    mSquares.resize( mNValue );
    for ( int row = 0 ; row < mNValue ; row = row +
      static_cast<int>( mNValueRoot ) )
      for ( int col = 0 ; col < mNValue ; col = col +
        static_cast<int>( mNValueRoot ) )
      {
        mSquares[ squareCounter ] = new GridSet();
        
        for ( int innerRow = 0 ; innerRow < mNValueRoot ; innerRow++ )
          for ( int innerCol = 0 ; innerCol < mNValueRoot ; innerCol++ )
          {
            mSquares[ squareCounter ]->AddCell( 
              mCells[ row + innerRow ][ col + innerCol ] );
            mCells[ row + innerRow ][ col + innerCol ]->SetSquare(
              mSquares[ squareCounter ] );
          }

        squareCounter++;
      }
  }
}
