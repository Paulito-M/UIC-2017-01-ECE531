function [ digit ] = guess_digit2( bitmapX )
%
% USAGE: digit = guess_digit( bitmapX )
%
%   return best guess of digit (0 through 9) represented by
%   28x28 grayscale bitmapX, based on MNIST database
%

ppmaps=[];

% initialize the MNIST database 
ppmaps = get_pixprob_maps();

digit = guess_digit( bitmapX, ppmaps );

end

      
