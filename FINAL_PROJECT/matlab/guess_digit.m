function [ digit ] = guess_digit( bitmapX, ppmaps )
%
% USAGE: digit = guess_digit( bitmapX )
%
%   return best guess of digit (0 through 9) represented by
%   28x28 grayscale bitmapX, based on MNIST database
%
%   ppmaps is array of pixel probability maps returned by 
%   get_pixprob_maps
%

logprobs=[];

% threshold is the pixel intensity value between OFF and ON
threshold = 75;

% calculate log probabilities over all digits 
for digit = 1:10
  logprobs( digit ) = get_logprob_YgivenX( ppmaps{ digit }, bitmapX, threshold );
end

[ maxlogprob, digit ] = max( logprobs );

if ( digit == 10 ) 
  digit = 0;
end

%fprintf( 'BEST GUESS IS %d\n', digit );

end

      
