function [ CHARS ] = read_mnist_file( filename )
%
% USAGE: chararray = read_mnist_file( 'data0.bin' )
%
%   chararray(:,:,1) returns the 1st 28x28 bitmap
%   chararray(:,:,4) returns the 4th 28x28 bitmap
%   imshow( chararray(:,:,56) ) displays the 56th bitmap
%   image( chararray(:,:,56) ) better display of 56th bitmap
%
% return a vector of bitmaps in the MNIST data file _filename
% each bitmap is a 28x28 array of UINT8 representing pixel
% intensities (0-255)
%
% SOURCE: http://cis.jhu.edu/~sachin/digit/digit.html


fid=fopen( filename, 'r');   % default mode is binary
fseek(fid, 0, 'eof');
byteSize=ftell(fid);
fseek(fid, 0, 'bof');

chars=[];
charCount=1;

fprintf( 'file %s size %d\n', filename, byteSize );

% the loop, below, is suggested by the source; the resulting
% bitmap is inverted (white character on black background),
% rotated CCW 90 deg, and is flipped
%
%while byteSize>0
%  [chars(:,:,charCount), byteCount]=fread(fid, [28 28]);
%  charCount = charCount + 1;
%  byteSize = byteSize - ( 28 * 28 );
%end

%
% here's a more manual loop that corrects the above:
%
while byteSize>0
  for row = 1:28
    % read in each row of 28 pixels at a time  
    [chars(row,:,charCount),rowSize]=fread(fid,28);

    % pixel values are 0-255; invert for black-on-white background
    % if desired (uncomment the below line)
    % chars(row,:,charCount) = 255 - chars(row,:,charCount ) ;
    
  end
  charCount = charCount + 1;
  byteSize = byteSize - ( 28 * 28 );
end      

fclose(fid);

fprintf( 'TOTAL CHARACTERS=%d\n', charCount - 1 );
CHARS = chars;  
end
