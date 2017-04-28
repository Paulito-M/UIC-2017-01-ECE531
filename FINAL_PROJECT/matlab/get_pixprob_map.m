function [ ppmap ] = get_pixprob_map( chars, threshold )
%
% USAGE: ppmap = get_pixprob_map( chars )
%
%   ppmap( 1, 1 ) returns the probability of pixel (1,1) being ON
%
% chars is the returned array from read_mnist_file() comprising
% 1000 28x28 pixel grayscale bitmaps for a given digit, where each
% pixel ranges from 0 (black) to 255 (white)
%
% assume 0 is OFF, and 1 is ON;
% calculate the probability of each pixel being ON over all 1000
% samples of the digit, via the threshold parameter:
%   pixel_value < threshold: OFF 
%   pixel_value >= threshold: ON
%
% return a 28x28 array of (real valued) probabilities ranging
% from 0.0 to 1.0 for each pixel:
%   0.0 = pixel is always OFF, in all samples
%   1.0 = pixel is always ON, in all samples
% modify the bitmaps in the chararray returned by read_mnist_file()
% so that, instead of 
% return a vector of bitmaps in the MNIST data file _filename
% each bitmap is a 28x28 array of UINT8 representing pixel
% intensities (0-255)
%

ppmap=[];
chars_size = size( chars );
num_chars = chars_size( 3 );

% some pixels may always be OFF (eg pixels along edges/corners)
% since eventually the log probabilities will be taken, we need
% to ensure the probability is NOT zero; therefore, always add
% the smoothCount to the numerator and denominator when calculating
% the probability
smoothCount = 1;

for row = 1:28
  for col = 1:28
      
    ppmap( row, col ) = 0.0;
    
    % count the number of times the pixel is ON
    for charCount = 1:num_chars
      if ( chars( row, col, charCount ) >= threshold ) 
        ppmap( row, col ) = ppmap( row, col ) + 1;    
      end
    end
    % calculate the probability the pixel is ON
    ppmap( row, col ) = ( ppmap( row, col ) + smoothCount ) / ( num_chars + smoothCount );
  end
end  

fprintf( 'TOTAL CHARACTERS=%d\n', num_chars );

end
