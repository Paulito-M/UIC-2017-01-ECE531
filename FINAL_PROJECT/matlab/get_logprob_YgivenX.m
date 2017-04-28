function [ logprob_YgivenX ] = get_logprob_YgivenX( ppmapY, bitmapX, threshold )
%
% USAGE: logprob = get_logprob( ppmapY, bitmapX, threshold )
%
%   ppmapY is the pixel probability map of digit Y: 0 <= y <= 9
%     ie map of probability that pixel is ON
%   bitmapX is the 28x28 grayscale bitmap of the digit, where
%   background ~ 0 dark, foreground >> 0 light and
%   each pixel value between 0 and 255
%   pixel < theshold: OFF
%   pixel >= threshold: ON
%

logprob = 0.0;

% logP( Y | X ) = logP( Y ) + logP( X | Y )
% logP( X | Y ) = sum( logP( pixelX | Y ) for all pixelX

for row = 1:28
  for col = 1:28
    if ( bitmapX( row, col ) >= threshold  )
      logprob = logprob + log( ppmapY( row, col ) );
    else
      logprob = logprob + log( ( 1 - ppmapY( row, col ) ) );
    end
  end
end  

logprob_YgivenX = logprob;
end
        
