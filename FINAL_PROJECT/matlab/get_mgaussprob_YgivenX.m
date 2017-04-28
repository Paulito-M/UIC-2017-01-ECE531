function [ Mgaussprob_YgivenX ] = get_Mgaussprob_YgivenX( meanvector, covarmatrix, bitmapX )
%

pixelvector = [];
numpixels = 1;
for row = 1:28
    for col = 1:28
          pixelvector( numpixels ) = bitmapX(row, col);
              numpixels = numpixels + 1;
    end
end

term1 = ( pixelvector - meanvector ) * inv( covarmatrix ) * transpose( pixelvector - meanvector );

term2 = 0.5 * log( norm( covarmatrix ) );


Mgaussprob_YgivenX = 0 - term1 - term2;
end
        
