function [ gaussprob_YgivenX ] = get_gaussprob_YgivenX( pgmapY, bitmapX )
%
% USAGE: logprob = get_gaussprob_YgivenX( pgmapY, bitmapX )
%
%   pgmapY is the gaussian probability map of digit Y: 0 <= y <= 9
%     ie map of pixel means, variances for digit Y
%     as returned by get_pixgauss_map()
%   bitmapX is the 28x28 grayscale bitmap of the digit, where
%   background ~ 0 dark, foreground >> 0 light and
%   each pixel value between 0 and 255
%

logprob = 0.0;

% logP( Y | X ) = logP( Y ) + logP( X | Y )
% logP( X | Y ) = sum( logP( pixelX | Y ) for all pixelX

for row = 1:28
  for col = 1:28
      mean = pgmapY( row, col, 1 );
      variance = pgmapY( row, col, 2 );
      
      % ALTERNATE 1: minimize variance to something very small
      if variance ~= 0 
          variance = 0.000001;
      %end
      % ALTERNATE 2: don't consider this element if variance is zero
      %if variance ~= 0
         logprob = logprob +  log( 1.0 / sqrt( 2 * pi * variance ) );
         logprob = logprob - ( ( bitmapX( row, col ) - mean )^2 ) / ( 2 * variance );      
      %end         
  end
end  

gaussprob_YgivenX = logprob;
end
        
