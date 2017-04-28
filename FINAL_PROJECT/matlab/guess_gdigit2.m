function [ digit ] = guess_gdigit2( bitmapX )
%
% USAGE: digit = guess_gdigit( bitmapX )
%
%   return best guess of digit (0 through 9) represented by
%   28x28 grayscale bitmapX, based on MNIST database
%   using Gaussiang naive Bayesian discriminator

pgmaps=[];

% initialize the MNIST database 
pgmaps = get_pixgauss_maps();

digit = guess_gdigit( bitmapX, pgmaps );

end

      
