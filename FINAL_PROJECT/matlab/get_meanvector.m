function [ meanvector ] = get_meanvector( chars, threshold )
%
% USAGE: meanvector = get_meanvector( chars, threshold )
%
%   meanvector( 35 ) returns the mean, or average, value of
%   pixel 35 in the 784-pixel BINARY bitmap. Each pixel
%   value mean should range from 0 to 1
%
%   threshold is the grayscale value assuming each
%   pixel ranges from 0 (black) to 255 (white). Above this
%   threshold, the pixel is considered ON.
%

meanvector=[];
chars_size = size( chars );
num_chars = chars_size( 3 );

num_pixel = 1;

for row = 1:28
  for col = 1:28
      
    meanvector( num_pixel ) = 0.0;
    
    % count the number of times the pixel is ON
    for charCount = 1:num_chars
      if ( chars( row, col, charCount ) >= threshold ) 
        meanvector( num_pixel ) = meanvector( num_pixel ) + 1;    
      end
    end
    % calculate the mean ie average
    meanvector( num_pixel ) = meanvector( num_pixel ) / num_chars;
    num_pixel = num_pixel + 1;
  end
end  

fprintf( 'TOTAL CHARACTERS=%d\n', num_chars );

end
