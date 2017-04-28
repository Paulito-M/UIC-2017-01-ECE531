function [ DIGITS ] = read_mnist_files( )
%
% USAGE: digitarray = read_mnist_files( )
%
%   digitarray{1} returns the chararray() for the digit 1
%   digitarray{10} returns the chararray() for the digit 0
%   image( digitarray{3}(:,:,55)) displays the 55th digit '3' image
%
% return a cell array of chararrays() as populated by read_mnist_file()
%
% SOURCE: http://cis.jhu.edu/~sachin/digit/digit.html

digits=[];

for digit = 1:10
  fprintf( 'DIGIT IS %d\n', mod( digit, 10 ) );
  
  %fname = 'data' + str(mod(digit,10)) + '.bin';
  fname = strcat( 'data', int2str( mod( digit, 10 ) ) );
  fname = strcat( fname, '.bin');
  fprintf( 'FILENAME IS %s\n', fname );
  
  digits{digit}=read_mnist_file( fname );
end

  DIGITS = digits;  
end
