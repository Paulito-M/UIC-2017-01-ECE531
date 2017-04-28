function [ pgmaps ] = get_pixgauss_maps( )
%
% USAGE: pgmaps = get_pixelgauss_maps( )
%
%   pgmaps( 1 ) returns the pgmap of digit 1
%   pgmaps( 10 ) returns the pgmap of digit 0
%
% invoke get_pixgauss_map() to create and return the array of
% pixel mean, variance maps for digits 0 through 9
%

digits=[];
pgmaps=[];

% invoke read_mnist_files() to retrieve the MNIST bitmaps for
% digits 0 through 9
digits = read_mnist_files();

% invoke get_pixgauss_map() to calculate the pixel mean, variance
% maps from the MNIST data

for digit = 1:10
  pgmaps{ digit } = get_pixgauss_map( digits{ digit } );      
end

end
