function [ ppmaps ] = get_pixprob_maps( )
%
% USAGE: ppmaps = get_pixelprob_maps( )
%
%   ppmaps( 1 ) returns the ppmap() of digit 1
%   ppmaps( 10 ) returns the ppmap of digit 0
%
% invoke get_pixprob_map() to create and return the array of
% pixel probability maps for digits 0 through 9
%

digits=[];
ppmaps=[];

% threshold is the pixel intensity value between OFF and ON
threshold = 75;

% invoke read_mnist_files() to retrieve the MNIST bitmaps for
% digits 0 through 9
digits = read_mnist_files();

% invoke get_pixprob_map() to calculate the pixel probability 
% maps from the MNIST data

for digit = 1:10
  ppmaps{ digit } = get_pixprob_map( digits{ digit }, threshold );      
end

end
