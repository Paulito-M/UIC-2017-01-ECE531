function [ pgmap ] = get_pixgauss_map( chars )
%
% USAGE: pgmap = get_pixgauss_map( chars )
%
%   pgmap( 1, 1, 1 ) returns mean of pixel( 1, 1 )
%   pgmap( 1, 1, 2 ) returns variance of pixel( 1, 1 )
%
% chars is the returned array from read_mnist_file() comprising
% 1000 28x28 pixel grayscale bitmaps for a given digit, where each
% pixel ranges from 0 (black) to 255 (white)
%
% assume 0 is OFF, and 255 is ON
% calculate the mean and variance of each pixel
% these parameters define the Gaussian distribution of each pixel
% for the given digit
%

pgmap=[];

chars_size = size( chars );
num_chars = chars_size( 3 );

for row = 1:28
  for col = 1:28
        
    % calculate the mean
    mean = 0;
    for charCount = 1:num_chars
        mean = mean + chars( row, col, charCount );
    end
    
    mean = mean /  num_chars;
            
    % calculate the variance
    variance = 0;
    for charCount = 1:num_chars
        variance = variance + ( chars( row, col, charCount ) )^2;
    end
    
    variance = variance / num_chars;
    variance = variance - ( mean )^2;
    
    fprintf( 'PIXEL (%d, %d): MEAN=%f VAR=%f\n', row, col, mean, variance );
    
    pgmap( row, col, 1 ) = mean;
    pgmap( row, col, 2 ) = variance;
  end
end  

fprintf( 'TOTAL CHARACTERS=%d\n', num_chars );

end
