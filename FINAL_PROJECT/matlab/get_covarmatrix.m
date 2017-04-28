function [ covar ] = get_covarmatrix( chars, meanvector, threshold )
%

chars_size = size( chars );
num_chars = chars_size( 3 );

stddev_vector=[];

num_pixel = 1;

for row = 1:28
  for col = 1:28
       
    stddev_vector( num_pixel ) = 0.0;
    
    % sum the differences over all characters between pixel ON and mean
    for charCount = 1:num_chars
      if ( chars( row, col, charCount ) >= threshold ) 
        stddev_vector( num_pixel ) = stddev_vector( num_pixel ) + 1 - meanvector( num_pixel );
      else
        stddev_vector( num_pixel ) = stddev_vector( num_pixel ) + 0 - meanvector( num_pixel );
      end
    end
            num_pixel = num_pixel + 1;
  end

end  

stddev_vector = transpose( stddev_vector );
covar = stddev_vector * transpose( stddev_vector );
covar = covar / num_chars;

fprintf( 'TOTAL CHARACTERS=%d\n', num_chars );

end
